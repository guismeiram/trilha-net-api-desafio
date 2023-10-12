using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaTitulo
{
    public class GetTarefaTitulo
    {
        public class Query : IRequest<Result<List<TarefaDto>>>
        {
            public string SearchQuery { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<TarefaDto>>>
        {
            private readonly IUnitOfWork _uow;

            public Handler(IUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<Result<List<TarefaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(request.SearchQuery))
                {
                    return Result<List<TarefaDto>>.Success(new List<TarefaDto>());
                }

                var searchQuery = request
                    .SearchQuery
                    .ToLower()
                    .Trim();

                var results = await _uow
                    .TarefaRepository
                    .AsQueryable(x => x.Titulo.ToLower().Contains(searchQuery))
                    .Select(x => new TarefaDto
                    {
                        Id = Guid.NewGuid(),
                        Titulo = x.Titulo,
                        Data = x.Data,
                        Status = x.Status,
                    })
                    .Take(6)
                    .ToListAsync(cancellationToken: cancellationToken);

                return Result<List<TarefaDto>>.Success(results);

                /*public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }*/
            }
        }
    }
}
