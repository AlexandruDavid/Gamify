using System.ComponentModel.DataAnnotations;

namespace Gamify.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte Discount { get; set; }

        public static readonly byte Unkonown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}