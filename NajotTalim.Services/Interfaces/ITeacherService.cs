using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Teachers;
using NajotTalim.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Services.Interfaces

{
    public interface ITeacherService
    {
        Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreation teacherDto);
        Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<Teacher>> UpdateAsync(Guid id, TeacherForCreation teacherDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
