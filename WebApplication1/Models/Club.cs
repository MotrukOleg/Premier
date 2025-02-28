using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApplication1.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Coach { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Founded { get; set; }
        public byte[]? Logo { get; set; }
        public int StadiumId { get; set; } 
        public Stadium Stadium { get; set; } = null!;

        public List<Player>? players { get; set; } = new List<Player>();
        public List<Transfer>? TransferFrom { get; set; } = new List<Transfer>(); 
        public List<Transfer>? TransferTo { get; set; } = new List<Transfer>();
    }
}
