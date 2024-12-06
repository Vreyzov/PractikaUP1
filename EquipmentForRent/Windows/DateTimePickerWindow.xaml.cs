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

namespace EquipmentForRent
{
    /// <summary>
    /// Логика взаимодействия для DateTimePickerWindow.xaml
    /// </summary>
    public partial class DateTimePickerWindow : Window
    {
        public DateTime? SelectedDate { get; set; }

        public DateTimePickerWindow(DateTime? initialDate)
        {
            InitializeComponent();
            SelectedDate = initialDate;
            EndDatePicker.SelectedDate = initialDate;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранную дату из DatePicker
            SelectedDate = EndDatePicker.SelectedDate;
            DialogResult = true; // Закрытие окна с подтверждением изменений
        }

        // Обработчик кнопки "Cancel" - отменяем изменения и закрываем окно
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Закрытие окна без изменений
        }
    }
}
