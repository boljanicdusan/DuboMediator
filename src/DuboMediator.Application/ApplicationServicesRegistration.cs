using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Identity;
using DuboMediator.Application.Sessions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DuboMediator.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<AppSession>();

            return services;
        }
    }
}