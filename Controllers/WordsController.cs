﻿using _NorskOrd_.Data;
using _NorskOrd_.Models;
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

        public WordsController(NorskOrdDBContext dbContext)
        {
            _dbContext = dbContext;
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
