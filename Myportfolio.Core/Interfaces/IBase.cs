using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.Core.Interfaces
{
    public interface IBase<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
