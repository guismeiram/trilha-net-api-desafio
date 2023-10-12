using Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ITarefaRepository TarefaRepository { get; }

        Task<bool> Complete();
    }
}
