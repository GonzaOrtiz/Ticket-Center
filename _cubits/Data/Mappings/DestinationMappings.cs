using _cubits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _cubits.Data.Mappings
{
    public class DestinationMappings : IEntityTypeConfiguration<DestinationModel>
    {
        public void Configure(EntityTypeBuilder<DestinationModel> builder)
        {
            builder.ToTable("Destinations");
            builder.HasKey(l => l.Id);

        }
    }
}
