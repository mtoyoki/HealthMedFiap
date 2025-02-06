using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("AGENDA");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(a => a.MedicoId)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(a => a.DataHora)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(a => a.Valor)
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired();

            builder.Property(a => a.Disponivel)
                .HasColumnType("BIT")
                .IsRequired();

            builder.HasOne(a => a.Medico)
                .WithMany()
                .HasForeignKey(a => a.MedicoId);
        }
    }
}