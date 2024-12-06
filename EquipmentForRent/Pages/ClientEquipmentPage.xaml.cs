using EquipmentForRent.Models;
using EquipmentForRent.Windows;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ClientEquipmentPage.xaml
    /// </summary>
    public partial class ClientEquipmentPage : Page
    {
        private int _clientId;

        public ClientEquipmentPage(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            LoadEquipment();
            
        }

        private void LoadEquipment()
        {
            using (var context = new EquipmentRentContext())
            {
                var equipmentList = context.Equipment
                                           .Include(e => e.Lessor) // Включаем данные о арендодателе
                                           .ToList();
                EquipmentDataGrid.ItemsSource = equipmentList;
            }
        }

        // Обработчик для оформления заказа
        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentDataGrid.SelectedItem is Equipment selectedEquipment)
            {
                var newOrderWindow = new NewOrderWindow(
                    _clientId,
                    selectedEquipment.EquipmentId,
                    selectedEquipment,
                    selectedEquipment.LessorId
                );
                newOrderWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите оборудование для оформления заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Обработчик для возврата на главную страницу
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientHomePage(_clientId));  // Навигация на главную страницу клиента
        }

    }
}
