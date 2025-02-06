using Domain.Queries.Paciente;
using Domain.Repositories;

namespace Application.Queries.Paciente
{
    public class BuscarMedicoQueryHandler(IMedicoRepository repository) : IBuscarMedicoQueryHandler
    {
        public Task<IEnumerable<BuscarMedicoQueryResult>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<IEnumerable<BuscarMedicoQueryResult>> GetByEspecialidadeIdAsync(string codigoEspecialidade)
        {
            return repository.GetByEspecialidadeIdAsync(codigoEspecialidade);
        }
    }

    public interface IBuscarMedicoQueryHandler
    {
        Task<IEnumerable<BuscarMedicoQueryResult>> GetAllAsync();
        Task<IEnumerable<BuscarMedicoQueryResult>> GetByEspecialidadeIdAsync(string codigoEspecialidade);
    }
}
