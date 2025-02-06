using Domain.Dtos;
using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class AgendaRepository(ApplicationDbContext context) : RepositoryBase<Agenda>(context), IAgendaRepository
    {
        public async Task<IEnumerable<PesquisarAgendaDto>> GetByCrm(string crm)
        {
            return await _context.Agenda
                                    .Where(a => a.Medico.Crm == crm)
                                    .Include(a => a.Medico.Especialidade)
                                    .AsNoTracking()
                                    .Select(a => NovoPesquisarAgendaDto(a))
                                    .ToListAsync();
        }

        public async Task<Agenda?> GetByCrmAndDataHora(string crm, DateTime dataHora)
        {
            return await _context.Agenda
                                 .Where(a => a.Medico.Crm == crm && a.DataHora == dataHora)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }

        private static PesquisarAgendaDto NovoPesquisarAgendaDto(Agenda agenda) => new PesquisarAgendaDto(
            agenda.Id,
            agenda.Medico.Crm,
            agenda.Medico.Nome,
            agenda.Medico.Especialidade.Descricao,
            agenda.DataHora,
            agenda.Valor,
            agenda.Disponivel);
    }
}