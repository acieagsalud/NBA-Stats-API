using NBA_Stats_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Stats_API.Dtos
{
    public class PlayerUpdateDto
    {
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
