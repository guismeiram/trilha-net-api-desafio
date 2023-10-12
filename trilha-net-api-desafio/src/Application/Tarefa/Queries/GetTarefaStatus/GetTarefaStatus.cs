using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tarefa.Queries.GetTarefaStatus
{
    public class GetTarefaStatus 
    {
        public class Query : IRequest<Result<List<TarefaDto>>>
        {
            public string SearchQuery { get; set; }
        }


    }
}
