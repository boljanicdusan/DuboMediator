using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Consts;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DuboMediator.Persistence.Repositories;

namespace DuboMediator.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DuboMediatorDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(AppConsts.DbConnectionName)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DuboMediatorDbContext>().AddDefaultTokenProviders();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILectureRepository, LectureRepository>();

            return services;
        }
    }
}