using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Reflection;

namespace ContosoUniversity.DAL
{
    public class DBNew
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";

            // Method to retrieve column names from the table
            static List<string> GetColumnsFromTable(string connectionString, string tableName)
            {
                List<string> columnNames = new List<string>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DataTable schema = connection.GetSchema("Columns", new string[] { null, null, tableName, null });

                    foreach (DataRow row in schema.Rows)
                    {
                        columnNames.Add(row["COLUMN_NAME"].ToString());
                    }
                }

                return columnNames;
            }
            // Step 1: Get the list of column names from the table
            List<string> columnsFromTable = GetColumnsFromTable(connectionString, "your_table_name");
         /*   Dictionary<string, Type> columnDataTypes = new Dictionary<string, Type>
            {
                { "column1", typeof(double) },
                { "column2", typeof(int) },
                { "column3", typeof(string) }

            };*/

            // Simulate user's requested columns (replace this with user input)
            List<string> userRequestedColumns = new List<string> { "column1", "column3" };
            Type dataModel = cdataModel(userRequestedColumns);
            List<object> dynamicModelInstances = pushData(dataModel);
            string json = JsonConvert.SerializeObject(dataModel);


            static Type cdataModel(List<string> columns)
            {
                // Create a dynamic assembly and module
                var assemblyName = new AssemblyName("DynamicModelAssembly");
                var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                var moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModelModule");

                // Create a dynamic type with properties based on user requested columns
                var typeBuilder = moduleBuilder.DefineType("DynamicModel", TypeAttributes.Public);

                foreach (var col in columns)
                {
                    var propertyBuilder = typeBuilder.DefineProperty(col, PropertyAttributes.HasDefault, typeof(object), null);
                    var fieldBuilder = typeBuilder.DefineField($"_{col.ToLower()}", typeof(object), FieldAttributes.Private);

                    // Create the getter method
                    var getterMethodBuilder = typeBuilder.DefineMethod($"get_{col}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, typeof(object), Type.EmptyTypes);
                    var ilGenGetter = getterMethodBuilder.GetILGenerator();
                    ilGenGetter.Emit(OpCodes.Ldarg_0);
                    ilGenGetter.Emit(OpCodes.Ldfld, fieldBuilder);
                    ilGenGetter.Emit(OpCodes.Ret);

                    // Create the setter method
                    var setterMethodBuilder = typeBuilder.DefineMethod($"set_{col}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { typeof(object) });
                    var ilGenSetter = setterMethodBuilder.GetILGenerator();
                    ilGenSetter.Emit(OpCodes.Ldarg_0);
                    ilGenSetter.Emit(OpCodes.Ldarg_1);
                    ilGenSetter.Emit(OpCodes.Stfld, fieldBuilder);
                    ilGenSetter.Emit(OpCodes.Ret);

                    // Associate getter and setter methods with the property
                    propertyBuilder.SetGetMethod(getterMethodBuilder);
                    propertyBuilder.SetSetMethod(setterMethodBuilder);
                }

                // Create and return the dynamic type
                return typeBuilder.CreateType();

            }
            static List<object> pushData(Type dataModel)
            {
                // Simulate loading data (replace with actual data loading)
                List<Dictionary<string, object>> data = LoadData();  // Implement LoadData() method

                List<object> instances = new List<object>();
                foreach (var rowData in data)
                {
                    var instance = Activator.CreateInstance(dataModel);
                    foreach (var kvp in rowData)
                    {
                        dataModel.GetProperty(kvp.Key)?.SetValue(instance, kvp.Value);
                    }
                    instances.Add(instance);
                }
                return instances;
            }
            static List<Dictionary<string, object>> LoadData()
            {
                // Replace this with your actual data loading logic
                // Return a list of dictionaries where each dictionary represents a row
                throw new NotImplementedException();
            }

            /* foreach (var col in userRequestedColumns)
             {
                 dynamicModel[col] = Activator.CreateInstance(userRequestedColumns.IndexOf(col));
             }*/

            // Convert dynamic model to JSON
            //string jsonModel = JsonConvert.SerializeObject(dynamicModel);

            /*Console.WriteLine(jsonModel);*/
        }

      
    }
}
   
