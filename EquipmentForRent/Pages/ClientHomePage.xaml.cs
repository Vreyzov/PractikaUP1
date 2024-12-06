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
    public partial class ClientHomePage : Page
    {
        private Client _loggedClient;

        // Конструктор, принимающий объект Client
        public ClientHomePage(Client loggedClient)
        {
            InitializeComponent();
            _loggedClient = loggedClient;
            WelcomeText.Text = $"Здравствуйте! {_loggedClient.FirstName} {_loggedClient.LastName}";
        }

        // Конструктор, принимающий clientId (в случае, если нужно создать клиента из ID)
        public ClientHomePage(int clientId)
        {
            InitializeComponent();

            using (var context = new EquipmentRentContext())
            {
                _loggedClient = context.Clients.FirstOrDefault(c => c.ClientId == clientId);
                if (_loggedClient != null)
                {
                    WelcomeText.Text = $"Здравствуйте! {_loggedClient.FirstName} {_loggedClient.LastName}";
                }
                else
                {
                    MessageBox.Show("Клиент не найден!");
                }
            }
        }

        // Обработчик для кнопки просмотра оборудования
        private void ViewEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем clientId в ClientEquipmentPage
            NavigationService.Navigate(new ClientEquipmentPage(_loggedClient.ClientId));
        }

        // Обработчик для кнопки просмотра заказов
        private void ViewMyOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаем clientId в ClientOrdersPage
            NavigationService.Navigate(new ClientsOrdersPage(_loggedClient.ClientId));
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Возвращаемся на страницу авторизации
            NavigationService.Navigate(new LoginPage());
        }
    }
}
