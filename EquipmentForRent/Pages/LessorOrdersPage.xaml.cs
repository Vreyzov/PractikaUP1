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

namespace EquipmentForRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для LessorOrdersPage.xaml
    /// </summary>
    public partial class LessorOrdersPage : Page
    {
        private int _lessorID;
        public LessorOrdersPage(int lessorID)
        {
            InitializeComponent();
            _lessorID = lessorID;
            LoadOrdersData();
        }
        private void LoadOrdersData()
        {
            using (var db = new EquipmentRentContext())
            {
                // Выгружаем все заказы, относящиеся к текущему арендодателю
                var orders = db.Orders
                               .Where(o => o.LessorId == _lessorID)
                               .Select(o => new
                               {
                                   o.OrderId,
                                   ClientName = o.Client.FirstName + " " + o.Client.LastName,
                                   EquipmentName = o.Equipment.Name,
                                   o.StartDate,
                                   o.EndDate,
                                   o.TotalCost
                               }).ToList();

                // Привязываем данные к таблице
                OrdersDataGrid.ItemsSource = orders;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенные строки
            var selectedOrders = OrdersDataGrid.SelectedItems.Cast<dynamic>().ToList();

            if (selectedOrders.Count == 0)
            {
                MessageBox.Show("Выберите заказы для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Вы уверены, что хотите удалить {selectedOrders.Count} заказ(ов)?",
                                         "Подтверждение удаления",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                using (var db = new EquipmentRentContext())
                {
                    foreach (var order in selectedOrders)
                    {
                        int orderId = order.OrderId;
                        var dbOrder = db.Orders.FirstOrDefault(o => o.OrderId == orderId);
                        if (dbOrder != null)
                        {
                            db.Orders.Remove(dbOrder);
                        }
                    }

                    db.SaveChanges();
                }

                MessageBox.Show("Выбранные заказы успешно удалены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Обновляем таблицу
                LoadOrdersData();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на домашнюю страницу арендодателя
            NavigationService.GoBack();
        }
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный заказ
            var selectedOrder = OrdersDataGrid.SelectedItem as dynamic;

            if (selectedOrder == null)
            {
                MessageBox.Show("Пожалуйста, выберите заказ для печати.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создаем документ для печати
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument document = new FlowDocument
                {
                    PagePadding = new Thickness(50),
                    FontSize = 14,
                    FontFamily = new FontFamily("Segoe UI")
                };

                // Добавляем заголовок
                Paragraph header = new Paragraph(new Bold(new Run("Информация о заказе")))
                {
                    FontSize = 18,
                    TextAlignment = TextAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 20)
                };
                document.Blocks.Add(header);

                // Добавляем информацию о заказе
                document.Blocks.Add(new Paragraph(new Run($"Клиент: {selectedOrder.ClientName}")));
                document.Blocks.Add(new Paragraph(new Run($"Оборудование: {selectedOrder.EquipmentName}")));
                document.Blocks.Add(new Paragraph(new Run($"Начало аренды: {selectedOrder.StartDate:dd.MM.yyyy}")));
                document.Blocks.Add(new Paragraph(new Run($"Конец аренды: {selectedOrder.EndDate:dd.MM.yyyy}")));
                document.Blocks.Add(new Paragraph(new Run($"Итоговая стоимость cтоимость: {selectedOrder.TotalCost:C}")));

                // Печать документа
                IDocumentPaginatorSource idpSource = document;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Печать заказа");
            }
        }
    }
}
