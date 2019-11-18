using System;
using System.Collections.Generic;
using Domain.BoundedContexts.RoomContext.Models;

namespace Domain.BoundedContexts.RoomContext.Interfaces
{
    public interface IHotelRepository
    {
        Hotel FindById(Guid id);
        IEnumerable<Hotel> GetAll();
        void Add(Hotel t);
        void Remove(Guid id);
        void Update(Hotel t);
    }
}