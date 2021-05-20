using System;
using System.Linq;

namespace consoleAppSQLite
{
    class Program
    {
        private static bool AddBlog(string strUrl, int intAvaliacao, string strTitulo, string strConteudo)
        {
            int contador = 0;
            using (var db = new BlogContext())
            {
                var blog = new Blog { Url = strUrl, Avaliacao = intAvaliacao};
                var post = new Post {Titulo = strTitulo, Conteudo = strConteudo, Blog = blog};
                db.Blogs.Add(blog);
                if(db.SaveChanges() > 0)
                {
                    db.Posts.Add(post);
                    contador = db.SaveChanges();
                }
            }
            return Convert.ToBoolean(contador);
        }

        public static bool RemovePost(int intId)
        {
            int contador = 0;
            using (var db = new BlogContext())
            {
                db.Posts.Remove(new Post { PostId = intId });
                contador = db.SaveChanges();
            }
            return Convert.ToBoolean(contador);
        }
        private static void ShowBlog()
        {
            using (var db = new BlogContext())
            {
                foreach(var post in db.Posts.OrderBy(p => p.Titulo).ToList())
                 {
                    Console.WriteLine(post.BlogId);
                    Console.WriteLine(post.Titulo);
                    Console.WriteLine(post.Conteudo);
                 }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o blog, avaliação , titulo e conteudo do post");
            string strUrl = Console.ReadLine();
            int intAvaliacao = Convert.ToInt32(Console.ReadLine()); 
            string strTitulo = Console.ReadLine(); 
            string strConteudo = Console.ReadLine();

            if(AddBlog(strUrl, intAvaliacao, strTitulo, strConteudo))
            {
                ShowBlog();
            }

        }
    }
}
