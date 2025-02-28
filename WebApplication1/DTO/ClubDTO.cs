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

    public class OutputClubDto
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string city { get; set; } = null!;
        public string country { get; set; } = null!;
        public string coach { get; set; } = null!;
        public int founded { get; set; }
        public string stadium { get; set; } = null!;
        public static explicit operator OutputClubDto(Club club)
        {
            Stadium stadium = club.Stadium;

            return new OutputClubDto
            {
                id = club.Id,
                name = club.Name,
                city = club.City,
                country = club.Country,
                coach = club.Coach,
                founded = club.Founded,
                stadium = stadium != null ? stadium.Name : "No Stadium"
            };
        }
    }

}
