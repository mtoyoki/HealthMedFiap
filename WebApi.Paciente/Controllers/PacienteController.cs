using System.Security.Claims;
using Application.Commands.Paciente;
using Application.Queries.Paciente;
using Application.Queries.Paciente.Handlers;
using Core.Commands;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Paciente.Controllers
{

    [ApiController]
    [Route("api/paciente")]
    [Authorize(Roles = "Paciente")]
    public class PacienteController(
        ICommandHandler<AgendarConsultaCommand> agendarConsultaCommandHandler,
        ICommandHandler<CancelarConsultaCommand> cancelarConsultaCommandHandler,
        IBuscarMedicoQueryHandler buscarMedicoQueryHandler,
        IPesquisarAgendaQueryHandler pesquisarAgendaQueryHandler) : ControllerBase
    {
        protected string? UserId => User.Claims
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value)
            .FirstOrDefault();

        [HttpGet("medicos/buscar")]
        public IActionResult BuscarMedicos([FromQuery] BuscarMedicoQuery query)
        {
            IEnumerable<BuscarMedicoDto> result;

            if (!string.IsNullOrWhiteSpace(query.CodigoEspecialidade))
            {
                result = buscarMedicoQueryHandler.GetByCodigoEspecialidadeAsync(query.CodigoEspecialidade).Result;
            }
            else
            {
                result = buscarMedicoQueryHandler.GetTodosAsync().Result;
            }

            return Ok(result);
        }

        [HttpGet("agenda/pesquisar")]
        public IActionResult PesquisarAgenda([FromQuery] PesquisarAgendaQuery query)
        {
            var result = pesquisarAgendaQueryHandler.GetByCrm(query.Crm).Result;
            return Ok(result);
        }

        [HttpPost("consulta-medica/agendar")]
        public IActionResult AgendarConsultaMedica([FromBody] AgendarConsultaCommand command)
        {
            if (command.Cpf != UserId) return Unauthorized("[ERRO] CPF informado é diferente do CPF do usuário logado.");

            var result = agendarConsultaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPost("consulta-medica/cancelar")]
        public IActionResult CancelarConsultaMedica([FromBody] CancelarConsultaCommand command)
        {
            if (command.Cpf != UserId) return Unauthorized("[ERRO] CPF informado é diferente do CPF do usuário logado.");

            var result = cancelarConsultaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }


        [HttpGet("perfil")]
        public IActionResult GetUserRoles()
        {
            var roles = User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return Ok(roles);
        }
    }
}