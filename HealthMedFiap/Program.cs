using Application.Commands.Medico;
using Application.Commands.Paciente;
using Application.Queries.Paciente;
using Core.Commands;
using Domain.Commands.Medico;
using Domain.Commands.Paciente;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi.Authentication;
using AuthenticationService = WebApi.Authentication.AuthenticationService;
using IAuthenticationService = WebApi.Authentication.IAuthenticationService;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthMed Hackaton Fiap ", Version = "v1", });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Médico: Username é o número de <b>CRM</b>. <br> Paciente: Username é o <b>CPF</b> ou <b>e-mail</b>."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basic"
                    }
                },
                new string[] {}
            }
        });
});

// Repositories
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IConsultaMedicaRepository, ConsultaRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

// Command Handlers
//Medico
builder.Services.AddScoped<ICommandHandler<AceitarConsultaCommand>, AceitarConsultaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AutenticarMedicoCommand>, AutenticarMedicoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CadastrarAgendaCommand>, CadastrarAgendaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RecusarConsultaCommand>, RecusarConsultaCommandHandler>();
//Paciente
builder.Services.AddScoped<ICommandHandler<AgendarConsultaCommand>, AgendarConsultaCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AutenticarPacienteCommand>, AutenticarPacienteCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CancelarConsultaCommand>, CancelarConsultaCommandHandler>();

// Query Handlers
builder.Services.AddScoped<IBuscarMedicoQueryHandler, BuscarMedicoQueryHandler>();
builder.Services.AddScoped<IPesquisarAgendaQueryHandler, PesquisarAgendaQueryHandler>();

// Add services to the container.
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Adiciona o serviço de autenticação básica
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contato");
        c.DocExpansion(DocExpansion.None);
    });

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
