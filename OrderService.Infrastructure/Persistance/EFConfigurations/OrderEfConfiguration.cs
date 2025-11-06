using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.EFConfigurations
{
    public class OrderEfConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //  builder.HasNoKey();
            //  builder.HasIndex(x => x.UserId).HasName("KeyId").IsUnique();
            //  builder.HasKey(e => e.Id);
            //  builder.HasAlternateKey(e => e.UserId);
            // builder.ToTable("tblOrder",schema:"ordering");
            //  builder.Property(x => x.Id).HasColumnName("OrderId");
            //  builder.HasQueryFilter(x => x.UserId == null);
           // builder.HasIndex(x => x.Moblie).HasFillFactor(100);
          // builder.Property(x=>x.UserId).HasPrecision(6,3);
         
            builder.Property(x=>x.Address).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Moblie).IsRequired().HasMaxLength(10);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.HasMany(x=>x.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            //builder.ToTable("TempralOrder", "majid",
            //    p => p.IsTemporal(p=> { p.HasPeriodEnd("End");
            //        p.HasPeriodStart("Start");
            //    }));
            // //notes=> _dbContext.Orders.TemporalAsOf=>return history of special Time
            //we can recicevd history of changes in data base

        }
    }
}
