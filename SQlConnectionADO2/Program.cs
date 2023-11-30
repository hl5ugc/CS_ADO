using System;
using System.Collections.Generic;
using System.Data.SqlClient;        // ADO.NET NameSpace
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;     // 참조 추가  ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
using System.Xml.Linq;

namespace SQlConnectionADO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Program.ConnectionSerch();
            Program.Connection();
            Console.ReadLine();
        }

        static void ConnectionSerch()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    //Console.Write("Id : "); int Id = Convert.ToInt32(Console.ReadLine());
                    //Console.Write("Id : "); string Id = Console.ReadLine();
                    //string query = "delete from Components where Id = @Id";
                    string query = "select Count(Price) from Components";
                    //string query = "select Min(Price) from Components";
                    //string query = "select Max(Price) from Components";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        //Double a = (Double)cmd.ExecuteScalar();
                        var a = (int)cmd.ExecuteScalar();
                        Console.WriteLine($"Max Price {a}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
        static void ConnectionDelete()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    //Console.Write("Id : "); int Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Id : "); string Id = Console.ReadLine();

                    string query = "delete from Components where Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    //
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Console.WriteLine("Data has been Delete Sucessfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Data has been Delete Fail!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
        static void ConnectionUpdate()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    Console.Write("Name : "); string Name = Console.ReadLine();
                    Console.Write("MFR : "); string Mfr = Console.ReadLine();
                    Console.Write("Price : "); float Price = float.Parse(Console.ReadLine());

                    //string query = "insert into Components values(@Name,@Mfr,@Price)";
                    string query = "update Components set Name = @Name,Mfr = @Mfr,Price = @Price)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Mfr", Mfr);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    //
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Console.WriteLine("Data has been Update Sucessfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Data has been Inseted Fail!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
        //

        static void ConnectionInsert()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    Console.Write("Name : ");  string Name = Console.ReadLine();
                    Console.Write("MFR : ");   string Mfr = Console.ReadLine();
                    Console.Write("Price : "); float Price = float.Parse(Console.ReadLine());

                    string query = "insert into Components values(@Name,@Mfr,@Price)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Mfr", Mfr);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    //
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        int a = cmd.ExecuteNonQuery();
                        if (a > 0)
                        {
                            Console.WriteLine("Data has been Inseted Sucessfully!!");
                        }
                        else
                        {
                            Console.WriteLine("Data has been Inseted Fail!!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }

            }
        }
        //
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;  //
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    string query = "select * from Components";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connnecton has been Created Sucessfully!!");
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Console.WriteLine($"Name = {dr[1]} ,MFR = {dr[2]},Price = {dr[3]}  ");
                        } 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"DB! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
