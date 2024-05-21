using LabProject.Core.Services;
using LabProject.Database.Context;
using LabProject.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LabProject.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<TasksService>();
            services.AddScoped<ProjectsService>();
            services.AddScoped<UsersService>();
            services.AddScoped<AuthService>();
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

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab project API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        }, new List<string>()
                    }
                });
            });
        }

    }
}
