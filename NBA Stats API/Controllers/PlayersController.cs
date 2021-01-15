using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NBA_Stats_API.Data;
using NBA_Stats_API.Dtos;
using NBA_Stats_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET api/players/byteamid/
        [HttpGet("byteamid/{id}", Name = "GetAllPlayersOnTeam")]
        public ActionResult<PlayerReadDto> GetAllPlayersOnTeam(int id)
        {
            var players = _repository.GetAllPlayers().Where(p => p.TeamId == id);

            if (players != null) return Ok(_mapper.Map<IEnumerable<PlayerReadDto>>(players));
            else return NotFound();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateCommand(int id, JsonPatchDocument<PlayerUpdateDto> patchDoc)
        {
            var playerModelFromRepo = _repository.GetPlayerById(id);
            if (playerModelFromRepo == null) return NotFound();

            var playerToPatch = _mapper.Map<PlayerUpdateDto>(playerModelFromRepo);
            patchDoc.ApplyTo(playerToPatch, ModelState);

            if (!TryValidateModel(playerToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(playerToPatch, playerModelFromRepo);
            _repository.UpdatePlayer(playerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
