using Core.Entities;

namespace Domain.Entities
{
    public class Especialidade: BaseEntity
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }


        public Especialidade()
        {            
        }

        public Especialidade(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}
