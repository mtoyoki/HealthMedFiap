using Domain.Dtos;
using Domain.Repositories;

namespace Application.Queries.Paciente.Handlers
{
    public class PesquisarAgendaQueryHandler(IAgendaRepository repository) : IPesquisarAgendaQueryHandler
    {
        public Task<IEnumerable<PesquisarAgendaDto>> GetByCrm(string crm)
        {
            return repository.GetByCrm(crm);
        }
    }

    public interface IPesquisarAgendaQueryHandler
    {
        Task<IEnumerable<PesquisarAgendaDto>> GetByCrm(string crm);
    }
}
