using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Infra.Repository;
using Infra.Repository.Base;
using Infra.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ITarefaRepository, TarefaRepository>();


            return services;
        }
    }
}
