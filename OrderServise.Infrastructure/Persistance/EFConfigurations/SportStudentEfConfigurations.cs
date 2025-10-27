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
    public class SportStudentEfConfigurations : IEntityTypeConfiguration<SportStudent>
    {
        public void Configure(EntityTypeBuilder<SportStudent> builder)
        {
           builder.HasKey(p=> new {p.SportId,p.StudentId});
            builder.Property(x => x.SportLevel).IsRequired();
           
        }
    }
}
