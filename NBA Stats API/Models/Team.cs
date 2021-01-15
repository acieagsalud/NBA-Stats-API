using System.ComponentModel.DataAnnotations;

namespace NBA_Stats_API.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(25)]
        public string Conference { get; set; }

        [Required]
        [MaxLength(25)]
        public string Division { get; set; }
    }
}
