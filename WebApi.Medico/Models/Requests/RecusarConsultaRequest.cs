namespace WebApi.Medico.Models.Requests
{
    public class RecusarConsultaRequest
    {
        public int ConsultaMedicaId { get; set; }
        public bool DisponibilizarAgenda { get; set; }
    }
}
