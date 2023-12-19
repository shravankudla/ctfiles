using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using NLog.Internal;

namespace ContactsLib
{
    public class ContactContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=CTAADPG02MWAZ\\SQLEXPRESS;Initial Catalog=InMemoryDb;User Id=sa;Password=password_123;TrustServerCertificate=true");
        }
    }
}
