﻿using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefa
{
    public class GetTarefaQuery
    {
        public class Query : IRequest<Result<TarefaDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TarefaDto>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<TarefaDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tarefa = await _uow
                    .TarefaRepository.Get(request.Id);

                return Result<TarefaDto>.Success(_mapper.Map<TarefaDto>(tarefa));
            }
        }
    }
}
