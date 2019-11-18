using System;
using Core.Models;

namespace Domain.BoundedContexts.RoomContext.Models
{
    public class Room : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}