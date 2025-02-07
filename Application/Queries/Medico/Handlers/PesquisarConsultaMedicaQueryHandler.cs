using Domain.Dtos;
using Domain.Enums;
using Domain.Repositories;

namespace Application.Queries.Medico.Handlers
{
    public class PesquisarConsultaMedicaQueryHandler(IConsultaMedicaRepository repository) : IPesquisarConsultaMedicaQueryHandler
    {
        public Task<IEnumerable<PesquisarConsultaMedicaDto>> GetByCrmAndSituacaoConsultaMedica(PesquisarConsultaMedicaQuery query)
        {
            return repository.GetByCrmAndSituacaoConsultaMedica(query.Crm, query.Situacao);
        }
    }

    public interface IPesquisarConsultaMedicaQueryHandler
    {
        Task<IEnumerable<PesquisarConsultaMedicaDto>> GetByCrmAndSituacaoConsultaMedica(PesquisarConsultaMedicaQuery query);
    }
}
