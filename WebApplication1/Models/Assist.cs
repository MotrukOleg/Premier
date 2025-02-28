using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Assist
    {
        [Key]
        public int Id { get; set; }
        public int MatchId { get; set; }
        public MatchInfo? Match { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
    }
}
