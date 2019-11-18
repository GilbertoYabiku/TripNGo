using System;
using Core.CQRS;

namespace Domain.BoundedContexts.RoomContext.Commands.Room
{
    public class RemoveRoomCommand : Command
    {
        public RemoveRoomCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}