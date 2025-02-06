using Core.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class Agenda : BaseEntity
    {
        public int MedicoId { get; set; }

        public DateTime DataHora { get; set; }

        public float Valor { get; set; }

        public bool Disponivel { get; set; } = true;


        public Medico Medico { get; set; }
    }
}