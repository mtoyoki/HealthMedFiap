namespace Domain.Dtos
{
    public class PesquisarConsultaMedicaDto
    {
        public int ConsultaId { get; set; }
        public string NomePaciente { get; set; }
        public string EmailPaciente { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public string DescricaoSituacao { get; set; }

        public PesquisarConsultaMedicaDto(int consultaId, string nomePaciente, string emailPaciente, DateTime dataHora, decimal valor, string descricaoSituacao)
        {
            ConsultaId = consultaId;
            NomePaciente = nomePaciente;
            EmailPaciente = emailPaciente;
            DataHora = dataHora;
            Valor = valor;
            DescricaoSituacao = descricaoSituacao;
        }
    }
}