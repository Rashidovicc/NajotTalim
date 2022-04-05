using Microsoft.AspNetCore.Mvc;
using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Domain.Enums;
using NajotTalim.Services.DTOs;
using NajotTalim.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NajotTalim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private IGroupService groupService;
        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Group>>> Create(GroupForCreation group)
        {
            var res = await groupService.CreateAsync(group);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Group>>> Get([FromRoute] Guid id)
        {
            var res = await groupService.GetAsync(p => p.Id == id);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }

        [HttpGet]

        public async Task<ActionResult<BaseResponse<IEnumerable<Group>>>> GetGroups([FromQuery] PaginationParams @params)
        {
            var res = await groupService.GetAllAsync(@params);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Group>>> Update(Guid id, [FromForm] GroupForUpdating groupdto)
        {
            var res = await groupService.UpdateAsync(id, groupdto);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var res = await groupService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }

    }
}
