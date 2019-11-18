using System;
using Core.CQRS;

namespace Domain.BoundedContexts.RoomContext.Commands.Hotel
{
    public class RemoveHotelCommand : Command
    {
        public RemoveHotelCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}