namespace Domain.Entities
{
    public class Medico : Usuario
    {
        public string Crm { get; set; }
        
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }

        public Medico()
        {
            
        }

        public Medico(Especialidade especialidade)
        {
            Especialidade = especialidade;
        }
    }
}
