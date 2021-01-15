using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBA_Stats_API.Data;
using NBA_Stats_API.Dtos;
using NBA_Stats_API.Models;
using System.Collections.Generic;

namespace NBA_Stats_API.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly INBARepo _repository;
        private readonly IMapper _mapper;

        public TeamsController(INBARepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/teams
        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetAllTeams()
        {
            var teams = _repository.GetAllTeams();

            return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(teams));
        }

        // GET api/teams/{id}
        [HttpGet("{id}", Name = "GetTeamById")]
        public ActionResult<TeamReadDto> GetTeamById(int id)
        {
            var team = _repository.GetTeamById(id);

            if (team != null) return Ok(_mapper.Map<TeamReadDto>(team));
            else return NotFound();
        }

        // GET api/teams/name/{name}
        [HttpGet("name/{name}", Name = "GetTeamByName")]
        public ActionResult<TeamReadDto> GetTeamByName(string name)
        {
            var team = _repository.GetTeamByName(name);
            if (team != null) return Ok(_mapper.Map<IEnumerable<TeamReadDto>>(team));
            else return NotFound();
        }
    }
}
