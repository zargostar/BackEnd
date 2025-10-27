using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderServise.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServise.Infrastructure.Persistance.EFConfigurations
{
    public class CustommerEfConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ComplexProperty(x => x.Address);
            //builder.OwnsOne(user => user.Address, onNavigation => {
            //    onNavigation.ToJson();
            //    onNavigation.OwnsMany(p => p.WorkAddresses);
            //    onNavigation.OwnsOne(p => p.HomeAddresses);

            //});
            
        }
    }
}
