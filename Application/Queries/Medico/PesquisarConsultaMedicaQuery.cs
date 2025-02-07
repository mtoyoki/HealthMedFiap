using Domain.Enums;

namespace Application.Queries.Medico
{
    public class PesquisarConsultaMedicaQuery
    {
        public string Crm { get; set; }

        public SituacaoConsultaMedica? Situacao { get; set; }
    }
}