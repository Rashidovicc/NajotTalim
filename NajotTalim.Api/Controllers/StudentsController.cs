using Microsoft.AspNetCore.Mvc;
using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Students;
using NajotTalim.Domain.Enums;
using NajotTalim.Services.DTOs;
using NajotTalim.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NajotTalim.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Student>>> Create([FromForm] StudentForCreation studentDto)
        {
            var result = await studentService.CreateAsync(studentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Student>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await studentService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Get([FromRoute] Guid id)
        {
            var result = await studentService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Student>>> Update(Guid id, [FromForm] StudentForUpdating studentDto)
        {
            var result = await studentService.UpdateAsync(id, studentDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await studentService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
        [HttpPatch]

        public async Task<ActionResult<BaseResponse<Student>>> UpdateGroup([FromQuery]Guid id, [FromQuery]Guid groupId)
        {
            var res = await studentService.UpdateGroup(id, groupId);

            return StatusCode(res.Code ?? res.Error.Code.Value, res);
        }
    }
}
