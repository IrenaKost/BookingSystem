using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Application.Resources.DTOs;

public class CreateResourceInputDto
{
    public string Name { get; set; } = default!;
    public int Quantity { get; set; }
}
