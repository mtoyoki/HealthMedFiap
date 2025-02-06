using Core.Repositories;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico?> GetMedicoByCrmAsync(string crm);
        Task<IEnumerable<BuscarMedicoDto>> GetTodosAsync();
        Task<IEnumerable<BuscarMedicoDto>> GetByCodigoEspecialidadeAsync(string codigoEspecialidade);
    }
}