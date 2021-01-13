using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Stats_API.Dtos
{
    public class TeamReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Abbreviation { get; set; }

        public string Conference { get; set; }

        public string Division { get; set; }
    }
}
