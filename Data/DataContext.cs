using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebAppFooter.Entities;

namespace WebAppFooter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
           
        }

        public DbSet<Footer> Footers { get; set; }
    }
}
