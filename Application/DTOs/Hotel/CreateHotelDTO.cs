namespace Application.DTOs.Hotel
{
    public class CreateHotelDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}