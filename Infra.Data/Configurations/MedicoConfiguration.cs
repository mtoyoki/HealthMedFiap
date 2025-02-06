using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("MEDICO");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .HasColumnType("INT")
                   .UseIdentityColumn();

            builder.Property(m => m.Nome)
                   .HasColumnType("VARCHAR(100)")
                   .IsRequired();

            builder.Property(m => m.Cpf)
                   .HasColumnType("VARCHAR(11)")
                   .IsRequired();

            builder.Property(m => m.Email)
                .HasColumnType("VARCHAR(50)");

            builder.Property(m => m.Senha)
                .HasColumnType("VARCHAR(20)");

            builder.Property(m => m.Crm)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(m => m.EspecialidadeId)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(c => c.Especialidade)
                .WithMany()
                .HasForeignKey(c => c.EspecialidadeId);

            // Adicionando índice na coluna CRM
            builder.HasIndex(m=> m.Crm).HasDatabaseName("IX_MEDICO_Crm");
        }
    }
}