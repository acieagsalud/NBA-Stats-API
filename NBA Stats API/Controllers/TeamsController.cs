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
    }
}
