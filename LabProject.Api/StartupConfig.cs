using LabProject.Core.Services;
using LabProject.Database.Context;
using LabProject.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<TasksService>();
            services.AddScoped<ProjectsService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<LabProjectDbContext>();
            services.AddScoped<DbContext, LabProjectDbContext>();

            services.AddScoped<TasksRepository>();
            services.AddScoped<ProjectsRepository>();
            services.AddScoped<UsersRepository>();
            services.AddScoped<UserProjectsRepository>();
        }
    }
}
