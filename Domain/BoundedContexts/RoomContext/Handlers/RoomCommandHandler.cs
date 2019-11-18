using AutoMapper;
using Core.CQRS;
using Domain.BoundedContexts.RoomContext.Commands.Room;
using Domain.BoundedContexts.RoomContext.Interfaces;
using Domain.BoundedContexts.RoomContext.Models;

namespace Domain.BoundedContexts.RoomContext.Handlers
{
    public class RoomCommandHandler : IHandler<CreateRoomCommand>, IHandler<UpdateRoomCommand>, IHandler<RemoveRoomCommand>
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomCommandHandler(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Handle(CreateRoomCommand Message)
        {
            if(Message != null)
            {
                var room = _mapper.Map<Room>(Message);
                _repository.Add(room);
            }
        }

        public void Handle(UpdateRoomCommand Message)
        {
            if(Message != null)
            {
                var room = _mapper.Map<Room>(Message);
                _repository.Update(room);
            }
        }

        public void Handle(RemoveRoomCommand Message)
        {
            var room = _repository.FindById(Message.Id);
            if(room != null)
            {
                _repository.Remove(Message.Id);
            }
        }
    }
}