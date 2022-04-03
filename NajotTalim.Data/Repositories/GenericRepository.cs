using Microsoft.EntityFrameworkCore;
using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Data.Repositories
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private NajotTalimDbContext context;
        private DbSet<T> dbSet;
        public GenericRepository(NajotTalimDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);

            if (entity is null)
                return false;

            dbSet.Remove(entity);

            return true;
        }


        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression is null ? dbSet : dbSet.Where(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entry = dbSet.Update(entity);

            return entry.Entity;
        }

    }
}
