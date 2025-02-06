namespace Domain.Queries.Paciente
{
    public class PesquisarAgendaQueryResult
    {
        public int AgendaId { get; set; }
        public string Crm { get; set; }
        public string Nome { get; set; }
        public string DescricaoEspecialidade { get; set; }

        public DateTime DataHora { get; set; }

        public float Valor { get; set; }

        public bool Disponivel { get; set; }

        public PesquisarAgendaQueryResult(int agendaId, string crm, string nome, string descricaoEspecialidade, DateTime dataHora, float valor, bool disponivel)
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