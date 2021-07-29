using Microsoft.EntityFrameworkCore;
using models;

namespace SampleProject1.Data
{
    public class ApplicationDbContext  : DbContext
    {

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
       {   
       }
        public DbSet<Payment> Payments {get;set;}
        public DbSet<Vendor> Vendors{get;set;}
        public DbSet<Invoice> Invoices {get;set;}
        
    }
}