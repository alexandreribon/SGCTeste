using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using SGC.Infrastructure.EntityConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoClienteMap());
            modelBuilder.ApplyConfiguration(new MenuMap());

        }
    }
}
