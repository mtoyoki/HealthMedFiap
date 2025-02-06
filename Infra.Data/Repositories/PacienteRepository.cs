using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class PacienteRepository(ApplicationDbContext context) : RepositoryBase<Paciente>(context), IPacienteRepository
    {
        public async Task<Paciente?> GetPacienteByEmailOrCpf(string emailOrCpf)
        {
            return await _context.Paciente
                                .Where(p => p.Email == emailOrCpf || p.Cpf == emailOrCpf)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }
    }
}