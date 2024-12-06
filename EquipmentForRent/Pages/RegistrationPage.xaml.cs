using EquipmentForRent.Models;
using Microsoft.Data.SqlClient;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Собираем данные
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string passport = PassportTextBox.Text;

            if (ClientRadioButton.IsChecked == true)
            {
                // Регистрация клиента
                RegisterClient(firstName, lastName, phone, email, login, password);
            }
            else if (LessorRadioButton.IsChecked == true)
            {
                // Регистрация арендодателя
                RegisterLessor(firstName, lastName, phone, email, login, password, passport);
            }
        }

        private void RegisterClient(string firstName, string lastName, string phone, string email, string login, string password)
        {
            // Добавление в таблицу Client
            using (SqlConnection connection = new SqlConnection("Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO Client (FirstName, LastName, Phone, Email, Login, Password) VALUES (@FirstName, @LastName, @Phone, @Email, @Login, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RegisterLessor(string firstName, string lastName, string phone, string email, string login, string password, string passport)
        {
            // Добавление в таблицу Lessor
            using (SqlConnection connection = new SqlConnection("Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO Lessor (FirstName, LastName, Phone, Email, Passport, Login, Password) VALUES (@FirstName, @LastName, @Phone, @Email, @Passport, @Login, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Passport", passport);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackRegistration_ButtonClick(object sender, RoutedEventArgs e)
        {
                // Возвращаемся на страницу авторизации
                NavigationService.Navigate(new LoginPage()); 
        }
    }
}
