using Domain.Dtos;
using Domain.Repositories;

namespace Application.Queries.Paciente.Handlers
{
    public class BuscarMedicoQueryHandler(IMedicoRepository repository) : IBuscarMedicoQueryHandler
    {
        public Task<IEnumerable<BuscarMedicoDto>> GetTodosAsync()
        {
            return repository.GetTodosAsync();
        }

        public Task<IEnumerable<BuscarMedicoDto>> GetByCodigoEspecialidadeAsync(string codigoEspecialidade)
        {
            return repository.GetByCodigoEspecialidadeAsync(codigoEspecialidade);
        }
    }

    public interface IBuscarMedicoQueryHandler
    {
        Task<IEnumerable<BuscarMedicoDto>> GetTodosAsync();
        Task<IEnumerable<BuscarMedicoDto>> GetByCodigoEspecialidadeAsync(string codigoEspecialidade);
    }
}
