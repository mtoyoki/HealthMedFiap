using Core.Commands;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Commands.Medico.Handlers
{
    public class AceitarConsultaCommandHandler(IMedicoRepository medicoRepository, IConsultaMedicaRepository consultaRepository, IAgendaRepository agendaRepository) : ICommandHandler<AceitarConsultaCommand>
    {
        public CommandResult Handle(AceitarConsultaCommand command)
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

            consulta.Situacao = SituacaoConsultaMedica.Aceita;
            consultaRepository.Update(consulta);

            return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Consulta médica aceita (ConsultaMedicaId = {consulta.Id})");
        }
    }

}
