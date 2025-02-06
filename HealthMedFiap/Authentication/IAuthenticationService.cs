namespace WebApi.Authentication
{
    public interface IAuthenticationService
    {
        bool AuthenticateMedicoAsync(string crm, string senha);
        bool AuthenticatePacienteAsync(string cpfOuEmail, string senha);
    }

}
