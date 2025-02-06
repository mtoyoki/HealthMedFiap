using Core.Commands;
using Domain.Commands.Medico;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Commands.Medico
{
    public class AutenticarMedicoCommandHandler(IMedicoRepository medicoRepository) : ICommandHandler<AutenticarMedicoCommand>
    {
        public CommandResult Handle(AutenticarMedicoCommand command)
        {
            var medico = medicoRepository.GetMedicoByCrm(command.Crm).Result;
            if (medico != null && medico.Senha == command.Senha)
            {
                return CommandResultFactory.CreateSuccessResult("[SUCESSO] Médico autenticado");
            }

            return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível autenticar médico." });
        }
    }

}
