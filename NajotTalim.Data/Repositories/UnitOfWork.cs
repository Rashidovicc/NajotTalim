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
            this.Students = new StudentRepository(context);
            this.Teachers = new TeacherRepository(context);
            this.Groups = new GroupRepository(context);
        }
        public IStudentRepository Students { get; set; }

        public IGroupRepository Groups { get; set; }

        public ITeacherRepository Teachers { get; set; }

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
