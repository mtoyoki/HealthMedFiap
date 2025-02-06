using Core.Commands;
using Domain.Commands.Paciente;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Commands.Paciente
{
    public class CancelarConsultaCommandHandler(IPacienteRepository pacienteRepository, IAgendaRepository agendaRepository, IConsultaMedicaRepository consultaRepository) : ICommandHandler<CancelarConsultaCommand>
    {

        public CommandResult Handle(CancelarConsultaCommand command)
        {
            var paciente = pacienteRepository.GetPacienteByEmailOrCpf(command.Cpf).Result;
            if (paciente == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar paciente." });
            }

            var consulta = consultaRepository.GetById(command.ConsultaMedicaId);
            if (consulta == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar consulta médica." });
            }

            var agenda = agendaRepository.GetById(consulta.AgendaId);
            if (agenda == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar agenda." });
            }

            agenda.Disponivel = true;
            agendaRepository.Update(agenda);

            consulta.Situacao = SituacaoConsultaMedica.Cancelada;
            consulta.JustificativaSituacao = command.Justificativa;
            consultaRepository.Update(consulta);


            return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Consulta cancelada. ConsultaMedicaId = {consulta.Id}");
        }
    }
}