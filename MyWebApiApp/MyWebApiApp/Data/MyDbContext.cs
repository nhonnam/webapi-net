using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.Id);
                e.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(o => o.Customer).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetails>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(od => new { od.OrderId, od.ItemId });

                e.HasOne(od => od.Order)
                    .WithMany(od => od.OrderDetails)
                    .HasForeignKey(od => od.OrderId)
                    .HasConstraintName("FK_OrderDetails_Order");

                e.HasOne(od => od.Item)
                    .WithMany(od => od.OrderDetails)
                    .HasForeignKey(od => od.ItemId)
                    .HasConstraintName("FK_OrderDetails_Item");
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(u => u.UserName).IsUnique();
                e.Property(u => u.FullName).IsRequired().HasMaxLength(150);
                e.Property(u => u.Email).IsRequired().HasMaxLength(150);
            });
        }
    }
}
