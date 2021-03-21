using _NorskOrd_.Data;
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
        public ActionResult<IEnumerable<Words>> GetAll()
        {
            var words = _dbContext
                .Words
                .ToList();

            return Ok(words);
        }
    }
}
