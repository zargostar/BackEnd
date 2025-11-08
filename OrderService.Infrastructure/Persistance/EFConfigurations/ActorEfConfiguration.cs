using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.EFConfigurations
{
    public class ActorEfConfiguration : IEntityTypeConfiguration<Actor>
    {


        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.FullName)
                .HasComputedColumnSql("[Name] +' '+[LastName]", true);
            


            builder.OwnsMany(x => x.DiscriptionI18n, nav =>
            {
                nav.ToJson();
            }
            );
            //builder.Property(a => a.Title)
            //       .HasConversion(
            //          v => JsonSerializer.Serialize(v ?? new Dictionary<string, string>(), (JsonSerializerOptions)null),
            //          v => string.IsNullOrEmpty(v)
            //          ? new Dictionary<string, string>()
            //          : JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions)null)!
            //     );
            //builder.OwnsOne(
            //    p => p.Address, navBilder =>
            //    {
            //        navBilder.ToJson();
            //        navBilder.OwnsOne(x => x.Home);
            //        navBilder.OwnsOne(x => x.Office);
            //    });
            //builder.OwnsOne(p => p.Location, navBuilder =>
            //{
            //    navBuilder.ToJson();
            //});








        }
}
}
