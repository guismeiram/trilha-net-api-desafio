using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enum;
using Infra.Context;
using Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IQueryable<Tarefa>> getData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Tarefa>> getStatus(EnumStatusTarefa statusTarefa)
        {
            throw new NotImplementedException();
        }

        /* public async Task<IQueryable<Tarefa>> getData(DateTime date)
         {
             //var tarefa = await _context.Tarefas.Where(x => x.Data.Date == date.Date);

             return tarefa;
         }

         public async Task<Tarefa> getStatus(EnumStatusTarefa statusTarefa)
         {
             //return _context.Tarefas.Where(x => x.Status == statusTarefa);

         }*/
    }
}
