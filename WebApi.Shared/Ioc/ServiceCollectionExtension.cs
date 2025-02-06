using Application.Commands.Medico;
using Application.Commands.Medico.Handlers;
using Application.Commands.Paciente;
using Application.Commands.Paciente.Handlers;
using Application.Queries.Paciente.Handlers;
using Core.Commands;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Shared.Ioc
{

    public static class ServiceCollectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            // Add the IMemoryCache service
            services.AddMemoryCache();

            //Repositories
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IConsultaMedicaRepository, ConsultaRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

            //Command Handlers
            //#Medico
            services.AddScoped<ICommandHandler<AceitarConsultaCommand>, AceitarConsultaCommandHandler>();
            services.AddScoped<ICommandHandler<AutenticarMedicoCommand>, AutenticarMedicoCommandHandler>();
            services.AddScoped<ICommandHandler<CadastrarAgendaCommand>, CadastrarAgendaCommandHandler>();
            services.AddScoped<ICommandHandler<RecusarConsultaCommand>, RecusarConsultaCommandHandler>();
            //#Paciente
            services.AddScoped<ICommandHandler<AgendarConsultaCommand>, AgendarConsultaCommandHandler>();
            services.AddScoped<ICommandHandler<AutenticarPacienteCommand>, AutenticarPacienteCommandHandler>();
            services.AddScoped<ICommandHandler<CancelarConsultaCommand>, CancelarConsultaCommandHandler>();

            //Query Handlers
            //#Paciente
            services.AddScoped<IBuscarMedicoQueryHandler, BuscarMedicoQueryHandler>();
            services.AddScoped<IPesquisarAgendaQueryHandler, PesquisarAgendaQueryHandler>();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        }
    }

}
