using System;
using System.Collections.Generic;
using Application.DTOs.Room;
using Application.Interfaces;
using AutoMapper;
using Core.CQRS;
using Domain.BoundedContexts.RoomContext.Models;
using Domain.BoundedContexts.RoomContext.Commands.Room;
using Domain.BoundedContexts.RoomContext.Interfaces;

namespace Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public RoomService(IRoomRepository repository, IMapper mapper, IBus bus)
        {
            _repository = repository;
            _mapper = mapper;
            _bus = bus;
        }

        public void Delete(Guid id)
        {
            _bus.SendCommand(new RemoveRoomCommand(id));
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            IEnumerable<Room> entityList = _repository.GetAll();
            List<RoomDTO> entityDTOList = new List<RoomDTO>();
            foreach(Room entity in entityList)
            {
                entityDTOList.Add(_mapper.Map<RoomDTO>(entity));
            }
            return entityDTOList;
        }

        public RoomDTO Get(Guid id)
        {
            var model = _repository.FindById(id);
            if(model != null)
            {
                return _mapper.Map<RoomDTO>(model);
            }
            return null;
        }

        public void Save(CreateRoomDTO model)
        {
            var room = _mapper.Map<CreateRoomCommand>(model);
            _bus.SendCommand(room);
        }

        public void Update(UpdateRoomDTO model)
        {
            var room = _mapper.Map<UpdateRoomCommand>(model);
            _bus.SendCommand(room);
        }
    }
}