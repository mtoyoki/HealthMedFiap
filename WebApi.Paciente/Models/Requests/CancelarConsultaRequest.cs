namespace WebApi.Paciente.Models.Requests
{
    public class CancelarConsultaRequest
    {
        public int ConsultaId { get; set; }
        public string Justificativa { get; set; }
    }
}
