using AdaTech.Application.Requests;
using AdaTech.Application.UseCases;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AdaTech.Api.Controllers
{
    [ApiController]
    [Route("api/alunos")]
    [Produces("application/json")]
    [ExcludeFromCodeCoverage]
    [Authorize]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca todos os alunos
        /// </summary>
        /// <response code="200">Lista de alunos</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new BuscarTodosAlunosRequest { });

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
        }

        /// <summary>
        /// Cria um aluno
        /// </summary>
        /// <response code="200">Lista de alunos</response>
        /// <response code="400">Validação ocorrida</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CriarAlunoRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response.Data);
        }
    }
}
