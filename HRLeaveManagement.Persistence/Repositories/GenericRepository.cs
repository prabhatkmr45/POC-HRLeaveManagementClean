using HRLeaveManage.Application.Contract.Persistence;
using HRLeaveManagement.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HrDataBaseContext _hrDataBaseContext;
        public GenericRepository(HrDataBaseContext hrDataBaseContext)
        {
            this._hrDataBaseContext = hrDataBaseContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _hrDataBaseContext.AddAsync(entity);
            await _hrDataBaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _hrDataBaseContext.Remove(entity);
            await _hrDataBaseContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _hrDataBaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _hrDataBaseContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            // // _hrDataBaseContext.Update(entity);
            _hrDataBaseContext.Entry(entity).State = EntityState.Modified;
            await _hrDataBaseContext.SaveChangesAsync();
        }
    }
}
