using Core.Commands;
using Domain.Repositories;

namespace Application.Commands.Paciente.Handlers
{
    public class AutenticarPacienteCommandHandler(IPacienteRepository pacienteRepository) : ICommandHandler<AutenticarPacienteCommand>
    {
        public CommandResult Handle(AutenticarPacienteCommand command)
        {
            var paciente = pacienteRepository.GetPacienteByEmailOrCpf(command.Cpf).Result;
            if (paciente != null && paciente.VerificarSenha(command.Senha))
            {
                return CommandResultFactory.CreateSuccessResult("[SUCESSO] Paciente autenticado");
            }

            return CommandResultFactory.CreateErrorResult(new List<string>() { "[ERRO] Não foi possível autenticar paciente." });
        }
    }
}