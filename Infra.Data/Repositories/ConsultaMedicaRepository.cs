using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ConsultaMedicaRepository(ApplicationDbContext context) : RepositoryBase<ConsultaMedica>(context), IConsultaMedicaRepository
    {
        public async Task<IEnumerable<PesquisarConsultaMedicaDto>> GetByCrmAndSituacaoConsultaMedica(string crm, SituacaoConsultaMedica? situacao)
        {
            var consultasDto = await _context.ConsultaMedica
                .Where(c => c.Agenda.Medico.Crm == crm && (!situacao.HasValue || c.Situacao == situacao))
                .Include(c => c.Agenda)
                .Include(c => c.Paciente)
                .Select(c => PesquisarConsultaMedicaDtoNovo(c))
                .AsNoTracking()
                .ToListAsync();

            return consultasDto;
        }

        private static PesquisarConsultaMedicaDto PesquisarConsultaMedicaDtoNovo(ConsultaMedica c) =>
            new PesquisarConsultaMedicaDto(c.Id, c.Paciente.Nome, c.Paciente.Email, c.Agenda.DataHora, c.Agenda.Valor, c.Situacao.Descricao());

    }
}