using AutoMapper;
using NBA_Stats_API.Dtos;
using NBA_Stats_API.Models;

namespace NBA_Stats_API.Profiles
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            CreateMap<Player, PlayerReadDto>();
        }
    }
}
