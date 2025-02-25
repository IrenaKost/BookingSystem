namespace BookingSystem.Domain.Shared;

    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }

