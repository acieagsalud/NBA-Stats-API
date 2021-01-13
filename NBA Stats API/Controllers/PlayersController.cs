using AutoMapper;
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
    }
}
