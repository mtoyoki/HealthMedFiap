using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Configurations
{
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
                    .HasColumnType("FLOAT")
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

}
