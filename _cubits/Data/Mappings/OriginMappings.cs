using _cubits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _cubits.Data.Mappings
{
    public class OriginMappings : IEntityTypeConfiguration<OriginModel>
    {
        public void Configure(EntityTypeBuilder<OriginModel> builder)
        {
            builder.ToTable("Origins");
            builder.HasKey(l => l.Id);

        }
    }
}