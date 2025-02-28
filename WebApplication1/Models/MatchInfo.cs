using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MatchInfo
    {
        [Key]
        public int Id { get; set; }
        public int HomeClubId { get; set; }
        public Club? HomeClub { get; set; }
        public int AwayClubId { get; set; }
        public Club? AwayClub { get; set; }
        public int PossesionHome { get; set; }
        public int PossesionAway { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get;set; }
        public DateTime Date { get; set; }

        public List<Assist>? Assists { get; set; } = new List<Assist>();
        public List<Goal>? Goals { get; set; } = new List<Goal>();
    }
}
