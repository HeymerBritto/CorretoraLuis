using MinhaCorretora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Core.Service.Captions
{
    public static class CaptionsService
    {
        public static string GetMenuPrincipal()
        {
            return $@"Bem vindo a Corretora

1 - Cadastro de Clientes
2 - Cadastro de Titulos
3 - Cadastro do Portifolio

4 - Sair
";
        }

        public static string GetMenuCliente(List<Cliente> clientes)
        {
            return $@"Lista de usuários cadastrados

{FormatarClientes(clientes)}

1 - Incluir 2 - Editar 3 - Excluir 4 - Sair
";
        }

        private static string FormatarClientes(List<Cliente> clientes)
        {
            var stringBuilder = new StringBuilder();

            foreach (var cliente in clientes)
            {
                if (!cliente.Excluido)
                    stringBuilder.Append($@"{cliente.Codigo} - {cliente.Nome}" + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public static string GetMenuTitulo(List<Titulo> titulos)
        {
            return $@"Lista de titulos cadastrados

{FormatarTitulo(titulos)}

1 - Incluir 2 - Editar 3 - Excluir 4 - Sair
";
        }

        private static string FormatarTitulo(List<Titulo> titulos)
        {
            var stringBuilder = new StringBuilder();

            foreach (var titulo in titulos)
            {
                if (!titulo.Excluido)
                    stringBuilder.Append($@"{titulo.Codigo} - {titulo.Descricao}" + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        public static string GetMenuPortifolio(List<ClienteTitulo> clienteTitulos)
        {
            return $@"Seu Portifolio

{FormatarClienteTitulo(clienteTitulos)}

1 - Incluir 2 - Editar 3 - Excluir 4 - Sair
";
        }

        private static string FormatarClienteTitulo(List<ClienteTitulo> clienteTitulos)
        {
            var stringBuilder = new StringBuilder();

            foreach (var clienteTitulo in clienteTitulos)
            {
                if (!clienteTitulo.Excluido)
                    stringBuilder.Append($@"{clienteTitulo.Codigo} - {clienteTitulo.Titulo.Descricao} -> {clienteTitulo.Cliente.Nome}" + Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
