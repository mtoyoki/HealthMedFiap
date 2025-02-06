using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("ESPECIALIDADE");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .UseIdentityColumn();

            builder.Property(e => e.Codigo)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
        }
    }
}

