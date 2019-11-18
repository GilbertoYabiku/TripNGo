using Core.CQRS;

namespace Domain.BoundedContexts.RoomContext.Commands.Room
{
    public abstract class BaseRoomCommand : Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}