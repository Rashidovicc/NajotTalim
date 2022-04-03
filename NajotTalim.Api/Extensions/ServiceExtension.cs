using Microsoft.Extensions.DependencyInjection;
using NajotTalim.Data.IRepositories;
using NajotTalim.Data.Repositories;
using NajotTalim.Services.Interfaces;
using NajotTalim.Services.Services;

namespace NajotTalim.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IGroupService, GroupService>();

        }
    }
}
