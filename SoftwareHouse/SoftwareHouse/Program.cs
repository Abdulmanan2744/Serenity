using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*UpdateQuery();*/
            /*UpdateDepartQuery();*/

         
            //nothing special 
           /* List<Employee> employees = new List<Employee>();
            foreach (var employee in mc.Employees)
            {
                employees.Add(employee);

            }*/

            




            //!-------- DB Entity Entry --------->

            /* try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {
                     //get employee whose EId is 1
                     var employee = mc.Employees.Find(1);

                     //edit Employee name
                     employee.EName = "Edited name";

                     //get DbEntityEntry object for employee entity object
                     var entry = mc.Entry(employee);

                     //get entity information e.g. full name
                     Console.WriteLine("Entity Name: {0}", entry.Entity.GetType().FullName);

                     //get current EntityState
                     Console.WriteLine("Entity State: {0}", entry.State);

                     Console.WriteLine("********Property Values********");

                     foreach (var propertyName in entry.CurrentValues.PropertyNames)
                     {
                         Console.WriteLine("Property Name: {0}", propertyName);

                         //get original value
                         var orgVal = entry.OriginalValues[propertyName];
                         Console.WriteLine("     Original Value: {0}", orgVal);

                         //get current values
                         var curVal = entry.CurrentValues[propertyName];
                         Console.WriteLine("     Current Value: {0}", curVal);
                     }

                     // extra added lines
                     //mc.Employees.Add(employee);
                    // mc.SaveChanges();
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.ToString());
             }*/

            // !------ Created Db First Approach----->
            // !------ Created four tables (Department, Employee, Project, EMployeeProject) ---->

            // !------ Department Table ------------->

            // !------- Inserting multiple values in Department Table ------->
            /* try
             {
                 using(var mc= new SoftwareHouseDBEntities())
                 {
                     string[] depart_Names = { "Management", "Quality Assurance", "Development", "Business Analyst", "Designing" };
                     for(int i=0; i<depart_Names.Length; i++)
                     {
                         var d_name = new Department
                         {
                             DName= depart_Names[i]
                         };
                         mc.Departments.Add(d_name);
                     }
                     mc.SaveChanges();
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }*/


            // !------ Employee Table ------------->

            // !----- Inserting Multiple Data ------>

            /* try
             {
                 using(var mc= new SoftwareHouseDBEntities())
                 {
                     string[] e_name = {"Abdul Manan","Waseem Arsalan","Hassan","Mehboob","Shoaib","Haroon","Ali","Kashif","Nabeel","Shahzad","Toufeeq" };
                     int[] d_id = {3,1,1,2,3,4,5,3,3,1,2 };
                     for(int i=0; i<e_name.Length; i++)
                     {
                         var emp_name = new Employee
                         {
                             EName = e_name[i],
                             DId = d_id[i]
                         };
                         mc.Employees.Add(emp_name);
                     }
                     mc.SaveChanges();
                 }

             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }*/


            // !------ Project Table ------------->

            // !----- Inserting  ------>

            /* try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {
                     string[] p_name = { "Website Development", "Hiring Intern", "Project Documentation", "Website Testing", "Mobile Application Development", "Grab new Project", "Design Web", "Develop Website", "Unity Game", "Documentation Game", "Game Testing" };
                     int[] d_id = { 3, 1, 1, 2, 3, 4, 5, 3, 3, 1, 2 };
                     for (int i = 0; i < p_name.Length; i++)
                     {
                         var prj_name = new Project
                         {
                             PName = p_name[i],
                             DId = d_id[i]
                         };
                         mc.Projects.Add(prj_name);
                     }
                     mc.SaveChanges();
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }*/



        }

        // !------ Asynchronous Queries  ----->
        // !------ Employee Table  ----->
        // !------ Created three methods. 2 are private method of getdata and savedata and
        // 1 is public where query update data ----->

        /* private static async Task<Employee> GetEmployee()
         {
             Employee employee = null;
             try
             {

                 using (var mc = new SoftwareHouseDBEntities())
                 {

                     employee = mc.Employees.First();

                     // Console.WriteLine("Start Get Employee");
                     // employee = await (mc.Employees.Where(s => s.EId == 1).FirstOrDefaultAsync<Employee>());
                     // Console.WriteLine("Finished Employee");

                 }

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             return employee;
         }*/

        /* private static async Task SaveEmployee(Employee editedEmployee)
         {

             try
             {
                  using (var mc = new SoftwareHouseDBEntities())
                  {

                    mc.Entry(editedEmployee).State = EntityState.Modified;
                    int x = await (mc.SaveChangesAsync());

                  }

               //  using (var context = new SoftwareHouseDBEntities())
                 //{
                   //  try
                     //{
                       //  context.Entry(editedEmployee).State = EntityState.Modified;
                         //context.SaveChanges();
                     //}
                     //catch (DbUpdateConcurrencyException ex)
                     //{
                      //   Console.WriteLine("Concurrency Exception Occurred.");
                     //}
                 //}
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         }*/

        /*  public static void UpdateQuery()
          {
              try
              {
                  var query = GetEmployee();
                  query.Wait();
                  var employee = query.Result;
                  Console.Write("Enter New Employee Name:");
                  employee.EName = Console.ReadLine();
                  // employee.EName = "Mani";
                  var numofsavedEmplyee = SaveEmployee(employee);
                  numofsavedEmplyee.Wait();

              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }
          }*/



        // !------ Employee Table  ----->
        // !------ Created three methods. 2 are private method of getdata and savedata and
        // 1 is public where query update data ----->

        /*private static async Task<Department> GetDepartment()
        {
            Department department = null;
            try
            {
                using(var mc= new SoftwareHouseDBEntities())
                {
                    Console.WriteLine("Get Department Data");
                    department = await(mc.Departments.Where(s=>s.DId==5)).FirstOrDefaultAsync<Department>();
                    Console.WriteLine("Department Data successfully retrieved");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return department;

        }*/

        /* private static async Task SaveDepartment(Department depart)
         {
             try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {

                     mc.Entry(depart).State = EntityState.Modified;
                     int x = await (mc.SaveChangesAsync());
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         }*/

        /* private static async Task DeleteDepartment(Department depart)
         {
             try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {
                     mc.Entry(depart).State = EntityState.Deleted;
                     int x = await (mc.SaveChangesAsync());
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         }*/

        /* public static async void UpdateDepartQuery()
         {
             var query = GetDepartment();
             query.Wait();
             var department = query.Result;

             // !-------- Update Department Name Code ------->

             department.DName = "UI/UX Designer";
             var savedDepart = SaveDepartment(department);
             savedDepart.Wait();

             // !-------- Delete Department Name Code ------->

             //var department = await GetDepartment();
            // var deletedDepart = DeleteDepartment(department);
            // deletedDepart.Wait();

         }*/




    }
}
