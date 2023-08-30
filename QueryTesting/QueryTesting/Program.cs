using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueryTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  !--------- Find Student in the Table ------------->
            /*  try 
              {
                  var mc = new SchoolDBEntities();
                  var student = mc.Students.Find(2);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }*/

            // !------- Fetch data in a list working ---------->

            /*  try
              {
                  using(var mc= new SchoolDBEntities())
                  {
                      var studentList = mc.Students.Where<Student>(a=>a.Name=="Mani").ToList();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }*/

            ///!------------ Group By --- Fetching data but not correctly ---------->
            /*   try
               {
                   using(var mc= new SchoolDBEntities())
                   {
                       var students = mc.Students.GroupBy(s => s.STId);

                       foreach (var groupItem in students)
                       {
                           Console.WriteLine(groupItem.Key);

                           foreach (var stud in groupItem)
                           {
                               Console.WriteLine(stud.SId);
                           }
                           Console.WriteLine(groupItem);
                       }
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex);
               }*/

            //-------- Order By and Order by descending same work on both ---------->

            /*  try
              {
                  using(var mc= new SchoolDBEntities())
                  {
                      var student=mc.Students.OrderBy(a=>a.Name).ToList();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex);
              }*/

            /*   try
               {
                   using(var mc=new SchoolDBEntities())
                   {
                       var student= mc.Students.OrderByDescending(a=>a.Name).ToList();
                   }
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex);
               }*/

            //!------------- Anonymous Object --------------->

            /*  try
              {
                  using (var mc = new SchoolDBEntities())
                  {
                      var student = mc.Students.Where<Student>
                      (a => a.STId==1).Select(a=> new {
                          Id = a.SId,
                          Name = a.Name
                      });
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex);
              }*/

            //  !------------ Working  Removing from Table --------------->

            /*  using (var mc = new SchoolDBEntities())
              {
                  var std = mc.Students.FirstOrDefault<Student>();
                  mc.Students.Remove(std);
                  mc.SaveChanges();
              }*/

            //!------- Eager Loading --------->

            //!------- Eager Loading  using Include --------->
            // in this it will show standard name along with student
            // name without writing extra query

            /*   try
               {
                   using (var mc = new SchoolDBEntities())
                   {
                       var stud1 = mc.Students
                                      .Include("Standard")
                                      .Where(s => s.Name == "Mani")
                                      .ToList();
                       foreach (var student in stud1)
                       {
                           Console.WriteLine($"Name: {student.Name}, Standard: {student.Standard?.Name}");
                       }



                      /* var stud1 = (from student in mc.Students
                                        where student.Name == "Mani"
                                        select student)
                             .Include(s => s.Standard)
                              .ToList();
                       foreach (var student in stud1)
                       {
                           Console.WriteLine($"Name: {student.Name}, Standard: {student.Standard?.Name}");
                       }


                   }
               }
               catch(Exception ex)
               {
                   Console.WriteLine(ex.ToString());
               }*/

            /* try
             {
                 using (var mc = new SchoolDBEntities())
                 {
                     var stud1 = mc.Students
                                    .Include(s => s.Standard.Teachers)
                                    .Where(s => s.Name == "Mani")
                                    .ToList();
                     foreach (var student in stud1)
                     {
                         Console.WriteLine($"Name: {student.Name}, Standard: {student.Standard?.Name} , Teacher: {student.Standard.Teachers}");
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/

            //!----------- Explicit Loading  ------------>

            /*  try
              {
                  using (var mc = new SchoolDBEntities())
                  {
                      var stud = mc.Students.Where(a => a.Name == "Mehboob").FirstOrDefault();
                      mc.Entry(stud).Collection(a => a.Courses).Load();
                      mc.Entry(stud).Reference(a => a.Standard).Load();
                      Console.WriteLine($"Name: {stud.Name}, Standard:{stud.Standard?.Name}");
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }*/

            /*     try
            {
                using(var mc=new SchoolDBEntities())
                {
                    var stud = mc.Students.Where(a => a.Name == "Shoaib").FirstOrDefault();
                    mc.Entry(stud).Collection(a => a.Courses).Query().Where(s => s.Name == "Math").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/

            //!--------- Attach Disconnected Entities -------------->
            /*
                        try
                        {
                            var student = new Student()
                            {
                                //Root entity (empty key)
                                Name = "Bill",
                                STId = 8,
                                Standard = new Standard()   //Child entity (with key value)
                                {
                                    STId = 8,
                                    Name = "Quality Manager"
                                },
                                Courses = new List<Course>() {
                          new Course(){  Name = "Machine Language" }, //Child entity (empty key)
                          new Course(){  CId = 7 } //Child entity (with key value)
                                  }
                            };
                            using (var context = new SchoolDBEntities())
                            {
                                context.Entry(student).State = EntityState.Added;

                                foreach (var entity in context.ChangeTracker.Entries())
                                {
                                    Console.WriteLine("{0}: {1}", entity.Entity.GetType().Name, entity.State);
                                }
                                context.Students.Add(student);
                                context.SaveChanges();
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }*/



            ///  !------------- Adding Multiple Data In Student Table  ---------->
            try
            {
                using (var mc = new SchoolDBEntities())
                {
                    string[] studentNames = { "Shabbir", "Shoaib", "Mehboob", "Haroon", "Ali", "Waseem" };
                    string[] stName = { "Intern", "Full Stack Developer", "Junior Developer", "Senior Developer", "Intern", "HR","","","","" };
                    var studentsToAdd = new List<Student>();

                    for (int i = 0; i < studentNames.Length; i++)
                    {
                        
                            var std = new Student()
                            {
                                Name = studentNames[i],
                                STId = stName[i]
                            };
                            studentsToAdd.Add(std);
                        

                        
                    }

                    mc.Students.AddRange(studentsToAdd);
                    mc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            //modified code
            /*try
            {
                using (var mc = new SchoolDBEntities())
                {
                    int numberOfStudents = 6; // Define the number of students

                    string[] studentNames = new string[6]; // Create an array to store student names
                    int[] standardIds = new int[numberOfStudents]; // Create an array to store standard IDs

                    for (int i = 0; i < numberOfStudents; i++)
                    {
                        Console.Write($"Enter name for student {i + 1}: ");
                        studentNames[i] = Console.ReadLine(); // Get student name from user


                        Console.Write($"Enter standard ID for student {i + 1}: ");
                        int.TryParse(Console.ReadLine(), out standardIds[i]); // Get standard ID from user
                    }

                    var studentsToAdd = new List<Student>();

                    for (int i = 0; i < studentNames.Length; i++)
                    {
                        var std = new Student()
                        {
                            Name = studentNames[i],
                            STId = standardIds[i]
                        };

                        studentsToAdd.Add(std);
                    }

                    mc.Students.AddRange(studentsToAdd);
                    mc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            // new modified

            /*try
            {
                using (var mc = new SchoolDBEntities())
                {
                    var standards = mc.Standards.ToList(); // Get all existing standards

                    string[] studentNames = { "Shabbir", "khan", "nabeel", "Waseem" };

                    for (int i = 0; i < studentNames.Length; i++)
                    {
                        var std = new Student()
                        {
                            Name = studentNames[i],
                            Standard = standards[i % standards.Count] // Associate the student with a standard
                        };

                        mc.Students.Add(std);
                    }

                    mc.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/




            // nnot good for health
            /* try
             {
                 using (var mc = new SchoolDBEntities())
                 {
                     string[] studentNames = { "Shabbir", "khan", "nabeel", "Waseem" };

                     foreach (var studentName in studentNames)
                     {
                         var std = new Student()
                         {
                             Name = studentName,
                             // Don't set the 'STId' property here
                         };

                         mc.Students.Add(std);
                     }

                     mc.SaveChanges();
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/

            //// failed
            ///
            /*  try
              {
                  using (var mc = new SchoolDBEntities())
                  {
                      var standards = mc.Standards.ToList(); // Get all existing standards

                      string[] studentNames = { "Shabbir", "khan", "nabeel", "Waseem" };

                      for (int i = 0; i < studentNames.Length; i++)
                      {
                          var std = new Student()
                          {

                              Name = studentNames[i]
                              Standard = standards[i % standards.Count], // Associate the student with a standard
                          };

                          mc.Students.Add(std);
                      }

                      mc.SaveChanges();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }*/


            ///------- successfull single entry-------->

            /* try
             {
                 using (var mc = new SchoolDBEntities())
                 {
                     var crs = new Course()
                     {
                         Name = "Data Structure",
                         TId=4
                     };
                     mc.Courses.Add(crs);
                     mc.SaveChanges();
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/
            /*  try
              {
                  using (var mc = new SchoolDBEntities())
                  {
                      var tchr = new Teacher()
                      {
                          Name = "Shahid",
                          STId = 4
                      };
                      mc.Teachers.Add(tchr);
                      mc.SaveChanges();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }*/
            /* try
             {
                 using (var mc = new SchoolDBEntities())
                 {
                     var crs = new Course()
                     {
                         Name = "Data Structure",
                         TId = 4
                     };
                     mc.Courses.Add(crs);
                     mc.SaveChanges();
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }*/




            //--------------------------------------->

            /*try
            {

                using (var mc = new SchoolDBEntities())
                {
                    string[] standard_names = { "Project Manager", "FullStack Developer", "Senior Developer", "Junior Developer", "Intern" };
                     int[] studentIds = { 1, 2, 3, 4, 5 };
                    
                    for (int i = 0; i < standard_names.Length; i++)
                    {
                        var std = new Standard()
                        {
                            Name = standard_names[i],
                            STId = studentIds[i]
                            
                        };
                        mc.Standards.Add(std);
                        mc.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
