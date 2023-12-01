using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;


namespace SqlDataAdapterDemo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //
            SqlDataAdapterDemo();

            Console.WriteLine("Enter Id of Any Appointment :");
            int id = Convert.ToInt32(Console.ReadLine());

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            // [1]
            //SqlConnection conn = new SqlConnection(cs);
            //SqlDataAdapter sda = new SqlDataAdapter("Select * From AppointmentsType",conn);
            //DataSet ds = new DataSet();
            //sda.Fill(ds);

            // [2] Id input id read using StoreProcedures(AppointmentsTypes_GetById)!!
            //SqlConnection conn = new SqlConnection(cs);
            //SqlDataAdapter sda = new SqlDataAdapter();
            //sda.SelectCommand = new SqlCommand("AppointmentsTypes_GetById", conn);
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sda.SelectCommand.Parameters.AddWithValue("@Id", id);

            // [3]All read using StoreProcedures! (AppointmentsTypes_GetAll)!
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = new SqlCommand("AppointmentsTypes_GetAll", conn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            //
            DataSet ds = new DataSet();
            sda.Fill(ds);

            foreach (DataRow row in ds.Tables[0].Rows) // 
            {
                Console.WriteLine($"{row[0]},{row[1]},{row[2]}");
            }
            Console.WriteLine("--------------------------------------");
           // [?]
           //DataTable dt = new DataTable();
           // sda.Fill(dt);

           // foreach (DataRow row in dt.Rows) // 
           // {
           //     Console.WriteLine($"{row[0]},{row[1]},{row[2]}");
           // }
        }
        // SELECT Id, AppointmentTypeName FROM AppointmentsType
        static void SqlDataAdapterDemo()
        {
            // Assumes that customerConnection is a valid SqlConnection object.  
            // Assumes that orderConnection is a valid OleDbConnection object.  
            //SqlDataAdapter custAdapter = new SqlDataAdapter(
            //  "SELECT * FROM dbo.Customers", customerConnection);
            //OleDbDataAdapter ordAdapter = new OleDbDataAdapter(
            //  "SELECT * FROM Orders", orderConnection);

            //DataSet customerOrders = new DataSet();

            //custAdapter.Fill(customerOrders, "Customers");
            //ordAdapter.Fill(customerOrders, "Orders");

            //DataRelation relation = customerOrders.Relations.Add("CustOrders",
            //  customerOrders.Tables["Customers"].Columns["CustomerID"],
            //  customerOrders.Tables["Orders"].Columns["CustomerID"]);

            //foreach (DataRow pRow in customerOrders.Tables["Customers"].Rows)
            //{
            //    Console.WriteLine(pRow["CustomerID"]);
            //    foreach (DataRow cRow in pRow.GetChildRows(relation))
            //        Console.WriteLine("\t" + cRow["OrderID"]);
            //}

 

        }
    }
}
