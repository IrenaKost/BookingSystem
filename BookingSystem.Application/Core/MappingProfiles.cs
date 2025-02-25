using AutoMapper;
using BookingSystem.Application.Bookings.DTOs;
using BookingSystem.Application.Resources.DTOs;
using BookingSystem.Domain.Bookings;
using BookingSystem.Domain.Resources;

namespace BookingSystem.Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Resource, ResourceDto>().ReverseMap();
        CreateMap<CreateResourceInputDto, Resource>();
        CreateMap<UpdateResourceInputDto, Resource>();

        CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.Resource)); // try remove this line
        CreateMap<CreateBookingInputDto, Booking>();
        CreateMap<UpdateBookingInputDto, Booking>();
    }
}

