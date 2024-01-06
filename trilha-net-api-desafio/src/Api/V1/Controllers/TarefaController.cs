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
        
    }
}
