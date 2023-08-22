using System;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Newtonsoft.Json;

namespace ContosoUniversity.DAL
{
    public class DBHelper
    {



        static void Main(string[] args)
        {
            string connectionString = "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT cdr1, cdr2 FROM YourTableName"; // Replace YourTableName with the actual table name

                    List<string> cdr1List = new List<string>();
                    List<string> cdr2List = new List<string>();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cdr1Value = reader["cdr1"].ToString();


                                cdr1List.Add(cdr1Value);

                            }
                        }
                    }

                    // Convert lists to JSON
                    string Json = JsonConvert.SerializeObject(cdr1List);


                    // Print the JSON
                    /* Console.WriteLine("cdr1 JSON:");
                     Console.WriteLine(cdr1Json);

                     Console.WriteLine("\ncdr2 JSON:");
                     Console.WriteLine(cdr2Json);*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
       /* static void Main(string[] args)
        {
            string connectionString = "Your_Connection_String"; // Replace with your actual connection string
            string tableName = "Your_Table_Name"; // Replace with your actual table name

            string columnName = "Your_Column_Name"; // Replace with the desired column name

            string dataType = GetColumnDataType(connectionString, tableName, columnName);

            if (!string.IsNullOrEmpty(dataType))
            {
                Console.WriteLine($"Data Type of '{columnName}': {dataType}");
            }
            else
            {
                Console.WriteLine($"Column '{columnName}' not found.");
            }
        }

        static string GetColumnDataType(string connectionString, string tableName, string columnName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable schemaTable = connection.GetSchema("Columns", new string[] { null, null, tableName, columnName });

                if (schemaTable.Rows.Count > 0)
                {
                    DataRow row = schemaTable.Rows[0];
                    return row["DATA_TYPE"].ToString();
                }
            }

            return null;
        }*/
    }
}



