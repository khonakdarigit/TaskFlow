using Domain.Repositories.Common;
using Domain.Repositories;
using Infrastructure.Repositories.Common;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interface;
using Infrastructure.Services;
using Application.Services;
using Application.Mappings;
using Application.Mappings.Project;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                  ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }


        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUser, CurrentUser>();


            services.AddAutoMapper(typeof(ApplicationUserProfile));
            services.AddAutoMapper(typeof(AttachmentProfile));
            services.AddAutoMapper(typeof(AuditProfile));
            services.AddAutoMapper(typeof(CommentProfile));
            services.AddAutoMapper(typeof(LogProfile));
            services.AddAutoMapper(typeof(NotificationProfile));
            services.AddAutoMapper(typeof(ProjectProfile));
            services.AddAutoMapper(typeof(TaskItemProfile));
            services.AddAutoMapper(typeof(ProjectWithTaskCountProfile));

            //services.AddSingleton(config =>
            //{
            //    var configTa = new TypeAdapterConfig();
            //    configTa.Scan(Assembly.GetExecutingAssembly());

            //    return configTa;
            //});

            //services.AddScoped<IMapper, ServiceMapper>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();


            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskItemService, TaskItemService>();

            return services;
        }
    }
}
