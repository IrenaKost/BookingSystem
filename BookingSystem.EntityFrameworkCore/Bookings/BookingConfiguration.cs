using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.EntityFrameworkCore.Bookings
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> b)
        {
            b.ToTable(BookingSystemConsts.DbTablePrefix + "Bookings");

            b.HasKey(x => x.Id);
            b.Property(x => x.DateFrom).IsRequired();
            b.Property(x => x.DateTo).IsRequired();
            b.Property(x => x.BookedQuantity).IsRequired();

            b.HasOne(x => x.Resource).WithMany(x => x.Bookings).HasForeignKey(x => x.ResourceId).IsRequired();

        }
    }
}
