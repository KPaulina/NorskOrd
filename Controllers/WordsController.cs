using _NorskOrd_;
using _NorskOrd_.Data;
using _NorskOrd_.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorskOrd.Controllers
{
    [Route("api/words")]
    public class WordsController : ControllerBase
    {
        private readonly NorskOrdDBContext _dbContext;
        private readonly IMapper _mapper;

        public WordsController(NorskOrdDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult AddNewWord([FromBody] AddNewWordDto dto)
        {
            var word = _mapper.Map<Words>(dto);
            _dbContext.Words.Add(word);
            _dbContext.SaveChanges();

            return Created($"/api/words/{word.Id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Words>> GetAll()
        {
            var words = _dbContext
                .Words
                .ToList();

            return Ok(words);
        }

        [HttpGet("{id}")]
        public ActionResult<Words> Get([FromRoute] int id)
        {
            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == id);

            if(word is null)
            {
                return NotFound();
            }

            return Ok(word);
        }
    }
}
