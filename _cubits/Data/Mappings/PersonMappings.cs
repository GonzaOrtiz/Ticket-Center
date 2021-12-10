using _cubits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _cubits.Data.Mappings
{
    public class PersonMappings : IEntityTypeConfiguration<PersonModel>
    {
        public void Configure(EntityTypeBuilder<PersonModel> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(l => l.Id);

        }
    }
}
