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
using Microsoft.Data.SqlClient;
using EquipmentForRent.Windows;

namespace EquipmentForRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для LessorEquipmentPage.xaml
    /// </summary>
    public partial class LessorEquipmentPage : Page
    {

        public LessorEquipmentPage(int lessorId)
        {
            InitializeComponent();
            LoadEquipmentData();
        }
        public void LoadEquipmentData()
        {
            string connectionString = "Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;"; // Укажите строку подключения к базе данных

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EquipmentID, Name, PricePerDay FROM Equipment WHERE LessorID = @LessorID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LessorID", 1); // Передайте ID арендатора

                SqlDataReader reader = command.ExecuteReader();

                var equipmentList = new System.Collections.Generic.List<Equipment>();
                while (reader.Read())
                {
                    equipmentList.Add(new Equipment
                    {
                        EquipmentId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        PricePerDay = reader.GetDecimal(2)
                    });
                }

                EquipmentDataGrid.ItemsSource = equipmentList;
            }
        }

        // Обработчик кнопки "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на предыдущую страницу (например, LessorMainPage)
            NavigationService.GoBack();
        }

        // Обработчик кнопки "Добавить"
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу добавления нового оборудования (NewEquipmentWindow)
            NewEquipmentWindow newEquipmentWindow = new NewEquipmentWindow(this); // Передаем текущую страницу как parentPage
            newEquipmentWindow.ShowDialog(); // Открыть в диалоговом режиме
        }

        // Обработчик кнопки "Редактировать"
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что элемент выбран
            var selectedEquipment = EquipmentDataGrid.SelectedItem as Equipment;
            if (selectedEquipment == null)
            {
                MessageBox.Show("Пожалуйста, выберите оборудование для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Открываем окно редактирования с передачей выбранного оборудования
            EditEquipmentWindow editEquipmentWindow = new EditEquipmentWindow(selectedEquipment);
            if (editEquipmentWindow.ShowDialog() == true)
            {
                // Если редактирование было успешно завершено, обновляем данные в таблице
                LoadEquipmentData();
            }
        }

        // Обработчик кнопки "Удалить выбранное"
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedEquipment = EquipmentDataGrid.SelectedItem as Equipment;
            if (selectedEquipment != null)
            {
                // Подтверждение удаления
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить это оборудование?", "Удалить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Удаление из базы данных
                    string connectionString = "Server=PC;Database=EquipmentRent;TrustServerCertificate=True;Trusted_Connection=True;"; // Укажите строку подключения
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Equipment WHERE EquipmentID = @EquipmentID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EquipmentID", selectedEquipment.EquipmentId);
                        command.ExecuteNonQuery();
                    }

                    // Обновить список оборудования
                    LoadEquipmentData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите оборудование для удаления.");
            }
        }
    }
}
