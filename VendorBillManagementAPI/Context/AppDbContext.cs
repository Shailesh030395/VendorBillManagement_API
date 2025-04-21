using Microsoft.EntityFrameworkCore;
using VendorBillManagementAPI.Models;


namespace Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLineItem> BillLineItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Connections> Connections { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure precision for decimal properties
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bill>()
                .Property(b => b.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BillLineItem>()
                .Property(bli => bli.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            // Resolve multiple cascade paths by restricting delete behavior
          

        }
    }
}
