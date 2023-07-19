using Microsoft.EntityFrameworkCore;
using Myportfolio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.EF.Repositories
{
    public class Base<T> : IBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Base(ApplicationDbContext context)
        {
           _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
