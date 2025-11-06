using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.EFConfigurations
{
    public class ActorEfConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.MetaData)
                   .HasConversion(
                      v => JsonSerializer.Serialize(v ?? new Dictionary<string, string>(), (JsonSerializerOptions)null),
                      v => string.IsNullOrEmpty(v)
                      ? new Dictionary<string, string>()
                      : JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions)null)!
                   );
            builder.OwnsOne(
                p => p.Address, navBilder =>
                {
                    navBilder.ToJson();
                    navBilder.OwnsOne(x => x.Home);
                    navBilder.OwnsOne(x => x.Office);
                });
            builder.OwnsOne(p => p.Location, navBuilder =>
            {
                navBuilder.ToJson();
            });



            builder.Property(p=>p.Degries).HasConversion(x=>  JsonSerializer.Serialize(x ??  new List<int>(), (JsonSerializerOptions)null),y=> JsonSerializer.Deserialize<List<int>>(y, (JsonSerializerOptions)null));

            builder.Property(x => x.Grade).HasColumnType("decimal(18,4)");
                
        }
    }
}
