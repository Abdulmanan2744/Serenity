using My_Query_Testing_App.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace My_Query_Testing_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var mc = new BookListRazorEntities())
                {
                    //  !--------- Add new book  ---------->

                    /* var book = new Book()
                     {
                         Name = "C++",
                         Author="Mark Henry",
                         ISBN="Cyh7682626"

                     };
                     mc.Books.Add(book);
                     mc.SaveChanges();*/

                    //    !--------- Show Book Data  ---------->

                    /*   var book = mc.Books.FirstOrDefault(a => a.Id == 1021);

                       if (book != null)
                       {
                           Console.WriteLine(book.Name);
                       }
                       else
                       {
                           Console.WriteLine("No book found with the specified Id.");
                       }*/

                    //  !--------- Update book  ---------->

                  /*  var book = mc.Books.FirstOrDefault<Book>(a=>a.Name=="abc");
                    if (book != null)
                    {
                        // Modify all properties of the entity
                        book.Name = "The Bowller Steve";
                        book.Author = "Steve Smith";
                        book.ISBN = "AbSteve73638";
                        mc.SaveChanges();
                    }*/

                    //  !--------- Search book if not found add new one ---------->
                    var book= mc.Books.Where(a=>a.Author=="Kargil").FirstOrDefault<Book>();
                    if (book == null)
                    {
                        var book1 = new Book()
                        {
                            Name="Kargil",
                            Author="Generel Musharraf",
                            ISBN="GRM8678634K"
                        };
                        mc.Books.Add(book1);
                        mc.SaveChanges();
                    }

                    //  !--------- Add new book  ---------->


                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}

