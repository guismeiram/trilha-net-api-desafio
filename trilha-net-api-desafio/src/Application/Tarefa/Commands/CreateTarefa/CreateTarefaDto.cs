using Application.Common.Mappings;
using AutoMapper;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Commands.CreateTarefa
{
    public class CreateTarefaDto : IMapFrom<Domain.Entities.Tarefa>
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTarefaDto, Domain.Entities.Tarefa>()
                .ReverseMap();
        }
    }
}
