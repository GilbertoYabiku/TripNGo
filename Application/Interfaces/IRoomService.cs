using System;
using System.Collections.Generic;
using Application.DTOs.Room;

namespace Application.Interfaces
{
    public interface IRoomService
    {
        void Save(CreateRoomDTO model);
        void Update(UpdateRoomDTO model);
        void Delete(Guid id);
        RoomDTO Get(Guid id);
        IEnumerable<RoomDTO> GetAll();
    }
}