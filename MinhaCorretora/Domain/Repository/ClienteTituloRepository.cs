using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Repository
{
    public class ClienteTituloRepository
    {
        private const int codigoArquivo = 2;

        public BancoDadosService bancoDadosService { get; set; }

        public ClienteTituloRepository()
        {
            bancoDadosService = new BancoDadosService();
        }

        public List<ClienteTitulo> BuscarTodos()
        {
            var clienteRepository = new ClienteRepository();
            var tituloRepository = new TituloRepository();

            var textoClienteTitulos = bancoDadosService.Output(codigoArquivo);

            if (textoClienteTitulos == string.Empty)
                return new List<ClienteTitulo>();

            var textoClienteTitulosAux = textoClienteTitulos.Split(";");

            var lista = new List<ClienteTitulo>();

            for (int i = 0; i < textoClienteTitulosAux.Length - 1; i += 4)
            {
                var clienteTitulo = new ClienteTitulo()
                {
                    Codigo = int.Parse(textoClienteTitulosAux[i]),
                    ClienteID = int.Parse(textoClienteTitulosAux[i + 1]),
                    TituloID = int.Parse(textoClienteTitulosAux[i + 2]),
                    Excluido = bool.Parse(textoClienteTitulosAux[i + 3]),
                };

                clienteTitulo.Cliente = clienteRepository.BuscarTodos().Find(cliente => cliente.Codigo == clienteTitulo.ClienteID);
                clienteTitulo.Titulo = tituloRepository.BuscarTodos().Find(titulo => titulo.Codigo == clienteTitulo.TituloID);

                //clienteRepository.BuscarTodos()
                //Heymer
                //Louis
                //Anne

                //Find(cliente => cliente.Codigo == clienteTitulo.ClienteID) Onde cliente é 1
                //Heymer

                lista.Add(clienteTitulo);
            }

            return lista;
        }

        public void Novo(ClienteTitulo clienteTitulo)
        {
            bancoDadosService.Input(
                codigoArquivo, 
                @$"{clienteTitulo.Codigo};{clienteTitulo.ClienteID};{clienteTitulo.TituloID};false;" + Environment.NewLine);
        }

        public void Editar(ClienteTitulo clienteTitulo)
        {
            var textoClientes = bancoDadosService.Output(codigoArquivo);

            var textoClientesAux = textoClientes.Split(";");

            for (int i = 0; i < textoClientesAux.Length - 1; i += 4)
            {
                int codigo = int.Parse(textoClientesAux[i]);
                if (codigo == clienteTitulo.Codigo)
                {
                    textoClientesAux[i + 1] = clienteTitulo.ClienteID.ToString();
                    textoClientesAux[i + 2] = clienteTitulo.TituloID.ToString();

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

            for (int i = 0; i < textoClientesAux.Length - 1; i += 4)
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
