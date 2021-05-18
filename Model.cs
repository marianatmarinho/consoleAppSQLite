using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace consoleAppSQLite
{
 public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            optionsBuilder.UseSqlite("DataSource=blog.db;");
         //   optionsBuilder.UseSqlite(@"Server=(localdb)\mssqllocaldb;Database=blog.db;
//Trusted_Connection=True;");
        }
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}