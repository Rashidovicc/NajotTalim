using AutoMapper;
using NajotTalim.Data.IRepositories;
using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Domain.Enums;
using NajotTalim.Services.DTOs;
using NajotTalim.Services.Extensions;
using NajotTalim.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<Group>> CreateAsync(GroupForCreation groupDto)
        {
            var response = new BaseResponse<Group>();
            var group = mapper.Map<Group>(groupDto);
            var createdGr = await unitOfWork.Groups.CreateAsync(group);
            await unitOfWork.SaveChangesAsync();

            response.Data = createdGr;
            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<bool>();
            var group = await unitOfWork.Groups.GetAsync(expression);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not Found");
            }
            group.Delete();

            await unitOfWork.Groups.UpdateAsync(group);
            await unitOfWork.SaveChangesAsync();

            response.Data = true;
            return response;

        }

        public async Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Group>>();
            var group = await unitOfWork.Groups.GetAllAsync(expression);
            response.Data = group.ToPagedList(@params);
            return response;
        }

        public async Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression)
        {
            var response = new BaseResponse<Group>();
            var group = await unitOfWork.Groups.GetAsync(expression);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not Found");
                return response;
            }
            response.Data = group;
            return response;
        }

        public async Task<BaseResponse<Group>> UpdateAsync(Guid id, GroupForUpdating groupDto)
        {
            var response = new BaseResponse<Group>();
            var group = await unitOfWork.Groups.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }


            group.Name = groupDto.Name;
            group.Price = groupDto.Price;
            group.Duration = groupDto.Duration;
            group.Update();

            var updatedGroup = await unitOfWork.Groups.UpdateAsync(group);

            await unitOfWork.SaveChangesAsync();

            response.Data = updatedGroup;
            return response;

        }
    }
}
