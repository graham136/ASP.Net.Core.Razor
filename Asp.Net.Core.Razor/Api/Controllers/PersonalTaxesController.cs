using Asp.Net.Core.Razor.Api.Interfaces;
using Asp.Net.Core.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Controllers
{
    [Route("api/personalTax")]
    [ApiController]
    public class PersonalTaxController : ControllerBase
    {
        private readonly IDataRepository<PersonalTax> _dataRepository;

        public PersonalTaxController(IDataRepository<PersonalTax> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/PersonalTax
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PersonalTax> personalTaxes = _dataRepository.GetAll();
            return Ok(personalTaxes);
        }

        // GET: api/PersonalTax/GetTaxCodes;
        [HttpGet]
        public IActionResult GetTaxCodes()
        {
            IEnumerable<string> taxCodes = _dataRepository.GetTaxCodes();
            return Ok(taxCodes);
        }

        // GET: api/PersonalTax/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            PersonalTax personalTax = _dataRepository.Get(id);

            if (personalTax == null)
            {
                return NotFound("The PersonalTax record couldn't be found.");
            }

            return Ok(personalTax);
        }

        // POST: api/PersonalTax
        [HttpPost]
        public IActionResult Post([FromBody] PersonalTax personalTax)
        {
            if (personalTax == null)
            {
                return BadRequest("PersonalTax is null.");
            }

            _dataRepository.Add(personalTax);
            return CreatedAtRoute(
                  "Get",
                  new { Id = personalTax.Id },
                  personalTax);
        }

        // PUT: api/PersonalTax/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] PersonalTax personalTax)
        {
            if (personalTax == null)
            {
                return BadRequest("PersonalTax is null.");
            }

            PersonalTax personalTaxToUpdate = _dataRepository.Get(id);
            if (personalTaxToUpdate == null)
            {
                return NotFound("The PersonalTax record couldn't be found.");
            }

            _dataRepository.Update(personalTaxToUpdate, personalTax);
            return NoContent();
        }

        // DELETE: api/PersonalTax/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            PersonalTax personalTax = _dataRepository.Get(id);
            if (personalTax == null)
            {
                return NotFound("The PersonalTax record couldn't be found.");
            }

            _dataRepository.Delete(personalTax);
            return NoContent();
        }
    }
}
