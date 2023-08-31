using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftwareHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*UpdateQuery();*/
            /*UpdateDepartQuery();*/
            /*UpdateData();*/
            UpdateDataQuery();

            //!--------- inner join on simple sql query --------->
            /*try
            {
                string connectionString = "Server=DESKTOP-4L73U46;Database=SoftwareHouseDB; Integrated Security= True"; // Replace with your actual connection string

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT E.EName, P.PName, D.DName" +
                                   " FROM Employee E " +
                                   "JOIN Project P ON E.PID = P.PID " +
                                   "JOIN Department D ON E.DID = D.DID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string employeeName = reader["EName"].ToString();
                                string projectName = reader["PName"].ToString();
                                string departmentName = reader["DName"].ToString();

                                Console.WriteLine($"Employee Name: {employeeName}, Project Name: {projectName}, Department Name: {departmentName}");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //!--------- inner join Order by Project Price ------------>
            /*try
            {
                string connectionString = "Server=DESKTOP-4L73U46;Database=SoftwareHouseDB; Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT E.EName, P.PName,P.PPrice, D.DName" +
                                   " FROM Employee E " +
                                   "JOIN Project P ON E.PID = P.PID " +
                                   "JOIN Department D ON E.DID = D.DID" +
                                   " ORDER BY P.PPrice"; // Adding ORDER BY clause here

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string employeeName = reader["EName"].ToString();
                                string projectName = reader["PName"].ToString();
                                string projectPrice = reader["PPrice"].ToString();
                                string departmentName = reader["DName"].ToString();

                                Console.WriteLine($"Employee Name: {employeeName}, Project Name: {projectName},Project Price: {projectPrice}, Department Name: {departmentName}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //!--------- inner join Group by Department ID ------------>

            /*try
            {
                string connectionString = "Server=DESKTOP-4L73U46;Database=SoftwareHouseDB; Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT D.DID, D.DName, COUNT(E.EName) AS EmployeeCount, COUNT(P.PName) AS ProjectCount" +
                                   " FROM Department D " +
                                   "LEFT JOIN Employee E ON D.DId = E.DId" +
                                   " LEFT JOIN Project P ON D.DId = P.DId" +
                                   " GROUP BY D.DId, D.DName"; // Adding GROUP BY clause here

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                string departmentId = reader["DId"].ToString();
                                string departmentName = reader["DName"].ToString();
                                Console.WriteLine($"Department ID: {departmentId},Department Name: {departmentName}");
                                int employeeCount = Convert.ToInt32(reader["EmployeeCount"]);
                                int projectCount = Convert.ToInt32(reader["ProjectCount"]);

                                Console.WriteLine($" Employee Count: {employeeCount}, Project Count: {projectCount}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/



            /// !----------- Inner Join ----->
            /// !----------- This code bring Employee Name, Department Name and
            /// Every Project related to that department associate with That department employee------>

            /*try
            {
                using(var mc= new SoftwareHouseDBEntities())
                {
                    var query = from e in mc.Employees
                                join d in mc.Departments on e.DId equals d.DId
                                join p in  mc.Projects on d.DId equals p.DId
                                select new
                                {
                                    EName = e.EName,
                                    DName = d.DName,
                                    PName = p.PName
                                };

                    foreach (var result in query)
                    {
                        Console.WriteLine($"Employee Name: {result.EName}, Department Name: {result.DName}, Prjoect Assigned: {result.PName}");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }*/

            // ----- This query brings all Employees and data relevant to that specific employee ------>
            /* try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {
                     var query = from e in mc.Employees
                                 join p in mc.Projects on e.PId equals p.PId
                                 join d in mc.Departments on e.DId equals d.DId

                                 select new
                                 {
                                     EName = e.EName,
                                     DName = d.DName,
                                     PName = p.PName
                                 };

                     foreach (var result in query)
                     {
                         Console.WriteLine($"Employee Name: {result.EName}, Department Name: {result.DName}, Prjoect Assigned: {result.PName}");
                     }

                 }

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.ToString());
             }*/


            //!--------- Order By using Inner join ------------->

            /* try
             {
                 using (var mc = new SoftwareHouseDBEntities())
                 {
                     var query = from e in mc.Employees
                                 join p in mc.Projects on e.PId equals p.PId
                                 join d in mc.Departments on e.DId equals d.DId
                                 orderby p.PId
                                 select new
                                 {
                                     EName = e.EName,
                                     DName = d.DName,
                                     PName = p.PName
                                 };

                     foreach (var result in query)
                     {
                         Console.WriteLine($"Employee Name: {result.EName}, Department Name: {result.DName}, Prjoect Assigned: {result.PName}");
                     }

                 }

             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.ToString());
             }*/

            //!---------- Group By using Inner join ------------->
            //!---------- Shows data First Department name and then on 2nd row all employees working in this department and
            // projects assigned to the eployees in same row ------------->
            // !----- Also a function commented which shows first all emplyees name and then all projects name
            // in the Department group --------->

            /*try
            {
                using (var mc = new SoftwareHouseDBEntities())
                {
                    var query = from e in mc.Employees
                                join p in mc.Projects on e.PId equals p.PId
                                join d in mc.Departments on e.DId equals d.DId
                                group new { e, d, p } by d.DId into grouped
                                select new
                                {
                                    DId = grouped.Key,
                                    Employees = grouped.Select(g => g.e.EName),
                                    Department = grouped.Select(g => g.d.DName),
                                    Projects = grouped.Select(g => g.p.PName)
                                };

                    foreach (var result in query)
                    {
                        
                        Console.WriteLine($"Project ID: {result.DId}");
                        Console.WriteLine($"  Department: {result.Department.FirstOrDefault()}");

                        var employeeProjectPairs = result.Employees.Zip(result.Projects, (employee, project) => new { Employee = employee, Project = project });

                        foreach (var pair in employeeProjectPairs)
                        {
                            Console.WriteLine($"    Employee Name: {pair.Employee}, Project Name: {pair.Project}");
                        }
                        // foreach (var employeeName in result.Employees)
                         //{
                         //    Console.WriteLine($"  Employee Name: {employeeName}");
                         //}

                         //foreach (var projectName in result.Projects)
                         //{
                           //  Console.WriteLine($"  Project Name: {projectName}");
                         //}

                        Console.WriteLine();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //!---------- Left Join Or Left Outer Join ------------->
            /*try
            {
                using (var mc = new SoftwareHouseDBEntities())
                {
                    var query = from e in mc.Employees
                                join p in mc.Projects on e.PId equals p.PId into empProjectGroup
                                from empProject in empProjectGroup.DefaultIfEmpty()
                                select new
                                {
                                    EmployeeName = e.EName,
                                    ProjectName = empProject != null ? empProject.PName : "No Project Assigned"
                                };

                    foreach (var result in query)
                    {
                        Console.WriteLine($"Employee Name: {result.EmployeeName}, Project Name: {result.ProjectName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //!--------- Updating Database adding more columns in Project and Employee Table ----->
            //!---- Left Join Order By  ----->
            /*try
            {
                using (var mc = new SoftwareHouseDBEntities())
                {
                    var query = from e in mc.Employees
                                join p in mc.Projects on e.PId equals p.PId into empProjectGroup
                                from empProject in empProjectGroup.DefaultIfEmpty()
                                orderby empProject.PPrice
                                select new
                                {
                                    EmployeeName = e.EName, 
                                    ProjectName = empProject != null ? empProject.PName : "No Project Assigned",
                                    ProjectPrice = empProject.PPrice,
                                    StartDate = empProject.PSDate,
                                    EndDate = empProject.PEDate
                                };

                    foreach (var result in query)
                    {
                        Console.WriteLine($"Employee Name: {result.EmployeeName},Project Name: {result.ProjectName},Project Price: {result.ProjectPrice},Project Start Date: {result.StartDate},Project End Date: {result.EndDate}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //!---- Left Join Group By Project Type ----->
            /*try
            {
                using (var mc = new SoftwareHouseDBEntities())
                {
                    var query = from e in mc.Employees
                                join p in mc.Projects on e.PId equals p.PId into empProjectGroup
                                from empProject in empProjectGroup.DefaultIfEmpty()
                                let projectType = empProject
                                select new
                                {
                                    EmployeeName = e.EName,
                                    ProjectName = empProject != null ? empProject.PName : "No Project Assigned",
                                    ProjectPrice = empProject.PPrice,
                                    StartDate = empProject.PSDate,
                                    EndDate = empProject.PEDate,
                                    ProjectType = projectType
                                };

                    var groupedQuery = from result in query
                                       group result by result.ProjectType;

                    foreach (var group in groupedQuery)
                    {
                        Console.WriteLine($"Project Type: {group.Key}");

                        foreach (var result in group)
                        {
                            Console.WriteLine($"  Employee Name: {result.EmployeeName}, Project Name: {result.ProjectName}, Project Price: {result.ProjectPrice}, Project Start Date: {result.StartDate}, Project End Date: {result.EndDate}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/









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
        // !------ Created four methods. 3 are private method of getdata , savedata and deletedata,
        // 1 is public where query updates data ----->

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


        //!---------- Using Async method changing multiple columns of a row  -------------->
        /*private static async Task<Project> GetProject()
        {
            Project project = null;
            try
            {
                using(var mc = new SoftwareHouseDBEntities())
                {
                    project = await (mc.Projects.Where(p => p.DId == 3).FirstOrDefaultAsync<Project>());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return project;
        }*/
        /*private static async Task SaveProject(Project proj)
        {
            try
            {
                using(var mc = new SoftwareHouseDBEntities())
                {
                    mc.Entry(proj).State = EntityState.Unchanged;
                    await( mc.SaveChangesAsync());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
        /*public static void UpdateData()
        {
            var query = GetProject();
            query.Wait();
            var project = query.Result;
            Console.WriteLine("Enter your Project Name");
            project.PName = Console.ReadLine();
            Console.WriteLine("Enter your Project Price in Dollars");
            string input = Console.ReadLine();
            
            if (int.TryParse(input, out int price))
            {
                project.PPrice = price;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            Console.WriteLine("Enter your Project Start Date");
            string inputDate = Console.ReadLine();
            if (DateTime.TryParse(inputDate, out DateTime date))
            {
                project.PSDate = date;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            Console.WriteLine("Enter your Project End Date");
            string inputEDate = Console.ReadLine();
            if (DateTime.TryParse(inputEDate, out DateTime date1))
            {
                project.PEDate = date1;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            var savedata = SaveProject(project);
            savedata.Wait();
        }*/



        //!---------- Using Async method changing multiple rows and columns of per row  -------------->

        /*private static async Task<List<Project>> GetProjects()
        {
            List<Project> projects = new List<Project>();
            try
            {
                using(var mc = new SoftwareHouseDBEntities())
                {
                    projects = await (mc.Projects.Where(p => p.DId == 3).ToListAsync());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return projects;
        }*/
        /*private static async Task SaveProject(Project proj)
        {
            try
            {
                using(var mc = new SoftwareHouseDBEntities())
                {
                    mc.Entry(proj).State = EntityState.Modified;
                    await (mc.SaveChangesAsync());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/

        /*public async static void UpdateDataQuery()
        {
            var query = await GetProjects();
            //query.Wait();
            //var projectList = query.Result;
            foreach (var project in query)
            {
                Console.WriteLine($"Updating Project {project.PName} (ID: {project.PId})");
                Console.WriteLine("Update Project Name");
                project.PName = Console.ReadLine();
                Console.WriteLine("Update Project Price");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int price))
                {
                    project.PName = price.ToString();
                }
                else
                {
                    Console.WriteLine("Incorrect values");
                }
                Console.WriteLine("Update Project Start Date");
                string input1 = Console.ReadLine();
                if (DateTime.TryParse(input1, out DateTime date))
                {
                    project.PSDate = date;
                }
                else
                {
                    Console.WriteLine("Invald Values");
                }
                Console.WriteLine("Update Project End Date");
                string input2 = Console.ReadLine();
                if (DateTime.TryParse(input2, out DateTime date2))
                {
                    project.PEDate = date2;
                }
                else
                {
                    Console.WriteLine("Invald Values");
                }
            }
        }*/



    }
}
