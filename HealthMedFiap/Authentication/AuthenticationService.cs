using Core.Commands;
using Domain.Commands.Medico;
using Domain.Commands.Paciente;

namespace WebApi.Authentication
{
    public class AuthenticationService(
        ICommandHandler<AutenticarMedicoCommand> autenticarMedicoCommandHandler,
        ICommandHandler<AutenticarPacienteCommand> autenticarPacienteCommandHandler) : IAuthenticationService
    {

        public bool AuthenticateMedicoAsync(string crm, string senha)
        {
            var command = new AutenticarMedicoCommand(crm, senha);

            var result = autenticarMedicoCommandHandler.Handle(command);

            return result.Success;
        }

        public bool AuthenticatePacienteAsync(string cpfOuEmail, string senha)
        {
            {
                var command = new AutenticarPacienteCommand(cpfOuEmail, senha);

                var result = autenticarPacienteCommandHandler.Handle(command);

                return result.Success;
            }
        }

    }
}