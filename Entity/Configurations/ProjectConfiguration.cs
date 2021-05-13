using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Configurations
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(x => x.Reports).WithOne(x => x.Projects).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User).WithMany(x => x.Projects).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
