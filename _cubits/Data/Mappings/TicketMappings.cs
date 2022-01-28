using _cubits.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _cubits.Data.Mappings
{
    public class TicketMappings : IEntityTypeConfiguration<TicketModel>
    {
        public void Configure(EntityTypeBuilder<TicketModel> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(l => l.Id);

        }
    }
}
