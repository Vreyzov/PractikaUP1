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
    /// Логика взаимодействия для LessorHomePage.xaml
    /// </summary>
    public partial class LessorHomePage : Page
    {
        private Lessor _loggedLessor;

        public LessorHomePage(Lessor loggedLessor)
        {
            InitializeComponent();
            _loggedLessor = loggedLessor;
            WelcomeText.Text = $"Здравствуйте! {_loggedLessor.FirstName} {_loggedLessor.LastName}";
        }
        private void ViewMyEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessorEquipmentPage(_loggedLessor.LessorId));
        }

        private void ViewMyOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LessorOrdersPage(_loggedLessor.LessorId));
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Возвращаемся на страницу авторизации
            NavigationService.Navigate(new LoginPage());
        }
    }
}
