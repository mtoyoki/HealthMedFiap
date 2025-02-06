namespace Application.Commands.Paciente
{
    public class AutenticarPacienteCommand
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }

        public AutenticarPacienteCommand(string cpf, string senha)
        {
            Cpf = cpf;
            Senha = senha;
        }
    }
}
