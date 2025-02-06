using Domain.Queries.Paciente;
using Domain.Repositories;

namespace Application.Queries.Paciente
{
    public class PesquisarAgendaQueryHandler(IAgendaRepository repository) : IPesquisarAgendaQueryHandler
    {
        public Task<IEnumerable<PesquisarAgendaQueryResult>> GetByCrm(string crm)
        {
            return repository.GetByCrm(crm);
        }
    }

    public interface IPesquisarAgendaQueryHandler
    {
        Task<IEnumerable<PesquisarAgendaQueryResult>> GetByCrm(string crm);
    }
}
