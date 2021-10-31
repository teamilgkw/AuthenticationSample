using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationSample.BackEnd.DataAccess;
using AuthenticationSample.BackEnd.BusinessLogic.Abstraction.Repositories;

namespace AuthenticationSample.BackEnd.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            /*
            services.AddScoped<ILoginTypeRepository, LoginTypeRepository>();
            */
            services.AddScoped<IOwnerLoginRepository, OwnerLoginRepository>();
            services.AddScoped<IOwnerMasterRepository, OwnerMasterRepository>();
            return services;
        }
    }
}
