using System;
using System.Threading.Tasks;

namespace NajotTalim.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IGroupRepository GroupRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        Task SaveChangesAsync();
    }
}
