using Core.Commands;
using Domain.Commands.Medico;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Commands.Medico
{
    public class CadastrarAgendaCommandHandler(IMedicoRepository medicoRepository) : ICommandHandler<CadastrarAgendaCommand>
    {
        public CommandResult Handle(CadastrarAgendaCommand command)
        {
            //var medico = medicoRepository.GetMedicoByCrm(command.Crm);
            //if (medico != null)
            //{
            //    medico.HorariosDisponiveis.Add(new HorarioDisponivel { DataHora = command.DataHora });
            //    medicoRepository.Update(medico);
            //    return CommandResultFactory.CreateSuccessResult("Horário atualizado");
            //}
            return CommandResultFactory.CreateErrorResult(new List<string>() { "Médico não encontrado" });
        }
    }

}
