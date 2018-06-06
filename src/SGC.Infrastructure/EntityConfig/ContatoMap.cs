using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");

            builder.HasKey(pk => pk.ContatoId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(80)");
        }
    }
}
