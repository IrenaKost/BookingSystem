using BookingSystem.Domain.Shared;

namespace BookingSystem.Application.Resources.DTOs;

public class UpdateResourceInputDto : CreateResourceInputDto
{
    public required int Id { get; set; }
}
