using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Commands.UpdateTarefa
{
    public class UpdateTarefaCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdateTarefaDto Tarefa { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Tarefa).SetValidator(new UpdateTarefaCommandValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var tarefa = _mapper.Map<Domain.Entities.Tarefa>(request.Tarefa);

                await _uow.TarefaRepository.UpdateAsync(tarefa);

                var result = await _uow.Complete();

                if (result) return Result<Unit>.Success(Unit.Value);

                return Result<Unit>.Failure("Failed to update tarefa");
            }
        }
    }
}
