using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class ConsultaMedicaConfiguration : IEntityTypeConfiguration<ConsultaMedica>
    {
        public void Configure(EntityTypeBuilder<ConsultaMedica> builder)
        {
            builder.ToTable("CONSULTA_MEDICA");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(c => c.AgendaId)
                .IsRequired();

            builder.Property(c => c.PacienteId)
                .IsRequired();

            builder.Property(c => c.Situacao)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(c => c.JustificativaSituacao)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false);

            builder.HasOne(c => c.Agenda)
                .WithMany()
                .HasForeignKey(c => c.AgendaId);

            builder.HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId);
        }
    }
}