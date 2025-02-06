using Core.Repositories;
using Domain.Entities;
using Domain.Queries.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<IEnumerable<PesquisarAgendaQueryResult>> GetByCrm(string crm);
    }
}
