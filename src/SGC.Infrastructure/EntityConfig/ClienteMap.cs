using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(pk => pk.ClienteId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            //Relacionamento(Cliente e Contato: 1:N)
            builder.HasMany(p => p.Contatos)
                   .WithOne(p => p.Cliente)
                   .HasForeignKey(fk => fk.ClienteId)
                   .HasPrincipalKey(pk => pk.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento(Cliente e Endereço: 1:1)
            builder.HasOne(p => p.Endereco)
                   .WithOne(p => p.Cliente)
                   .HasForeignKey<Endereco>(p => p.ClienteId); //ou .HasForeignKey("Endereco", "ClienteId");
        }
    }
}
