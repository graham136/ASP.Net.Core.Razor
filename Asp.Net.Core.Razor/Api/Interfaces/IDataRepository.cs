using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.Core.Razor.Api.Interfaces
{
    /// <summary>
    /// Standard Interface for data access. Get Tax Codes is not used, but it is a good idea to put in one place.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<string> GetTaxCodes();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
