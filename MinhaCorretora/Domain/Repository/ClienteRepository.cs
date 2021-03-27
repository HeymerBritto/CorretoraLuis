using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Domain.Model;
using System;
using System.Collections.Generic;

namespace MinhaCorretora.Domain.Repository
{
    public class ClienteRepository
    {
        private const int codigoArquivo = 0;

        public BancoDadosService bancoDadosService { get; set; }

        public ClienteRepository()
        {
            bancoDadosService = new BancoDadosService();
        }

        public List<Cliente> BuscarTodos()
        {
            var textoClientes = bancoDadosService.Output(codigoArquivo);

            if (textoClientes == string.Empty)
                return new List<Cliente>();

            var textoClientesAux = textoClientes.Split(";");

            var lista = new List<Cliente>();

            for (int i = 0; i < textoClientesAux.Length - 1; i = i + 4)
            {
                var cliente = new Cliente()
                {
                    Codigo = int.Parse(textoClientesAux[i]),
                    Nome = textoClientesAux[i + 1],
                    Senha = textoClientesAux[i + 2],
                    Excluido = bool.Parse(textoClientesAux[i + 3]),
                };

                lista.Add(cliente);
            }

            return lista;
        }

        public void Novo(Cliente cliente)
        {
            bancoDadosService.Input(0, @$"{cliente.Codigo};{cliente.Nome};{cliente.Senha};false;" + Environment.NewLine);
        }

        public void Editar(Cliente cliente)
        {
            var textoClientes = bancoDadosService.Output(codigoArquivo);

            var textoClientesAux = textoClientes.Split(";");

            for (int i = 0; i < textoClientesAux.Length - 1; i = i + 4)
            {
                int codigo = int.Parse(textoClientesAux[i]);
                if (codigo == cliente.Codigo)
                {
                    textoClientesAux[i + 1] = cliente.Nome;
                    textoClientesAux[i + 2] = cliente.Senha;

                    continue;
                }
            }

            var textoFinal = string.Join(";", textoClientesAux);

            bancoDadosService.Input(codigoArquivo, textoFinal, true);
        }

        public void Excluir(int codigo)
        {
         var textoClientes = bancoDadosService.Output(codigoArquivo);

            var textoClientesAux = textoClientes.Split(";");

            for (int i = 0; i < textoClientesAux.Length - 1; i = i + 4)
            {
                int codigoAux = int.Parse(textoClientesAux[i]);
                if (codigoAux == codigo)
                {
                    textoClientesAux[i + 3] = "true";
                    continue;
                }
            }

            var textoFinal = string.Join(";", textoClientesAux);

            bancoDadosService.Input(codigoArquivo, textoFinal, true);
        }
    }
}
