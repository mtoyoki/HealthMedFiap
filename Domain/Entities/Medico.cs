using Core.Entities;

namespace Domain.Entities
{
    public class Medico : Usuario
    {
        public string Crm { get; set; }
        
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }

        //public List<HorarioDisponivel> HorariosDisponiveis { get; set; } = new List<HorarioDisponivel>();
        //public List<Consulta> Consultas { get; set; } = new List<Consulta>();

        public Medico()
        {
            
        }

        public Medico(Especialidade especialidade)
        {
            Especialidade = especialidade;
        }
    }
}
