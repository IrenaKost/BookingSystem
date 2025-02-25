namespace BookingSystem.Domain.Shared;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}
