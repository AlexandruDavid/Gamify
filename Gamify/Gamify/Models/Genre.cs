using System.ComponentModel.DataAnnotations;

namespace Gamify.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}