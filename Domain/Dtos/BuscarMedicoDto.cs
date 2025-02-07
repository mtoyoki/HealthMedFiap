namespace Domain.Dtos
{
    public class BuscarMedicoDto
    {
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DescricaoEspecialidade { get; set; }
        public string CodigoEspecialidade { get; set; }
        
        public BuscarMedicoDto(string crm, string nome, string email, string codigoEspecialidade, string descricaoEspecialidade)
        {
            Crm = crm;
            Nome = nome;
            Email = email;
            CodigoEspecialidade = codigoEspecialidade;
            DescricaoEspecialidade = descricaoEspecialidade;
        }
    }
}