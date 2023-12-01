using Microsoft.Data.SqlClient;
using System.Windows;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connString =
            "Data Source=(localdb)\\MSSQLLocalDB; Initial catalog=AppointDB; Integrated Security = True;";

        public MainWindow()
        {
            InitializeComponent();
        }
        // SqlDataReader를 사용하여 데이터에 액세스
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            // Nuget : Microsoft.Data.SqlClient
            using (var sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                // [1] Define Viaiables
                SqlCommand sqlCmd;
                SqlDataReader sqlReader;
                String sql, output = "";
                // [2] Define SQL Statement
                sql = "Select * from AppointmentsType";
                // [3] The Command Statement
                sqlCmd = new SqlCommand(sql, sqlConn);
                // [4] Define the data reader from database Table (AppointmentsType)
                sqlReader = sqlCmd.ExecuteReader();
                // [5] Get the table values
                while (sqlReader.Read())
                {
                    output += $"Id:{sqlReader[0]},Name:{sqlReader[1]},IsActive:{sqlReader[2]},Date:{sqlReader[3]} ";
                    output += Environment.NewLine;
                }
                sqlReader.Close();
                sqlCmd.Dispose();
                sqlConn.Close();
                MessageBox.Show(output);
                // close()
            }
        }
        // C# 데이터베이스에 삽입
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                // [1] Define Viaiables
                SqlCommand sqlCmd;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                String sql = "";
                // [2] Define SQL Insert Statement
                //sql = "Insert Into AppointmentsType (AppointmentTypeName,IsActive) VALUES('Test3',True)";
                sql = "Insert Into AppointmentsType (AppointmentTypeName) VALUES('Test3')";
                // [3] The SQL Command Statement
                sqlCmd = new SqlCommand(sql, sqlConn);
                // [4] Define  Associate the insert command
                sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConn);
                // 5] Define Data insert in DB Table
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();
                sqlCmd.Dispose();
                sqlConn.Close();
                // close()
            }
        }
        // C# 데이터베이스에  수정
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                // [1] Define Viaiables
                SqlCommand sqlCmd;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                String sql = "";
                // [2] Define SQL Insert Statement
                //sql = "Insert Into AppointmentsType (AppointmentTypeName,IsActive) VALUES('Test3',True)";
                sql = "Update AppointmentsType set AppointmentTypeName = 'Kang Hag Seong' " +
                      "where Id=1";
                // [3] The SQL Command Statement
                sqlCmd = new SqlCommand(sql, sqlConn);
                // [4] Define  Associate the insert command
                sqlDataAdapter.UpdateCommand = new SqlCommand(sql, sqlConn);
                // 5] Define Data insert in DB Table
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlCmd.Dispose();
                sqlConn.Close();
                // close()
            }
        }
        // 기록 삭제
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you Sure ?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (var sqlConn = new SqlConnection(connString))
                {
                    sqlConn.Open();
                    // [1] Define Viaiables
                    SqlCommand sqlCmd;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    String sql = "";
                    // [2] Define SQL Delete Statement
                    //sql = "Insert Into AppointmentsType (AppointmentTypeName,IsActive) VALUES('Test3',True)";
                    sql = "Delete AppointmentsType  where Id = 1";
 
                    // [3] The SQL Command Statement
                    sqlCmd = new SqlCommand(sql, sqlConn);
                    // [4] Define  Associate the insert command
                    sqlDataAdapter.DeleteCommand = new SqlCommand(sql, sqlConn);
                    // 5] Define Data insert in DB Table
                    sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                    sqlCmd.Dispose();
                    sqlConn.Close();
                    // close()
                }
            }
        }
    }
}