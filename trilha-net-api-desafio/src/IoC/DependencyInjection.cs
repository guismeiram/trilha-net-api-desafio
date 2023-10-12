using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Infra.UoW;
using Infra.Repository.Base;
using Infra.Service;
using Application.Common.Interfaces.Repositories;
using Infra.Repository;
using FluentValidation;
using Application.Tarefa.Queries.GetTarefaListQuery;

namespace IoC
{
    public static class DependencyInjection
    {
      
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
         {
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
                //services.AddMediatR(typeof(GetTarefaListQuery.Handler).Assembly);
                services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

                return services;
         }

            public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
            {
                var connectionString = config.GetConnectionString("DefaultConnection");

                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

                services.AddTransient<IDateTime, DateTimeService>();


                services.AddTransient<ITarefaRepository, TarefaRepository>();

                return services;
            }
        
    }
}