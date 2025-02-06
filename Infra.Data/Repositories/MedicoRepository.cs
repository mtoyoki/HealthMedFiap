using Domain.Entities;
using Domain.Queries.Paciente;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class MedicoRepository(ApplicationDbContext context) : RepositoryBase<Medico>(context), IMedicoRepository
    {
        public async Task<Medico?> GetMedicoByCrm(string crm)
        {
            return await _context.Medico
                           .Where(m => m.Crm == crm)
                           .AsNoTracking()
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BuscarMedicoQueryResult>> GetAllAsync()
        {
            return await _context.Medico
                                 .Include(m => m.Especialidade)
                                 .Select(m => MedicoQueryResult(m))
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<BuscarMedicoQueryResult?> GetByIdAsync(int id)
        {
            return await _context.Medico
                                .Where(m => m.Id == id)
                                .Include(m => m.Especialidade)
                                .Select(m => MedicoQueryResult(m))
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BuscarMedicoQueryResult>> GetByEspecialidadeIdAsync(string codigoEspecialidade)
        {
            return await _context.Medico
                                 .Where(m => m.Especialidade.Codigo == codigoEspecialidade)
                                 .Include(m => m.Especialidade)
                                 .Select(m => MedicoQueryResult(m))
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        private static BuscarMedicoQueryResult MedicoQueryResult(Medico medico) => new BuscarMedicoQueryResult(medico.Nome, medico.Email, medico.Crm, medico.Especialidade.Descricao);
    }
}