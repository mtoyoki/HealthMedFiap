using Core.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class ConsultaMedica : BaseEntity
    {
        public int AgendaId { get; set; }
        public int PacienteId { get; set; }

        public SituacaoConsultaMedica Situacao { get; set; }
        public string JustificativaSituacao { get; set; }


        public Agenda Agenda { get; set; }
        public Paciente Paciente { get; set; }
    }
}