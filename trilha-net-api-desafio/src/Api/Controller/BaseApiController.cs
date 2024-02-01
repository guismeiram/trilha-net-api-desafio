using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.Sucess)
            {
                return Ok(result.Data);
            }

            return BadRequest(new { error = result.ErrorMessage });
        }
    }
}
