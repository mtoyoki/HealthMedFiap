using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class EspecialidadeRepository(ApplicationDbContext context) : RepositoryBase<Especialidade>(context), IEspecialidadeRepository;
}