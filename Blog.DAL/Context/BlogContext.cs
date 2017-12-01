using Blog.DAL.Migrations;
using Blog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>("BlogContext"));
           // this.Configuration.LazyLoadingEnabled = true;

            
        }
        //dbset
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }


    }
}
