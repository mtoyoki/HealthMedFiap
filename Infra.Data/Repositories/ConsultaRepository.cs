using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ConsultaRepository(ApplicationDbContext context) : RepositoryBase<ConsultaMedica>(context), IConsultaMedicaRepository;
}