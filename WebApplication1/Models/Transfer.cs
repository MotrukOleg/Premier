using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Transfer
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player? Player { get; set; }
        public int ClubFromId { get; set; }
        public Club? ClubFrom { get; set; }
        public int ClubToId { get; set; }
        public Club? ClubTo { get; set; }
    }
}
