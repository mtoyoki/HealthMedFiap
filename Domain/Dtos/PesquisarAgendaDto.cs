namespace Domain.Dtos
{
    public class PesquisarAgendaDto
    {
        public int AgendaId { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string DescricaoEspecialidade { get; set; }

        public DateTime DataHora { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        public PesquisarAgendaDto(int agendaId, string crm, string nome, string descricaoEspecialidade, DateTime dataHora, decimal valor, bool disponivel)
        {
            AgendaId = agendaId;
            Crm = crm;
            Nome = nome;
            DescricaoEspecialidade = descricaoEspecialidade;
            DataHora = dataHora;
            Valor = valor;
            Disponivel = disponivel;
        }
    }
}