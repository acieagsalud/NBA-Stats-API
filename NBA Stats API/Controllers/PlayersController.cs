using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBA_Stats_API.Data;
using NBA_Stats_API.Dtos;
using NBA_Stats_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace NBA_Stats_API.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly INBARepo _repository;
        private readonly IMapper _mapper;

        public PlayersController(INBARepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetAllPlayers()
        {
            var players = _repository.GetAllPlayers();

            return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
        }

        // GET api/players/{id}
        [HttpGet("{id}", Name="GetPlayerById")]
        public ActionResult<PlayerReadDto> GetPlayerById(int id)
        {
            var player = _repository.GetPlayerById(id);

            if (player != null) return Ok(_mapper.Map<PlayerReadDto>(player));
            else return NotFound();
        }

        // GET api/players/name/{name}
        [HttpGet("name/{name}", Name = "GetPlayerByName")]
        public ActionResult<PlayerReadDto> GetPlayerByName(string name)
        {
            var player = _repository.GetPlayerByName(name);

            if (player != null) return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(player));
            else return NotFound();
        }

        // GET api/players/ByTeamId/{id}
        [HttpGet("ByTeamId/{id}", Name = "GetAllPlayersOnTeamId")]
        public ActionResult<PlayerReadDto> GetAllPlayersOnTeamId(int id)
        {
            var players = _repository.GetAllPlayersOnTeamId(id);

            if (players != null) return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
            else return NotFound();
        }

        // GET api/players/ByTeamName/{name}
        [HttpGet("ByTeamName/{name}", Name = "GetAllPlayersOnTeam")]
        public ActionResult<PlayerReadDto> GetAllPlayersOnTeamName(string name)
        {
            var players = _repository.GetAllPlayersOnTeamName(name);

            if (players != null) return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
            else return NotFound();
        }
    }
}
