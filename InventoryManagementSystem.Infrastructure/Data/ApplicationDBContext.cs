using InventoryManagementSystem.Application.ViewModels;
using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContext) : base(dbContext)
        { }

        

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ReceiveHeader> ReceiveHeader { get; set; }
        public DbSet<ReceiveDetails> ReceiveDetails { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<PendingOrderVm> PendingOrderVm { get; set; }
        public DbSet<PendingItemVm> PendingItemVm { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.ROL)
                .HasPrecision(18, 2); // or use .HasColumnType("decimal(18,2)")
            modelBuilder.Entity<OrderDetails>()
                .Property(o => o.Quantity)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ReceiveDetails>()
                .Property(r => r.Qty)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ReceiveDetails>()
               .Property(r => r.BalanceQty)
               .HasPrecision(18, 2);
            modelBuilder.Entity<Stock>()
               .Property(s => s.SIH)
               .HasPrecision(18, 2);
            modelBuilder.Entity<PendingOrderVm>().HasNoKey().ToView(null);
            modelBuilder.Entity<PendingItemVm>().HasNoKey().ToView(null);

        }


    }
}
