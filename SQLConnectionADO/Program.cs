


using Microsoft.Data.SqlClient;
using System.Data;

namespace SQLConnectionADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }

        static void Connection()
        {
            string cs = "Data Source =SAMJIN-DESKTOP; Initial Catalog=SJElectronicParts;" +
                "Integrated Security = true;  TrustServerCertificate=true";
            // [1]
            //SqlConnection con = new SqlConnection(cs);
            //try
            //{
            //    con.Open();

            //    if (con.State == ConnectionState.Open)
            //    {
            //        Console.WriteLine("Connnecton has been Created Sucessfully!!");
            //    }
            //}
            //catch  (Exception ex) 
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally { con.Close(); }

            // [2]
            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    con.Open();
            //    if (con.State == ConnectionState.Open)
            //    {
            //        Console.WriteLine("Connnecton has been Created Sucessfully!!");
            //    }
            //}
            //[3]
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connnecton has been Created Sucessfully!!");
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"File! {ex.Message}");
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}