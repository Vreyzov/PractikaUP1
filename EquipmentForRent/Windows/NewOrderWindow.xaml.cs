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
using System.Windows.Shapes;

namespace EquipmentForRent.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private Equipment _selectedEquipment;
        private int _clientId;

        public NewOrderWindow(int clientId, int equipmentId, Equipment equipment, int lessorId)
        {
            InitializeComponent();
            _selectedEquipment = equipment;
            _clientId = clientId;

            // Инициализация данных
            EquipmentName.Text = _selectedEquipment.Name;
            PricePerDay.Text = _selectedEquipment.PricePerDay.ToString("C2");
            EndDatePicker.SelectedDate = DateTime.Now.AddDays(1); // По умолчанию завтрашний день
        }

        private void ConfirmOrderButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? endDate = EndDatePicker.SelectedDate;

            if (!endDate.HasValue || endDate <= DateTime.Now)
            {
                MessageBox.Show("Дата окончания аренды должна быть позже сегодняшнего дня.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Расчет количества дней аренды, включая начальную и конечную даты
            int totalDays = (endDate.Value - DateTime.Now.Date).Days + 1;

            // Проверка на корректное количество дней
            if (totalDays <= 0)
            {
                MessageBox.Show("Дата окончания аренды должна быть позже сегодняшнего дня.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Расчет общей стоимости
            decimal totalCost = _selectedEquipment.PricePerDay * totalDays;

            var newOrder = new Order
            {
                ClientId = _clientId,
                EquipmentId = _selectedEquipment.EquipmentId,
                LessorId = _selectedEquipment.LessorId,
                StartDate = DateTime.Now,
                EndDate = endDate.Value,
                TotalCost = totalCost
            };

            using (var context = new EquipmentRentContext())
            {
                context.Orders.Add(newOrder);
                context.SaveChanges();
            }

            MessageBox.Show($"Заказ успешно оформлен!\nИтоговая стоимость аренды: {totalCost:C2}",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();  // Закрытие окна оформления заказа
        }
    }
}
