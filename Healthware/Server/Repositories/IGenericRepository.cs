using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Healthware.Shared;

namespace Healthware.Server.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add<T>(T entity);
        Task Update<T>(T entity);
        Task Delete(int id);
    }
}
