using AutoMapper;
using Core.CQRS;
using Domain.BoundedContexts.RoomContext.Commands.Hotel;
using Domain.BoundedContexts.RoomContext.Interfaces;
using Domain.BoundedContexts.RoomContext.Models;

namespace Domain.BoundedContexts.RoomContext.Handlers
{
    public class HotelCommandHandler : IHandler<CreateHotelCommand>, IHandler<UpdateHotelCommand>, IHandler<RemoveHotelCommand>
    {
        private readonly IHotelRepository _repository;
        private readonly IMapper _mapper;

        public HotelCommandHandler(IHotelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Handle(CreateHotelCommand Message)
        {
            if(Message != null)
            {
                var hotel = _mapper.Map<Hotel>(Message);
                _repository.Add(hotel);
            }
        }

        public void Handle(UpdateHotelCommand Message)
        {
            if(Message != null)
            {
                var hotel = _mapper.Map<Hotel>(Message);
                _repository.Update(hotel);
            }
        }

        public void Handle(RemoveHotelCommand Message)
        {
            var hotel = _repository.FindById(Message.Id);
            if(hotel != null)
            {
                _repository.Remove(Message.Id);
            }
        }
    }
}