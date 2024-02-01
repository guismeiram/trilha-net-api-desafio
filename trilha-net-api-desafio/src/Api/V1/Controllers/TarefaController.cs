using Api.Controller;
using Application.Tarefa.Commands.CreateTarefa;
using Application.Tarefa.Commands.DeleteTarefa;
using Application.Tarefa.Commands.UpdateTarefa;
using Application.Tarefa.Queries.GetTarefa;
using Application.Tarefa.Queries.GetTarefaData;
using Application.Tarefa.Queries.GetTarefaList;
using Application.Tarefa.Queries.GetTarefaStatus;
using Application.Tarefa.Queries.GetTarefaTitulo;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Api.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateTarefaDto tarefa)
        {
            var result = await Mediator.Send(new CreateTarefaCommand.Command { Tarefa = tarefa });

            return HandleResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTarefaDto tarefa)
        {
            var result = await Mediator.Send(new UpdateTarefaCommand.Command { Tarefa = tarefa});

            return HandleResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeleteTarefaCommand.Command { Id = id });

            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetTarefaQuery.Query { Id = id });


            return HandleResult(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetTarefaListQuery.Query());

            return HandleResult(result);
        }

        [HttpGet("Titulo")]
        public async Task<IActionResult> GetTitulo(String titulo)
        {
            var result = await Mediator.Send(new GetTarefaTituloQuery.Query { Titulo = titulo });

            return HandleResult(result);
        }

        [HttpGet("Data")]
        public async Task<IActionResult> GetData(DateTime date)
        {
            var result = await Mediator.Send(new GetTarefaDataQuery.Query { Data =  date});

            return HandleResult(result);
        }


        //mudar variavel status para int, se ocorrer erro, na dto, no parametro, e dentro da classe CommandStatus
        [HttpGet("Status")]
        public async Task<IActionResult> GetStatus(EnumStatusTarefa status)
        {
            var result = await Mediator.Send(new GetTarefaStatusQuery.Query { Status = status });

            return HandleResult(result);
        }
    }
}
