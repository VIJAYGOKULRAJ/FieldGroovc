using CRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.MySQL.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Leads> Leads { get; set; }
        public DbSet<Estimates> Estimates { get; set; }
        public DbSet<WorkOrders> WorkOrders { get; set; }
        public DbSet<Vendors> Vendors { get; set; }
        public DbSet<InventoryItems> InventoryItems { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Opportunities> Opportunities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Companies> companies { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }
        public DbSet<ToDos> ToDos { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // UseSqlServer with EnableRetryOnFailure
                optionsBuilder.UseSqlServer(
                   "Data Source=DESKTOP-S3MV8AB\\SQLEXPRESS;Initial Catalog=FieldGroovc;Integrated Security=True;Encrypt=True;Trust Server Certificate=True",
                    options => options.EnableRetryOnFailure());
            }
        }
    }
}
