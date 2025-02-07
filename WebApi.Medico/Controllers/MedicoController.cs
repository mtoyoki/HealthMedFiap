using Application.Commands.Medico;
using Application.Queries.Medico;
using Application.Queries.Medico.Handlers;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Medico.Controllers
{

    [ApiController]
    [Route("api/medico")]
    [Authorize(Roles = "Medico")]
    public class MedicoController(
        ICommandHandler<CadastrarAgendaCommand> cadastrarAgendaCommandHandler,
        ICommandHandler<AceitarConsultaCommand> aceitarConsultaCommandHandler,
        ICommandHandler<RecusarConsultaCommand> recusarConsultaCommandHandler,
        IPesquisarConsultaMedicaQueryHandler pesquisarConsultaMedicaQueryHandler) : ControllerBase
    {
        protected string? UserId => User.Claims
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value)
            .FirstOrDefault();


        [HttpPost("agenda/cadastar")]
        public IActionResult CadastrarAgenda([FromBody] CadastrarAgendaCommand command)
        {
            if (command.Crm != UserId) return Unauthorized("[ERRO] CRM informado é diferente do CRM do usuário logado.");

            var result = cadastrarAgendaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpGet("consulta-medica/pesquisar")]
        public IActionResult PesquisarConsultaMedica([FromQuery] PesquisarConsultaMedicaQuery command)
        {
            if (command.Crm != UserId) return Unauthorized("[ERRO] CRM informado é diferente do CRM do usuário logado.");

            var result = pesquisarConsultaMedicaQueryHandler.GetByCrmAndSituacaoConsultaMedica(command).Result;

            return Ok(result);
        }

        [HttpPost("consulta-medica/aceitar")]
        public IActionResult AceitarConsulta([FromBody] AceitarConsultaCommand command)
        {
            if (command.Crm != UserId) return Unauthorized("[ERRO] CRM informado é diferente do CRM do usuário logado.");

            var result = aceitarConsultaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPost("consulta-medica/recusar")]
        public IActionResult RecusarConsulta([FromBody] RecusarConsultaCommand command)
        {
            if (command.Crm != UserId) return Unauthorized("[ERRO] CRM informado é diferente do CRM do usuário logado.");

            var result = recusarConsultaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpGet("roles")]
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