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

namespace WpfApp.AppointmentTypes
{
    /// <summary>
    /// AppointmentTypesMainForm.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AppointmentTypesMainForm : Window
    {
        public AppointmentTypesMainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addwindow = new AddAppintmentTypeWindow();
            if (addwindow.ShowDialog() == true)
            {
                MessageBox.Show(addwindow.AppointmentTypeName); // add 입력 받은 걸 부모에게 전달
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditAppintmentTypeWindow();
            editWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete this appointment type ?", 
                "Delete",MessageBoxButton.YesNo,MessageBoxImage.Question);
        }
    }
}
