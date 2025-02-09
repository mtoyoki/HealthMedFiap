using Application.Commands.Medico;
using Application.Queries.Medico;
using Application.Queries.Medico.Handlers;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Medico.Models.Requests;


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
        protected string IdentificacaoUsuarioLogin => User.Claims
            .Where(c => c.Type == ClaimTypes.NameIdentifier)
            .Select(c => c.Value)
            .First();


        [HttpPost("agenda/cadastar")]
        public IActionResult CadastrarAgenda([FromBody] CadastrarAgendaRequest request)
        {
            var command = new CadastrarAgendaCommand
            {
                Crm = IdentificacaoUsuarioLogin,
                DataHora = request.DataHora,
                Valor = request.Valor,
                Disponivel = request.Disponivel
            };

            var result = cadastrarAgendaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpGet("consulta-medica/pesquisar")]
        public IActionResult PesquisarConsultaMedica([FromQuery] PesquisarConsultaMedicaRequest request)
        {
            var query = new PesquisarConsultaMedicaQuery
            {
                Crm = IdentificacaoUsuarioLogin,
                Situacao = request.Situacao
            };

            var result = pesquisarConsultaMedicaQueryHandler.GetByCrmAndSituacaoConsultaMedica(query).Result;

            return Ok(result);
        }

        [HttpPost("consulta-medica/aceitar")]
        public IActionResult AceitarConsulta([FromBody] AceitarConsultaRequest request)
        {
            var command = new AceitarConsultaCommand
            {
                Crm = IdentificacaoUsuarioLogin,
                ConsultaMedicaId = request.ConsultaMedicaId
            };

            var result = aceitarConsultaCommandHandler.Handle(command);

            if (result.Success) return Ok(result.Message);

            return BadRequest(result.Errors);
        }

        [HttpPost("consulta-medica/recusar")]
        public IActionResult RecusarConsulta([FromBody] RecusarConsultaRequest request)
        {
            var command = new RecusarConsultaCommand
            {
                Crm = IdentificacaoUsuarioLogin,
                ConsultaMedicaId = request.ConsultaMedicaId,
                DisponibilizarAgenda = request.DisponibilizarAgenda
            };

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