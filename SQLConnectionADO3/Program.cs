using System;
using System.Collections.Generic;
using System.Data.SqlClient;        // ADO.NET NameSpace
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;     // 참조 추가  ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
 

namespace SQLConnectionADO3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Components;" + "select * from MFR_CODE;";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                double dPrice = 0;
                while (dr.Read())
                {
                    dPrice += dr.GetDouble(3);
                    Console.WriteLine(dr.GetName(2));
                    //Console.WriteLine(dr.FieldCount);
                    //Console.WriteLine(dr.HasRows);
                    //Console.WriteLine($"ID={dr["Id"]} , Name = {dr["Name"]} ,MFR = {dr["Mfr"]},Price = {dr["Price"]}");
                    Console.WriteLine($"ID={dr[0]} , Name = {dr[1]} ,MFR = {dr[2]},Price = {dr[3]}");
                }
                Console.WriteLine($"Total Price ={dPrice}");
                Console.WriteLine("-----------------------------------------------------------");
                //
                dr.NextResult();
                while (dr.Read())
                {
                   Console.WriteLine($"{dr[0]} , {dr[1]} , {dr[2]}");
                }

                dr.Close();
                con.Close();
            }
        }
        //

    }
}
