using System.Windows;

namespace WpfApp.AppointmentTypes
{
    /// <summary>
    /// EditAppintmentTypeWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditAppintmentTypeWindow : Window
    {
        public string AppointmentTypeName { get; set; }
        public new bool IsActive { get; private set; }

        public EditAppintmentTypeWindow(string appointmentTypeName, bool IsActive)
        {
            InitializeComponent();
            this.AppointmentTypeName = appointmentTypeName;
            this.IsActive = IsActive;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentTypeName = AppointTypeNameTextBox.Text;
            IsActive = (IsActiveCheckBox.IsChecked == true);
            DialogResult = true;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
