using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.EFConfigurations
{
    public class SuplierEfConfiguration : IEntityTypeConfiguration<Suplier>
    {
        public void Configure(EntityTypeBuilder<Suplier> builder)
        {
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Suplier)
                .OnDelete(DeleteBehavior.SetNull);
            builder.Property(x => x.Country).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
