using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
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

            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Cliente>().Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();


            modelBuilder.Entity<Contato>().ToTable("Contatos");

            modelBuilder.Entity<Contato>().Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(p => p.Telefone)
                .HasColumnType("varchar(15)");

            modelBuilder.Entity<Contato>().Property(p => p.Email)
                .HasColumnType("varchar(80)");


        }
    }
}
