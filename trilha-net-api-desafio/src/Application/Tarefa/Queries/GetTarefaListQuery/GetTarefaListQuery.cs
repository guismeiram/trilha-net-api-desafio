using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaListQuery
{
    public class GetTarefaListQuery
    {
        public class Query : IRequest<Result<PaginatedList<TarefaDto>>>
        {
            [FromQuery(Name = "pageNumber")]
            public int PageNumber { get; init; } = 1;

            [FromQuery(Name = "pageSize")]
            public int PageSize { get; init; } = 8;
        }

        public class Handler : IRequestHandler<Query, Result<PaginatedList<TarefaDto>>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            Task<Result<PaginatedList<TarefaDto>>> IRequestHandler<Query, Result<PaginatedList<TarefaDto>>>.Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
