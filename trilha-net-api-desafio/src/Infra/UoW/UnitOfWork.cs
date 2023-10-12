using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Infra.Context;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ITarefaRepository TarefaRepository => new TarefaRepository(_context);

        public async Task<bool> Complete()
            => await _context.SaveChangesAsync() > 0;

        public async ValueTask DisposeAsync()
            => await _context.DisposeAsync();
    }
}
