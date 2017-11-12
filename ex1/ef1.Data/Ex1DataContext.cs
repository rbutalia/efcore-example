
using ex1.Domain;
using ex1.Domain.Mappings;
using ex1.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ef1.Data
{
    public class Ex1DataContext: DbContext
    {
        private const string connectionString = "Server=.\\SQLEXPRESS; Database=ex1_master; Integrated Security=True;";
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] 
                                                                    {
                                                                        new ConsoleLoggerProvider((_, __) => true, true)
                                                                    });

                                                             //= new LoggerFactory(new[]
                                                             //       {
                                                             //           new ConsoleLoggerProvider((category, level)
                                                             //               => category == DbLoggerCategory.Database.Command.Name
                                                             //                  && level == LogLevel.Information, true)
                                                             //       });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                          .UseSqlServer(connectionString);
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
