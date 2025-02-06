namespace Application.Commands.Medico
{
    public class CadastrarAgendaCommand
    {
        public string Crm { get; set; }
        public DateTime DataHora { get; set; }

        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }
    }
}