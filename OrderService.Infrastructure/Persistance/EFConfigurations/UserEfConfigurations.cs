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
    public class UserEfConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.ComplexProperty(x => x.Address);
            //builder.OwnsOne(user => user.Address, onNavigation => {
            //    onNavigation.ToJson();
            //    onNavigation.OwnsMany(p => p.WorkAddresses);
            //    onNavigation.OwnsOne(p => p.HomeAddresses);

            //});
            
        }
    }
}
