using ApiRestGenerica.Application;
using ApiRestGenerica.DTOs;
using ApiRestGenerica.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestGenerica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {

        IApplication<FootballTeam> _football;

        public FootballTeamController(IApplication<FootballTeam> football)
        {
            _football = football;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_football.GetAll());
        }
        
        [HttpPost]
        public IActionResult Save(FootballTeamDTO footballTeamDTO)
        {
            var footballTeam = new FootballTeam()
            {
                Name = footballTeamDTO.Name,
                Score = footballTeamDTO.Score
            };
            return Ok(_football.Save(footballTeam));

        }

    }
}
