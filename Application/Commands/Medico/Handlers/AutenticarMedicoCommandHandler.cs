using System.Net.Mail;
using Core.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Commands.Medico.Handlers
{
    public class AutenticarMedicoCommandHandler(IMedicoRepository medicoRepository) : ICommandHandler<AutenticarMedicoCommand>
    {
        public CommandResult Handle(AutenticarMedicoCommand command)
        {
            var medico = medicoRepository.GetMedicoByCrmAsync(command.Crm).Result;
            if (medico != null && medico.VerificarSenha(command.Senha))
            {
                return CommandResultFactory.CreateSuccessResult("[SUCESSO] Médico autenticado");
            }

            return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível autenticar médico." });
        }
    }

}
