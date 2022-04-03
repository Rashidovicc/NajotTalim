using Microsoft.EntityFrameworkCore;
using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;

namespace NajotTalim.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private NajotTalimDbContext context;
        private DbSet<T> dbSet;
        public GenericRepository(NajotTalimDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}
