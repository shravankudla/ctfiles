using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
    public class MyDbContext:DbContext 
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("UserWebAPI"));
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("conne");
            }
            //optionsBuilder.UseSqlServer("server=CTAADPG02MWAZ\\SQLEXPRESS;database=EfDb;uid=sa;pwd=password_123;TrustServerCertificate=True");
        }
    }
}
