using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NajotTalim.Data.IRepositories;
using NajotTalim.Domain.Commons;
using NajotTalim.Domain.Configurations;
using NajotTalim.Domain.Entities.Teachers;
using NajotTalim.Domain.Enums;
using NajotTalim.Services.DTOs;
using NajotTalim.Services.Extensions;
using NajotTalim.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NajotTalim.Services.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public async Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreation teacherDto)
        {
            var response = new BaseResponse<Teacher>();                 

           
            var mappedTeacher = mapper.Map<Teacher>(teacherDto);

            // save image from dto model to wwwroot
            mappedTeacher.Image = await SaveFileAsync(teacherDto.Image.OpenReadStream(), teacherDto.Image.FileName);

            var result = await unitOfWork.Teachers.CreateAsync(mappedTeacher);

            result.Image = "https://localhost:5001/Images/" + result.Image;

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            var existTeacher = await unitOfWork.Teachers.GetAsync(expression);
            if (existTeacher is null)
            {
                response.Error = new ErrorResponse(404, "Teacher not found");
                return response;
            }
            existTeacher.Delete();

            var result = await unitOfWork.Teachers.UpdateAsync(existTeacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null)
        {

            var response = new BaseResponse<IEnumerable<Teacher>>();

            var teachers = await unitOfWork.Teachers.GetAllAsync(expression);

            response.Data = teachers.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression)
        {
            var response = new BaseResponse<Teacher>();

            var teacher = await unitOfWork.Teachers.GetAsync(expression);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "Teacher not found");
                return response;
            }

            response.Data = teacher;

            return response;
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }

        public async Task<BaseResponse<Teacher>> UpdateAsync(Guid id, TeacherForCreation teacherDto)
        {
            var response = new BaseResponse<Teacher>();

            var teacher = await unitOfWork.Teachers.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (teacher is null)
            {
                response.Error = new ErrorResponse(404, "Teacher not found");
                return response;
            }

            // check for exist group
            var group = await unitOfWork.Groups.GetAsync(p => p.Id == teacherDto.GroupId);
            if (group is null)
            {
                response.Error = new ErrorResponse(404, "Group not found");
                return response;
            }

            teacher.FirstName = teacherDto.FirstName;
            teacher.LastName = teacherDto.LastName;
            teacher.GroupId = teacherDto.GroupId;
            teacher.Update();

            var result = await unitOfWork.Teachers.UpdateAsync(teacher);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
