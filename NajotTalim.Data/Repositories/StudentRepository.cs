using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;
using NajotTalim.Domain.Entities.Students;

namespace NajotTalim.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(NajotTalimDbContext context) : base(context)
        {
        }
    }
}
