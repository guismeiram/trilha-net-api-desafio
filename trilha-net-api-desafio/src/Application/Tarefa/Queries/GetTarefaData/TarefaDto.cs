using Application.Common.Mappings;
using AutoMapper;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaData
{
    public class TarefaDto : IMapFrom<Domain.Entities.Tarefa>
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Tarefa, TarefaDto>()
                    .ReverseMap();
        }
    }
}
