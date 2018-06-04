using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClienteContext context)
        {
            if (context.Clientes.Any())
            {
                return; //BD já possui dados
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Fulano da Silva",
                    CPF = "11111111111"
                },

                new Cliente
                {
                    Nome = "Beltrano da Silva",
                    CPF = "22222222222"
                }
            };

            context.Clientes.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato 1",
                    Telefone = "11975502088",
                    Email = "contato1@gmail.com",
                    Cliente = clientes[0]
                },

                new Contato
                {
                    Nome = "Contato 2",
                    Telefone = "11925665445",
                    Email = "contato2@gmail.com",
                    Cliente = clientes[1]
                }
            };

            context.Contatos.AddRange(contatos);

            context.SaveChanges();
        }
    }
}
