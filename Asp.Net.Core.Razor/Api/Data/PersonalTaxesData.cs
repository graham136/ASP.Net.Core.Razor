﻿using Asp.Net.Core.Razor.Api.Interfaces;
using Asp.Net.Core.Razor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Data
{   
    
    public class PersonalTaxesData : IDataRepository<PersonalTax>
    {
        private PersonalTaxesDBContext _personalTaxesDbContext;

        // Injecting the EF Core dbcontext
        public PersonalTaxesData(PersonalTaxesDBContext context)
        {
            _personalTaxesDbContext = context;
        }
        public IEnumerable<PersonalTax> GetAll()
        {
            //Adding this just so that there is sometihng to display for you guys.
            IEnumerable<PersonalTax> tempTaxes = _personalTaxesDbContext.PersonalTaxes.ToList();
           
            return _personalTaxesDbContext.PersonalTaxes.ToList();
        }
        public void Add(PersonalTax entity)
        {
            _personalTaxesDbContext.PersonalTaxes.Add(entity);
            _personalTaxesDbContext.SaveChanges();
        }

        public void Delete(PersonalTax entity)
        {
            _personalTaxesDbContext.PersonalTaxes.Remove(entity);
            _personalTaxesDbContext.SaveChanges();
        }

        public PersonalTax Get(long id)
        {
            return _personalTaxesDbContext.PersonalTaxes
                  .FirstOrDefault(personaltax => personaltax.Id == id);
        }

        public void Update(PersonalTax dbEntity, PersonalTax entity)
        {
            dbEntity.PostalCode = entity.PostalCode;
            dbEntity.TaxableIncome = entity.TaxableIncome;
            dbEntity.LogTime = DateTime.Now;
            _personalTaxesDbContext.SaveChanges();
        }

        public IEnumerable<string> GetTaxCodes()
        {
            return new List<string>()
            {
                TaxCodeTypes.FlatRate,
                TaxCodeTypes.FlatValue,
                TaxCodeTypes.ProgressiveA,
                TaxCodeTypes.PorgressiveB
            };
        }
    }
}
