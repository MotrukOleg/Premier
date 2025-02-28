using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class InputStadiumDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Capacity { get; set; }

    }

    public class OutputStadiumDto
    {
        public int id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Capacity { get; set; }
        public string Club { get; set; } = null!;
        public static explicit operator OutputStadiumDto(Stadium stadium)
        {
            Club? club = stadium.Club;
            return new OutputStadiumDto
            {
                id = stadium.Id,
                Name = stadium.Name,
                City = stadium.City,
                Country = stadium.Country,
                Capacity = stadium.Capacity,
                Club = club != null ? club.Name : "No club"
            };
        }
    }
}
