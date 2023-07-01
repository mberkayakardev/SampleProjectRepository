using AkarEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace AkarDataAccess.Concrete.DataAccess.Configuration
{
    public class GroupModelConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
             
        }
    }
}
