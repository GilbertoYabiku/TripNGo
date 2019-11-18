using System;
using Application.DTOs.Hotel;

namespace Application.DTOs.Room
{
    public class RoomDTO : BaseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Guid HotelId { get; set; }
        public HotelDTO Hotel { get; set; }
    }
}