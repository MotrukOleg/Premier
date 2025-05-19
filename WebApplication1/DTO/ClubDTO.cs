using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class InputClubDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string city { get; set; } = null!;
        public string country { get; set; } = null!; 
        public string coach { get; set; } = null!;
        public int founded { get; set; }
        public int stadiumId{ get; set; }

    }

    public class InputClubForWeb
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string city { get; set; } = null!;
        public string country { get; set; } = null!;
        public string coach { get; set; } = null!;
        public int founded { get; set; }

    }

    public class OutputClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Coach { get; set; } = null!;
        public int Founded { get; set; }
        public string Stadium { get; set; } = null!;
        public int GoalConceded { get; set; }
        public int GoalScored { get; set; }
        public static explicit operator OutputClubDto(Club club)
        {
            Stadium stadium = club.Stadium;

            return new OutputClubDto
            {
                Id = club.Id,
                Name = club.Name,
                City = club.City,
                Country = club.Country,
                Coach = club.Coach,
                Founded = club.Founded,
                Stadium = stadium.Name ?? "No Stadium",
            };
        }
    }
}
