using Core.Repositories;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<IEnumerable<PesquisarAgendaDto>> GetByCrm(string crm);

        Task<Agenda?> GetByCrmAndDataHora(string crm, DateTime dataHora);

    }
}
