using AutoMapper;
using NajotTalim.Domain.Entities.Groups;
using NajotTalim.Domain.Entities.Students;
using NajotTalim.Domain.Entities.Teachers;
using NajotTalim.Services.DTOs;

namespace NajotTalim.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentForCreation, Student>().ReverseMap();
            CreateMap<TeacherForCreation, Teacher>().ReverseMap();
            CreateMap<GroupForCreation, Group>().ReverseMap();
        }
    }
}
