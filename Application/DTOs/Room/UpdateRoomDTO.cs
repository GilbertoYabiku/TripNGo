
namespace Application.DTOs.Room
{
    public class UpdateRoomDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}