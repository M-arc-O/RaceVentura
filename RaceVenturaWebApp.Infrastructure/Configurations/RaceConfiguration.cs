using RaceVenturaWebApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RaceVenturaWebApp.Infrastructure.Configurations;
public class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.ToTable("Race");
        builder.HasKey(x => x.Id);
    }
}
