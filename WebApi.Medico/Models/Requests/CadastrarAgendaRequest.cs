namespace WebApi.Medico.Models.Requests
{
    public class CadastrarAgendaRequest
    {
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
    }
}
