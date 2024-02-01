using Application.Tarefa.Commands.CreateTarefa;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);


            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(CreatePacienteCommand.Command).GetTypeInfo().Assembly));
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(CreateTarefaCommand.Command).GetTypeInfo().Assembly));
            // services.AddMediatR(cf => cf.
            //AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
