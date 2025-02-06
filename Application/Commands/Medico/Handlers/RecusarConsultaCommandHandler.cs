using Core.Commands;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Commands.Medico.Handlers
{
    public class RecusarConsultaCommandHandler(IMedicoRepository medicoRepository, IConsultaMedicaRepository consultaRepository, IAgendaRepository agendaRepository) : ICommandHandler<RecusarConsultaCommand>

    {
        public CommandResult Handle(RecusarConsultaCommand command)
        {
            var medico = medicoRepository.GetMedicoByCrmAsync(command.Crm).Result;
            if (medico == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar médico." });
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

            if (agenda.MedicoId != medico.Id)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Médico não é responsável por essa consulta." });
            }

            if (command.DisponibilizarAgenda)
            {
                agenda.Disponivel = true;
                agendaRepository.Update(agenda);
            }

            consulta.Situacao = SituacaoConsultaMedica.Recusada;
            consultaRepository.Update(consulta);

            return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Consulta médica recusada (ConsultaMedicaId = {consulta.Id})");
        }
    }
}