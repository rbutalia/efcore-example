
using ex1.Domain;
using ex1.Domain.Mappings;
using ex1.Domain.Relationships;
using Microsoft.EntityFrameworkCore;

namespace ef1.Data
{
    public class Ex1DataContext: DbContext
    {
        private const string connectionString = "Server=.\\SQLEXPRESS; Database=ex1_master; Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Company>(new CompanyConfig());
            modelBuilder.ApplyConfiguration<ProductCategory>(new ProductCategoryConfig());
            //modelBuilder.Entity<Customer>().Property(c => c.Company).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
    }
}
