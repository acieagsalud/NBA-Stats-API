using AutoMapper;
using NBA_Stats_API.Dtos;
using NBA_Stats_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA_Stats_API.Profiles
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            CreateMap<Team, TeamReadDto>();
        }
    }
}
