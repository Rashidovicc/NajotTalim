using Microsoft.EntityFrameworkCore;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Domain.Entities.Students;
using NajotTalim.Domain.Entities.Teachers;

namespace NajotTalim.Data.Contexts
{
    public class NajotTalimDbContext : DbContext
    {
        public NajotTalimDbContext(DbContextOptions<NajotTalimDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }

    }
}
