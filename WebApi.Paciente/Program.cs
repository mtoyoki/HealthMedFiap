using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi.Paciente.Authentication;
using WebApi.Shared.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthMed Hackaton Fiap ", Version = "v1", });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Username do paciente � o <b>CPF</b> ou <b>e-mail</b>."
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


// Adiciona o servi�o de autentica��o b�sica
builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, PacienteAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddControllers();

//Configura inje��o de depend�ncia para os Repositories, CommandHandlers, QueryHandlers
builder.Services.ConfigureDependencyInjection();

builder.Services.AddDbContext(builder.Configuration); //builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

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