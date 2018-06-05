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

            #region Configurações de Cliente

            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            modelBuilder.Entity<Cliente>().HasKey(pk => pk.ClienteId);

            modelBuilder.Entity<Cliente>().Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(p => p.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            //Relacionamento(Cliente e Contato: 1:N)
            modelBuilder.Entity<Cliente>()
                .HasMany(p => p.Contatos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(fk => fk.ClienteId)
                .HasPrincipalKey(pk => pk.ClienteId);

            //Relacionamento(Cliente e Endereço: 1:1)
            modelBuilder.Entity<Cliente>()
                .HasOne(p => p.Endereco)
                .WithOne(p => p.Cliente)
                .HasForeignKey("Endereco", "ClienteId");

            #endregion

            #region Configurações de Contato

            modelBuilder.Entity<Contato>().ToTable("Contatos");

            modelBuilder.Entity<Contato>().HasKey(pk => pk.ContatoId);

            modelBuilder.Entity<Contato>().Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Contato>().Property(p => p.Telefone)
                .HasColumnType("varchar(15)");

            modelBuilder.Entity<Contato>().Property(p => p.Email)
                .HasColumnType("varchar(80)");

            #endregion

            #region  Configurações de Endereço

            modelBuilder.Entity<Endereco>().ToTable("Enderecos");

            modelBuilder.Entity<Endereco>().HasKey(pk => pk.EnderecoId);

            modelBuilder.Entity<Endereco>().Property(p => p.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(p => p.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(p => p.Numero)
                .HasColumnType("varchar(15)");

            modelBuilder.Entity<Endereco>().Property(p => p.Complemento)
               .HasColumnType("varchar(30)");

            modelBuilder.Entity<Endereco>().Property(p => p.Bairro)
                .HasColumnType("varchar(30)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(p => p.Cidade)
                .HasColumnType("varchar(30)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(p => p.Estado)
                .HasColumnType("varchar(2)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(p => p.Referencia)
                .HasColumnType("varchar(100)");

            #endregion

            #region Configurações de Profissão

            modelBuilder.Entity<Profissao>().ToTable("Profissoes");

            modelBuilder.Entity<Profissao>().HasKey(pk => pk.ProfissaoId);

            modelBuilder.Entity<Profissao>().Property(p => p.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(p => p.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            modelBuilder.Entity<Profissao>().Property(p => p.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();

            #endregion

            #region  Configurações de Profissão Cliente

            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissoesClientes");

            modelBuilder.Entity<ProfissaoCliente>().HasKey(pk => pk.Id);

            //Relacionamento(Cliente e Profissão: N:N) cria-se a entidade 'ProfissaoCliente'

            //Relacionamento(Cliente e ProfissaoCliente: 1:N)
            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(p => p.Cliente)
                .WithMany(p => p.ProfissoesClientes)
                .HasForeignKey(fk => fk.ClienteId);

            //Relacionamento(Profissao e ProfissaoCliente: 1:N)
            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(p => p.Profissao)
                .WithMany(p => p.ProfissoesClientes)
                .HasForeignKey(fk => fk.ProfissaoId);

            #endregion

            #region  Configurações de Menu

            modelBuilder.Entity<Menu>().ToTable("Menus");

            modelBuilder.Entity<Menu>().HasKey(pk => pk.Id);

            //AutoRelacionamento
            modelBuilder.Entity<Menu>()
                .HasMany(p => p.SubMenu)
                .WithOne()
                .HasForeignKey(fk => fk.MenuId);

            #endregion
        }
    }
}
