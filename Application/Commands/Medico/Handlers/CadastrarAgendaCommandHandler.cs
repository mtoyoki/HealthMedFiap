using Core.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Commands.Medico.Handlers
{
    public class CadastrarAgendaCommandHandler(IMedicoRepository medicoRepository, IAgendaRepository agendaRepository) : ICommandHandler<CadastrarAgendaCommand>
    {
        public CommandResult Handle(CadastrarAgendaCommand command)
        {
            var medico = medicoRepository.GetMedicoByCrmAsync(command.Crm).Result;
            if (medico == null)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível encontrar médico." });
            }

            // Validação para garantir que somente a data e hora foram preenchidas
            if (command.DataHora.Minute != 0 || command.DataHora.Second != 0 || command.DataHora.Millisecond != 0)
            {
                return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] No campo dataHora, deixar zerado a parte dos minutos, segundos e milisegundos." });
            }

            var agenda = agendaRepository.GetByCrmAndDataHora(command.Crm, command.DataHora).Result;
            if (agenda != null)
            {
                agenda.Valor = command.Valor;
                agenda.Disponivel = command.Disponivel;
                agendaRepository.Update(agenda);

                return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Agenda atualizada (AgendaId = {agenda.Id})");
            }

            agenda = new Agenda()
            {
                MedicoId = medico.Id,
                DataHora = command.DataHora,
                Valor = command.Valor,
                Disponivel = command.Disponivel
            };
            agendaRepository.Insert(agenda);

            return CommandResultFactory.CreateSuccessResult($"[SUCESSO] Agenda incluída (AgendaId = {agenda.Id})");
        }
    }
}