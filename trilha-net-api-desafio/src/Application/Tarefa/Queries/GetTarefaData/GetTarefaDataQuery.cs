using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaData
{
    public class GetTarefaDataQuery 
    {
        public class Query : IRequest<Result<IEnumerable<TarefaDto>>>
        {
            public DateTime Data { get; set; }
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
                                        .AsQueryable(x => x.Data == request.Data)
                                        .ProjectTo<TarefaDto>(_mapper.ConfigurationProvider)
                                        .FirstOrDefaultAsync();

                return Result<IEnumerable<TarefaDto>>.Success(_mapper.Map<IEnumerable<TarefaDto>>(tarefa));
            }
        }
    }
}
