using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILoginTypeRepository, LoginTypeRepository>();
            services.AddScoped<IOwnerLoginRepository, OwnerLoginRepository>();
            services.AddScoped<IOwnerMasterRepository, OwnerMasterRepository>();
            return services;
        }
    }
}
