using System;
using System.Collections.Generic;
using Application.DTOs.Hotel;
using Application.Interfaces;
using AutoMapper;
using Core.CQRS;
using Domain.BoundedContexts.RoomContext.Models;
using Domain.BoundedContexts.RoomContext.Interfaces;
using Domain.BoundedContexts.RoomContext.Commands.Hotel;

namespace Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public HotelService(IHotelRepository repository, IMapper mapper, IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new RemoveHotelCommand(id));
        }

        public IEnumerable<HotelDTO> GetAll()
        {
            IEnumerable<Hotel> entityList = _repository.GetAll();
            List<HotelDTO> entityDTOList = new List<HotelDTO>();
            foreach(Hotel entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<HotelDTO>(entity));
            }
            return entityDTOList;
        }

        public HotelDTO Get(Guid id)
        {
            var model = _repository.FindById(id);
            if(model != null)
            {
                return _mapper.Map<HotelDTO>(model);
            }
            return null;
        }

        public void Save(CreateHotelDTO model)
        {
            var room = _mapper.Map<CreateHotelCommand>(model);
            _bus.SendCommand(room);
        }

        public void Update(UpdateHotelDTO model)
        {
            var room = _mapper.Map<UpdateHotelCommand>(model);
            _bus.SendCommand(room);
        }
    }
}