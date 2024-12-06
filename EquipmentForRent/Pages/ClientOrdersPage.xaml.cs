using EquipmentForRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EquipmentForRent.Pages;
using Microsoft.EntityFrameworkCore;

namespace EquipmentForRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsOrdersPage.xaml
    /// </summary>
    public partial class ClientsOrdersPage : Page
    {
        private int _clientId;

        public ClientsOrdersPage(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadOrders();
        }
        private void LoadOrders()
        {
            using (var context = new EquipmentRentContext())
            {
                var orders = context.Orders
                                    .Where(o => o.ClientId == _clientId)
                                    .Include(o => o.Equipment) // Включаем данные об оборудовании
                                    .ToList();
                OrdersDataGrid.ItemsSource = orders;
            }
        }

        private void EditEndDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem is Order selectedOrder)
            {
                // Открываем окно выбора новой даты окончания аренды
                var newEndDateWindow = new DateTimePickerWindow(selectedOrder.EndDate);

                if (newEndDateWindow.ShowDialog() == true)  // Если нажата кнопка "OK"
                {
                    DateTime? newEndDate = newEndDateWindow.SelectedDate;

                    // Проверяем, что новая дата не раньше даты начала аренды
                    if (newEndDate.HasValue && newEndDate.Value < selectedOrder.StartDate)
                    {
                        MessageBox.Show("Дата окончания не может быть раньше даты начала", "Недопустимая дата", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Если дата окончания изменена
                    if (newEndDate.HasValue && newEndDate.Value != selectedOrder.EndDate)
                    {
                        // Перерасчитываем стоимость аренды
                        int rentalDays = (newEndDate.Value - selectedOrder.StartDate).Days;
                        if (rentalDays <= 0)
                        {
                            MessageBox.Show("Дата окончания должна быть позже даты начала.", "Неверная дата.", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        double dailyRate = (double)selectedOrder.Equipment.PricePerDay; // Используем PricePerDay вместо DailyRentalRate
                        double newTotalCost = rentalDays * dailyRate;  // Пересчитываем стоимость

                        // Обновляем дату окончания аренды и пересчитанную стоимость
                        selectedOrder.EndDate = newEndDate.Value;
                        selectedOrder.TotalCost = (decimal)newTotalCost;  // Обновляем поле TotalCost

                        // Обновляем заказ в базе данных
                        using (var context = new EquipmentRentContext())
                        {
                            context.Orders.Update(selectedOrder); // Обновляем заказ в контексте
                            context.SaveChanges();  // Сохраняем изменения в базе данных
                        }

                        // Перезагружаем список заказов
                        LoadOrders();
                    }
                }
                else
                {
                    // Если нажата кнопка "Cancel" или окно закрыто, ничего не меняем
                    MessageBox.Show("Изменения были отменены.", "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Обработчик кнопки "Back" для возврата на главную страницу клиента
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientHomePage(_clientId));  // Навигация на главную страницу клиента
        }
    }
}
