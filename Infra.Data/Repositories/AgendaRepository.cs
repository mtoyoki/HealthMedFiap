using Domain.Entities;
using Domain.Queries.Paciente;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class AgendaRepository(ApplicationDbContext context) : RepositoryBase<Agenda>(context), IAgendaRepository
    {
        public async Task<IEnumerable<PesquisarAgendaQueryResult>> GetByCrm(string crm)
        {
            return await _context.Agenda
                    .Where(a => a.Medico.Crm == crm)
                    .Include(a => a.Medico.Especialidade)
                    .AsNoTracking()
                    .Select(a => AgendaQueryResult(a))
                    .ToListAsync();
        }

        private static PesquisarAgendaQueryResult AgendaQueryResult(Agenda agenda) => new PesquisarAgendaQueryResult(
            agenda.Id,
            agenda.Medico.Crm,
            agenda.Medico.Nome,
            agenda.Medico.Especialidade.Descricao,
            agenda.DataHora,
            agenda.Valor,
            agenda.Disponivel);
    }
}