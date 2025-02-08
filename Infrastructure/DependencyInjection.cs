﻿using Domain.Repositories.Common;
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
using Application.DTOs.Config;
using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;

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

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUser, CurrentUser>();

            return services;
        }


        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUserFileRepository, UserFileRepository>();
            //services.AddScoped<IFileShareRepository, FileShareRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            TypeAdapterConfig.GlobalSettings.Scan(typeof(MappingConfig).Assembly);


            //services.AddScoped<IUserFileService, UserFileService>();
            //services.AddScoped<IFileShareService, FileShareService>();

            return services;
        }
    }
}
