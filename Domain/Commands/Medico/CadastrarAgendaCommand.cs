using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Medico
{
    public class CadastrarAgendaCommand
    {
        public string Crm { get; set; }
        public DateTime DataHora { get; set; }

        public float Valor { get; set; }

        public bool Disponivel { get; set; }
    }
}
