using Domain.Enums;

namespace WebApi.Medico.Models.Requests
{
    public class PesquisarConsultaMedicaRequest
    {
        public SituacaoConsultaMedica? Situacao { get; set; }
    }
}
