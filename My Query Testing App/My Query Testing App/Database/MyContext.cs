using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Query_Testing_App.Database
{
    public class MyContext : DbContext
    {



       /* string connectionString = "Server=DESKTOP-4L73U46; Database=BookListRazor; Integrated Security=True";*/
        public MyContext() : base("name=TestConnection")
        {

        }
      
        public DbSet<Booksm> books { get; set; }



    }
}
