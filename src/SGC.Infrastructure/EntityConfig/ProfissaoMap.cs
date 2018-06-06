using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ProfissaoMap : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.ToTable("Profissoes");

            builder.HasKey(pk => pk.ProfissaoId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(p => p.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();
        }
    }
}
