namespace Domain.Commands.Paciente
{
    public class CancelarConsultaCommand
    {
        public string Cpf { get; set; }

        public int ConsultaMedicaId { get; set; }

        public string Justificativa { get; set; }
    }
}
