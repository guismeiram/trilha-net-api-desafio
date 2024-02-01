using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaStatus
{
    public class GetTarefaStatusQuery 
    {
        public class Query : IRequest<Result<IEnumerable<TarefaDto>>>
        {
            public EnumStatusTarefa Status { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<IEnumerable<TarefaDto>>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<IEnumerable<TarefaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tarefa = await _uow.TarefaRepository
                                        .GetWhere(x => x.Status == request.Status);

                return Result<IEnumerable<TarefaDto>>.Success(_mapper.Map<IEnumerable<TarefaDto>>(tarefa));

            }
        }
    }
}
