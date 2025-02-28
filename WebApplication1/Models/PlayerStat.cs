using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PlayerStat
    {
        [Key]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}
