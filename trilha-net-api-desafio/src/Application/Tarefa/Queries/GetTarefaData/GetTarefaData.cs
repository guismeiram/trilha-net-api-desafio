using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaData
{
    public class GetTarefaData 
    {
        public class Query : IRequest<Result<TarefaDto>>
        {
            public Domain.Entities.Tarefa? Tarefa { get; set; }
        }

        /*public class Handler : IRequestHandler<Query, Result<List<TarefaDto>>>
        {
            private readonly ITarefaRepository _tarefaRepository;
            private readonly IMapper _mapper;

            public Handler(ITarefaRepository cartRepository, IMapper mapper)
            {
                _tarefaRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<TarefaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tarefa = _mapper.Map<Domain.Entities.Tarefa>(request.Tarefa);

                var data = _tarefaRepository.getData(tarefa.Data);


                return Result<List<TarefaDto>>.Success(_mapper.Map<List<TarefaDto>>(data));
            }
        }*/
    }
}
