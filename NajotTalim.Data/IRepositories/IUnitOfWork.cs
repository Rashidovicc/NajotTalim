using System;
using System.Threading.Tasks;

namespace NajotTalim.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        IGroupRepository Groups { get; }
        ITeacherRepository Teachers { get; }
        Task SaveChangesAsync();
    }
}
