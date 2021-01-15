using System.ComponentModel.DataAnnotations;

namespace NBA_Stats_API.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(5)]
        public string Position { get; set; }

        [Required]
        [MaxLength(10)]
        public string Height { get; set; }

        [Required]
        [MaxLength(7)]
        public int Weight { get; set; }


        [Required]
        public int TeamId { get; set; }

        [Required]
        public Team Team { get; set; }

    }
}
