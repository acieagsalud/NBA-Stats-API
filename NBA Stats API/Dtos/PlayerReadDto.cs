using NBA_Stats_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Stats_API.Dtos
{
    public class PlayerReadDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string Height { get; set; }

        public int Weight { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
