

namespace Domain.BoundedContexts.RoomContext.Commands.Hotel
{
    public class CreateHotelCommand : BaseHotelCommand
    {
        public CreateHotelCommand(string name, string description, double rating, string street, int number, string complement, string zipcode, string district, string city, string country)
        {
            Name = name;
            Description = description;
            Rating = rating;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipcode;
            District = district;
            City = city;
            Country = country;
        }
    }
}