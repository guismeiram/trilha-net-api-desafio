using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaList
{
    public class GetTarefaListQuery
    {
        public class Query : IRequest<Result<IEnumerable<TarefaDto>>>
        {

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
                var tarefa = await _uow.TarefaRepository.GetAll();

                return Result<IEnumerable<TarefaDto>>.Success(_mapper.Map<IEnumerable<TarefaDto>>(tarefa));
            }
        }
    }
}
