using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Standings
    {
        [Key]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Looses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalsDifference {  get; set; }
        public int Points { get; set; }
    }
}
