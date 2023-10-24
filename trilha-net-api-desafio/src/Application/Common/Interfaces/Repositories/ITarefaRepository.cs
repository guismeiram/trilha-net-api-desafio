using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface ITarefaRepository : IRepository<Domain.Entities.Tarefa>
    {
        Task<IQueryable<Domain.Entities.Tarefa>> getStatus(EnumStatusTarefa statusTarefa);

        Task<IQueryable<Domain.Entities.Tarefa>> getData(DateTime date);
    }
}
