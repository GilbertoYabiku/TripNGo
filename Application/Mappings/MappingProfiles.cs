using Application.DTOs.Room;
using AutoMapper;
using Domain.BoundedContexts.RoomContext.Models;
using Domain.BoundedContexts.RoomContext.Commands.Room;
using Application.DTOs.Hotel;
using Domain.BoundedContexts.RoomContext.Commands.Hotel;

namespace Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<CreateRoomCommand, CreateRoomDTO>().ReverseMap();
            CreateMap<UpdateRoomCommand, UpdateRoomDTO>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<CreateHotelCommand, CreateHotelDTO>().ReverseMap();
            CreateMap<UpdateHotelCommand, UpdateHotelDTO>().ReverseMap();
        }
    }
}