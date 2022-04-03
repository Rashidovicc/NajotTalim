using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;
using NajotTalim.Domain.Entities.Teachers;

namespace NajotTalim.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(NajotTalimDbContext context) : base(context)
        {
        }
    }
}
