using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Commands.CreateTarefa
{
    public class CreateTarefaCommandValidator : AbstractValidator<CreateTarefaDto>
    {
        public CreateTarefaCommandValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty();
        }
    }
}
