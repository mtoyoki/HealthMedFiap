using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infra.Data.Repositories
{
    public class MedicoRepository(ApplicationDbContext context, IMemoryCache cache) : RepositoryBase<Medico>(context), IMedicoRepository
    {
        public async Task<Medico?> GetMedicoByCrmAsync(string crm)
        {
            var cacheKey = $"Medico_{crm}";
            if (!cache.TryGetValue(cacheKey, out Medico? medico))
            {
                medico = await _context.Medico
                                       .Where(m => m.Crm == crm)
                                       .AsNoTracking()
                                       .FirstOrDefaultAsync();

                if (medico != null)
                {
                    cache.Set(cacheKey, medico, TimeSpan.FromMinutes(30));
                }
            }

            return medico;
        }

        public async Task<IEnumerable<BuscarMedicoDto>> GetByCodigoEspecialidadeAsync(string codigoEspecialidade)
        {
            var cacheKey = $"Medicos_Especialidade_{codigoEspecialidade}";
            if (!cache.TryGetValue(cacheKey, out IEnumerable<BuscarMedicoDto>? medicos))
            {
                medicos = await _context.Medico
                                        .Where(m => m.Especialidade.Codigo == codigoEspecialidade)
                                        .Include(m => m.Especialidade)
                                        .Select(m => BuscarMedicoDtoNovo(m))
                                        .AsNoTracking()
                                        .ToListAsync();

                cache.Set(cacheKey, medicos, TimeSpan.FromMinutes(30));
            }

            return medicos;
        }

        public async Task<IEnumerable<BuscarMedicoDto>> GetTodosAsync()
        {
            return await _context.Medico
                .Include(m => m.Especialidade)
                .Select(m => BuscarMedicoDtoNovo(m))
                .AsNoTracking()
                .ToListAsync();
        }

        private static BuscarMedicoDto BuscarMedicoDtoNovo(Medico medico) => new BuscarMedicoDto(medico.Nome, medico.Email, medico.Crm, medico.Especialidade.Descricao);
    }
}