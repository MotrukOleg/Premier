using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int  Capacity { get; set; }
        public int? ClubId { get; set; }
        public Club? Club { get; set; }
    }
}
