namespace Domain.Queries.Paciente
{
    public class BuscarMedicoQueryResult
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Crm { get; set; }
        public string DescricaoEspecialidade { get; set; }

        public BuscarMedicoQueryResult(string nome, string email, string crm, string descricaoEspecialidade)
        {
            Nome = nome;
            Email = email;
            Crm = crm;
            DescricaoEspecialidade = descricaoEspecialidade;
        }
    }
}