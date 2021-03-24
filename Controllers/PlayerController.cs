using _NorskOrd_.Data;
using _NorskOrd_.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _NorskOrd_.Controllers
{
    [Route("api/player")]
    public class PlayerController : Controller
    {
        private readonly NorskOrdDBContext _dbContext;
        private readonly IMapper _mapper;

        public PlayerController(NorskOrdDBContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public ActionResult<IEnumerable<PlayerDto>> GetAll()
        {
            var players = _dbContext
                .Player
                .ToList();

            List<PlayerDto> playerDtos = _mapper.Map<List<PlayerDto>>(players);

            return Ok(playerDtos);
        }
    }
}
