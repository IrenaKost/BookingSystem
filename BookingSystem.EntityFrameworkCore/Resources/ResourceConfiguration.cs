using BookingSystem.Domain.Resources;
using BookingSystem.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.EntityFrameworkCore.Resources;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> b)
    {
        b.ToTable(BookingSystemConsts.DbTablePrefix + "Resources");

        b.HasKey(x => x.Id);
        b.Property(x => x.Name).IsRequired();
        b.Property(x => x.Quantity).IsRequired();
    }
}
