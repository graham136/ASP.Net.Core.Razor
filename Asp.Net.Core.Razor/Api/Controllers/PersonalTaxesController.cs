using Asp.Net.Core.Razor.Api.Interfaces;
using Asp.Net.Core.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Controllers
{
    // Main Api Controller to calculate tax and save income and postal codes
    [Route("api/personalTax")]
    [ApiController]
    public class PersonalTaxController : ControllerBase
    {
        private readonly IDataRepository<PersonalTax> _dataRepository;
        private readonly ICalculate _taxlogic;

        public PersonalTaxController(IDataRepository<PersonalTax> dataRepository, ICalculate TaxLogic)
        {
            _dataRepository = dataRepository;
            _taxlogic = TaxLogic;
        }

        // GET: api/PersonalTax
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PersonalTax> personalTaxes = _dataRepository.GetAll();
            return Ok(personalTaxes);
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

        // Get: api/PersonalTax/Calculate
        [HttpGet("[action]")]
        public IActionResult Calculate()
        {

            var x = Request.QueryString;
            string postalCode = Request.Query["PersonalTax.PostalCode"];
            if (string.IsNullOrEmpty(postalCode))
            {
                return BadRequest(0);
            }

            decimal income = 0;
            decimal tax = 0;

            Decimal.TryParse(Request.Query["PersonalTax.TaxableIncome"], out income);

            if (income == 0)
            {
                return BadRequest(0);
            }

            tax = _taxlogic.calculateTax(postalCode, income);

            PersonalTax personalTax = new PersonalTax()
            {
                PostalCode = postalCode,
                TaxableIncome = income,
                LogTime = DateTime.Now,
                Tax = tax
            };

            _dataRepository.Add(personalTax);

            return Ok(tax);

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
            return Ok();
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
            return Ok();
        }
    }
}
