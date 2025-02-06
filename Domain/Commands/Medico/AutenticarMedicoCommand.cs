using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.Medico
{
    public class AutenticarMedicoCommand
    {
        public string Crm { get; set; }
        public string Senha { get; set; }

        public AutenticarMedicoCommand(string crm, string senha)
        {
            Crm = crm;
            Senha = senha;
        }
    }
}
