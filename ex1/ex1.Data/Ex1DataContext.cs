
using System;
using ex1.Domain;
using System.Linq;
using ex1.Domain.Mappings;
using ex1.Domain.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ex1.Data
{
    public class Ex1DataContext: DbContext
    {
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
        public Ex1DataContext() { }
        public Ex1DataContext(DbContextOptions<Ex1DataContext> options)  :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Ex1SqlConnection")));
            }
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            //              .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Company>(new CompanyConfig());
            modelBuilder.ApplyConfiguration<ProductCategory>(new ProductCategoryConfig());
            //modelBuilder.Entity<Customer>().Property(c => c.Company).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added ||
                         e.State == EntityState.Modified))
            {
                entry.Property("ModifiedDate").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges();
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
