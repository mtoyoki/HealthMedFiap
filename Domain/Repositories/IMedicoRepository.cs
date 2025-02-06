using Core.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Queries.Paciente;

namespace Domain.Repositories
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico?> GetMedicoByCrm(string crm);
        Task<IEnumerable<BuscarMedicoQueryResult>> GetAllAsync();
        Task<BuscarMedicoQueryResult?> GetByIdAsync(int id);

        Task<IEnumerable<BuscarMedicoQueryResult>> GetByEspecialidadeIdAsync(string codigoEspecialidade);
    }
}
