using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApplication1.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public string Nationality { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int Price { get; set; }
        public DateTime SignContractDate { get; set; }
        public DateTime ExpiredContractTime { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        public byte[]? Picture { get; set; }

        public PlayerStat? PlayerStat { get; set; }
        public  List<Transfer>? Transfer { get; set; } = new List<Transfer>();
    }
}
