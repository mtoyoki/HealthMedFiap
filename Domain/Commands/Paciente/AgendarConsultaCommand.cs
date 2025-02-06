using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Paciente
{
    public class AgendarConsultaCommand
    {
        public string Cpf { get; set; }

        public int AgendaId { get; set; }
    }
}
