
namespace Domain.BoundedContexts.RoomContext.Commands.Room
{
    public class UpdateRoomCommand : BaseRoomCommand
    {
        public UpdateRoomCommand(string name, string description, int number, int capacity)
        {
            Name = name;
            Description = description;
            Number = number;
            Capacity = capacity;
        }
    }
}