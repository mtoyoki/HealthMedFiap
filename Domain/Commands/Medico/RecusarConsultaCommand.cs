using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Medico
{
    public class RecusarConsultaCommand
    {
        public string Crm { get; set; }
        public string Justificativa { get; set; }
        public int ConsultaMedicaId { get; set; }
        
        public bool DisponibilizarAgenda { get; set; }
    }
}
