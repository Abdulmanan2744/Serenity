using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace ContosoUniversity.DAL
{
    public class DBNew1
    {
        public static void Test()
        {
          




           /* string connectionString = "Server=DESKTOP-4L73U46;Database=BookListRazor; Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Book(Name, Author, ISBN) VALUES ('dotnet', 'Mani', 'mani2744675')";
                    string query1 = "DELETE FROM Book WHERE Id IN ('1008', '1009', '1010', '1011')";
                    string query2 = "Delete From Book WHERE Id='1007'";

                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                        }
                        *//*command.ExecuteNonQuery();*//*
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occured" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }



            }*/


        }
    }
}

