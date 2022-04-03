using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;
using System;
using System.Threading.Tasks;

namespace NajotTalim.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NajotTalimDbContext context;
        public UnitOfWork(NajotTalimDbContext context)
        {
            this.context = context;
        }
        public IStudentRepository StudentRepository { get; set; }

        public IGroupRepository GroupRepository { get; set; }

        public ITeacherRepository TeacherRepository { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
