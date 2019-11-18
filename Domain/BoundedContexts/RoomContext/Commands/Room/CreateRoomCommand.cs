
namespace Domain.BoundedContexts.RoomContext.Commands.Room
{
    public class CreateRoomCommand : BaseRoomCommand
    {
        public CreateRoomCommand(string name, string description, int number, int capacity)
        {
            Name = name;
            Description = description;
            Number = number;
            Capacity = capacity;
        }
    }
}