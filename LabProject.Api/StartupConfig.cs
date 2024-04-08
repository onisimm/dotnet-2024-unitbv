using LabProject.Core.Services;
using LabProject.Database.Repositories;

namespace LabProject.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<TasksService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<TasksRepository>();
        }
    }
}
