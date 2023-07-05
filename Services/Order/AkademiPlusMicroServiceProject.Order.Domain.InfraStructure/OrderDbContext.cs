using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Order.Domain.InfraStructure
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options ):base(options)
        {
           
        }
        public DbSet<AkademiPlusMicroServiceProject.Order.Domain.Entities.Order> Orders { get; set; } 
        public DbSet<AkademiPlusMicroServiceProject.Order.Domain.Entities.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
