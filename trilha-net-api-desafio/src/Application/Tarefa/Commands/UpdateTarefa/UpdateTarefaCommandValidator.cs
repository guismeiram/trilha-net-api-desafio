using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Commands.UpdateTarefa
{
    public class UpdateTarefaCommandValidator : AbstractValidator<UpdateTarefaDto>
    {
        public UpdateTarefaCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty();
        }
    }
}
