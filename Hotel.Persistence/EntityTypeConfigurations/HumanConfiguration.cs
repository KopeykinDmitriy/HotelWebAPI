using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hotel.Domain;

namespace Hotel.Persistence.EntityTypeConfigurations
{
    public class HumanConfiguration: IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.HasKey(human => human.HumanId);
            builder.HasIndex(human => human.HumanId).IsUnique();
        }
    }
}
