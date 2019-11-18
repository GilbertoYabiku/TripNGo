using System;
using System.Collections.Generic;
using Domain.BoundedContexts.RoomContext.Models;

namespace Domain.BoundedContexts.RoomContext.Interfaces
{
    public interface IRoomRepository
    {
        Room FindById(Guid id);
        IEnumerable<Room> GetAll();
        void Add(Room t);
        void Remove(Guid id);
        void Update(Room t);
    }
}