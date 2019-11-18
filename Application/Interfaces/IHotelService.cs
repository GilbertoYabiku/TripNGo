using System;
using System.Collections.Generic;
using Application.DTOs.Hotel;

namespace Application.Interfaces
{
    public interface IHotelService
    {
        void Save(CreateHotelDTO model);
        void Update(UpdateHotelDTO model);
        void Delete(Guid id);
        HotelDTO Get(Guid id);
        IEnumerable<HotelDTO> GetAll();
    }
}