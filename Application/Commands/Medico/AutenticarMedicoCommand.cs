namespace Application.Commands.Medico
{
    public class AutenticarMedicoCommand
    {
        public string Crm { get; set; }
        public string Senha { get; set; }

        public AutenticarMedicoCommand(string crm, string senha)
        {
            Crm = crm;
            Senha = senha;
        }
    }
}
