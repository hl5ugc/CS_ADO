﻿using Microsoft.Data.SqlClient;
using System.Windows;
using WpfApp.Models;

namespace WpfApp.AppointmentTypes
{
    /// <summary>
    /// AppointmentTypesMainForm.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AppointmentTypesMainForm : Window
    {
        private readonly List<AppointmentType> _appointmentTypes; // Model Class AppointmentType 의 LIST
        // [1] Database Name or Database Source : Server
        // [2] 신임장  : 사용자 이름과 비밀번호
        // [3] 선택적 매개변수
        private readonly string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB; Initial catalog=AppointDB; Integrated Security = True;";

        public AppointmentTypesMainForm()
        {
            InitializeComponent();
            _appointmentTypes = new List<AppointmentType>();    // 초기화
            AppointmentTypesListView.ItemsSource = _appointmentTypes;
            LoadData();
        }
        // 데이터베이스에서 데이터 선택
        // 데이터베이스에 데이터 삽입
        // 데이터베이스에 데이터 업데이트
        // 데이터베이스에서 데이터 삭제 
        private void LoadData()
        {
            _appointmentTypes.Clear();
            // Read Data table 
            // ADO.NET을 이용하여 데이타 조회
            // Table -> Model classs -> ListView -> ListView.Items.Refresh
            //
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // SELECT : 데이터베이스에서 데이터 선택
                var command = new SqlCommand("SELECT Id, AppointmentTypeName, IsActive FROM AppointmentsType", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = (int)reader["Id"];
                        var name = (string)reader["AppointmentTypeName"];
                        var isActive = (bool)reader["IsActive"];

                        var appointmentType = new AppointmentType
                        {
                            Id = id,
                            AppointmentTypeName = name,
                            IsActive = isActive
                        };
                        _appointmentTypes.Add(appointmentType);
                    }
                }
                //
                AppointmentTypesListView.Items.Refresh();

            }
        }
        //
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
            var editWindow = new EditAppintmentTypeWindow("", false);
            editWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete this appointment type ?",
                "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
