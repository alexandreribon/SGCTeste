using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class ProfissaoClienteMap : IEntityTypeConfiguration<ProfissaoCliente>
    {
        public void Configure(EntityTypeBuilder<ProfissaoCliente> builder)
        {
            builder.ToTable("ProfissoesClientes");

            builder.HasKey(pk => pk.Id);

            //Relacionamento(Cliente e Profissão: N:N) cria-se a entidade 'ProfissaoCliente'

            //Relacionamento(Cliente e ProfissaoCliente: 1:N)
            builder.HasOne(p => p.Cliente)
                   .WithMany(p => p.ProfissoesClientes)
                   .HasForeignKey(fk => fk.ClienteId);

            //Relacionamento(Profissao e ProfissaoCliente: 1:N)
            builder.HasOne(p => p.Profissao)
                   .WithMany(p => p.ProfissoesClientes)
                   .HasForeignKey(fk => fk.ProfissaoId);
        }
    }
}
