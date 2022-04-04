using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Services.Interfaces
{
    public interface IGroupService
    {
        Task<BaseResponse<Group>> CreateAsync(GroupForCreation groupDto);
        Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression);
        Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Group, bool>> expression);
        Task<BaseResponse<Group>> UpdateAsync(Guid id, GroupForUpdating groupDto);
    }
}
