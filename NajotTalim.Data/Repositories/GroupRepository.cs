using NajotTalim.Data.Contexts;
using NajotTalim.Data.IRepositories;
using NajotTalim.Domain.Entities.Groups;

namespace NajotTalim.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(NajotTalimDbContext context) : base(context)
        {
        }
    }
}
