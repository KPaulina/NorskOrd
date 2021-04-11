using _NorskOrd_;
using _NorskOrd_.Data;
using _NorskOrd_.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NorskOrd_.Services;

namespace NorskOrd.Controllers
{
    [Route("api/words")]
    public class WordsController : ControllerBase
    {
        private readonly INorskOrd _NorskOrdService;

        public WordsController(INorskOrd norskOrdService)
        {
            _NorskOrdService = norskOrdService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _NorskOrdService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateWordDto dto, [FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _NorskOrdService.Update(id, dto);
            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult AddNewWord([FromBody] AddNewWordDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _NorskOrdService.Create(dto);

            return Created($"/api/words/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Words>> GetAll()
        {
            var NorskOrdDtos = _NorskOrdService.GetAll();
            return Ok(NorskOrdDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<Words> Get([FromRoute] int id)
        {

            var word = _NorskOrdService.GetById(id);
            if(word is null)
            {
                return NotFound();
            }

            return Ok(word);
        }


    }
}
