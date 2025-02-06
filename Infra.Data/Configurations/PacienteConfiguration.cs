using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("PACIENTE");
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnType("INT")
                   .UseIdentityColumn();

            builder.Property(p => p.Nome)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            builder.Property(p => p.Cpf)
                   .HasColumnType("VARCHAR(11)")
                   .IsRequired();

            builder.Property(p => p.Email)
                   .HasColumnType("VARCHAR(50)");


            builder.Property(p => p.Senha)
                .HasColumnType("VARCHAR(20)");

            //builder.Property(p => p.RegiaoId)
            //       .HasColumnType("INT")
            //       .IsRequired();

            //builder.HasOne(c => c.Regiao)
            //       .WithMany()         
            //       .HasForeignKey(c => c.RegiaoId);
        }
    }
}