using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.Services
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<EmailService>();
            services.AddScoped<OtpService>();
            return services;
        }
    }
}
