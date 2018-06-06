using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(pk => pk.EnderecoId);

            builder.Property(p => p.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(p => p.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.Numero)
                .HasColumnType("varchar(15)");

            builder.Property(p => p.Complemento)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.Bairro)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(p => p.Cidade)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(p => p.Estado)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(p => p.Referencia)
                .HasColumnType("varchar(100)");
        }
    }
}
