using Api.Controller;
using Application.Tarefa.Commands.CreateTarefa;
using Application.Tarefa.Commands.DeleteTarefa;
using Application.Tarefa.Commands.UpdateTarefa;
using Application.Tarefa.Queries.GetTarefa;
using Application.Tarefa.Queries.GetTarefaListQuery;
using Application.Tarefa.Queries.GetTarefaTitulo;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetTarefaListQuery.Query query)
        {
            var tarefas = await Mediator.Send(query);

            return HandleResult(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var tarefa = await Mediator.Send(new GetTarefaQuery.Query { Id = id });

            return HandleResult(tarefa);
        }

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
            var tarefa = await Mediator.Send(new DeleteTarefaCommand.Command { Id = id });

            return HandleResult(tarefa);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string query)
        {
            var results = await Mediator.Send(new GetTarefaTitulo.Query { SearchQuery = query });

            return HandleResult(results);
        }

    }
}
