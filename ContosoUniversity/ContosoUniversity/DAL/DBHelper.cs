using System;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Dynamic;

namespace ContosoUniversity.DAL
{
    public class DBHelper
    {
         // code work creating json files
        static public void getnode()
        {
            string connectionString = "Server=192.168.10.176;Database=SBODemoAU;User Id=sa; Password=P@ssw0rd;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT CardCode,CardName, CardType, Address FROM OCRD"; // Replace YourTableName with the actual table name

                    List<ExpandoObject> dynamicModels = new List<ExpandoObject>();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dynamic dynamicModel = new ExpandoObject();
                                var model = (IDictionary<string, object>)dynamicModel;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string columnName = reader.GetName(i);
                                    object columnValue = reader[i];

                                    model[columnName] = columnValue;
                                }

                                dynamicModels.Add(dynamicModel);
                            }
                        }
                    }

                    // Convert dynamic models to JSON
                    string json = JsonConvert.SerializeObject(dynamicModels);
                    var Columns = ((IDictionary<string, object>)dynamicModels.FirstOrDefault()).Keys.ToList();
                    List<dynamic> dynamicList = dynamicModels.Cast<dynamic>().ToList();
                    DynamicData data = new DynamicData();
                    data.Columns = Columns;
                    data.Rows = dynamicList;
                    // Print the JSON
                    var DataJson = JsonConvert.SerializeObject(data);
                    Console.WriteLine(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
    public class DynamicData
    {
        public List<string> Columns { get; set; }
        public List<dynamic> Rows { get; set; }
    }

}



