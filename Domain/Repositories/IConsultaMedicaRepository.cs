using Core.Repositories;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories
{
    public interface IConsultaMedicaRepository : IRepository<ConsultaMedica>
    {
        Task<IEnumerable<PesquisarConsultaMedicaDto>> GetByCrmAndSituacaoConsultaMedica(string crm, SituacaoConsultaMedica? situacao);
    }
}
