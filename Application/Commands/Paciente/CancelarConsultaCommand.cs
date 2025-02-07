namespace Application.Commands.Paciente
{
    public class CancelarConsultaCommand
    {
        public string EmailOrCpf { get; set; }

        public int ConsultaMedicaId { get; set; }

        public string Justificativa { get; set; }
    }
}
