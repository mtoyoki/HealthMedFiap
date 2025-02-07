using Core.Commands;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Commands.Paciente.Handlers
{
    public class AgendarConsultaCommandHandler(IPacienteRepository pacienteRepository, IAgendaRepository agendaRepository, IConsultaMedicaRepository consultaRepository) : ICommandHandler<AgendarConsultaCommand>
    {

        public CommandResult Handle(AgendarConsultaCommand command)
        {
            var paciente = pacienteRepository.GetPacienteByEmailOrCpf(command.EmailOrCpf).Result;
            if (paciente == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar paciente." });
            }

            var agenda = agendaRepository.GetById(command.AgendaId);
            if (agenda == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar agenda." });
            }

            agenda.Disponivel = false;
            agendaRepository.Update(agenda);

            var consulta = new ConsultaMedica
            {
                AgendaId = agenda.Id,
                PacienteId = paciente.Id,
                Situacao = SituacaoConsultaMedica.Agendada
            };

            consultaRepository.Insert(consulta);

            return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Consulta agendada (ConsultaMedicaId = {consulta.Id})");
        }
    }
}