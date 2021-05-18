using System;

namespace consoleAppSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BlogContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Blogs.Add(new Blog { Url = "http://macoratti.net/aspnet" });
                db.Blogs.Add(new Blog { Url = "http://microsoft.msdn/vbnet" });
                var contador = db.SaveChanges();
                Console.WriteLine("{0} registros salvos no banco de dados ", contador);
                Console.WriteLine();
                Console.WriteLine("Todos os blogs no banco de dados:");

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }
    }
}
