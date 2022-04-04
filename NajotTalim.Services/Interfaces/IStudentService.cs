using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Students;
using NajotTalim.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Services.Interfaces
{
    public interface IStudentService
    {

        Task<BaseResponse<Student>> CreateAsync(StudentForCreation studentDto);
        Task<BaseResponse<Student>> GetAsync(Expression<Func<Student, bool>> expression);
        Task<BaseResponse<IEnumerable<Student>>> GetAllAsync(PaginationParams @params, Expression<Func<Student, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Student, bool>> expression);
        Task<BaseResponse<Student>> UpdateAsync(Guid id, StudentForCreation studentDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
