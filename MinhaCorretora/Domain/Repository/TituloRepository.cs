using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Repository
{
    public class TituloRepository
    {
        private const int codigoArquivo = 1;

        public BancoDadosService bancoDadosService { get; set; }

        public TituloRepository()
        {
            bancoDadosService = new BancoDadosService();
        }

        public List<Titulo> BuscarTodos()
        {
            var textoTitulos = bancoDadosService.Output(codigoArquivo);

            if (textoTitulos == string.Empty)
                return new List<Titulo>();

            var textoTitulosAux = textoTitulos.Split(";");

            var lista = new List<Titulo>();

            for (int i = 0; i < textoTitulosAux.Length - 1; i += 4)
            {
                var Titulo = new Titulo()
                {
                    Codigo = int.Parse(textoTitulosAux[i]),
                    Descricao = textoTitulosAux[i + 1],
                    Tipo = textoTitulosAux[i + 2],
                    Excluido = bool.Parse(textoTitulosAux[i + 3]),
                };

                lista.Add(Titulo);
            }

            return lista;
        }

        public void Novo(Titulo titulo)
        {
            bancoDadosService.Input(1, @$"{titulo.Codigo};{titulo.Descricao};{titulo.Tipo};false;" + Environment.NewLine);
        }

        public void Editar(Titulo titulo)
        {
            var textoTitulos = bancoDadosService.Output(codigoArquivo);

            var textoTitulosAux = textoTitulos.Split(";");

            for (int i = 0; i < textoTitulosAux.Length - 1; i += 4)
            {
                int codigo = int.Parse(textoTitulosAux[i]);
                if (codigo == titulo.Codigo)
                {
                    textoTitulosAux[i + 1] = titulo.Descricao;
                    textoTitulosAux[i + 2] = titulo.Tipo;

                    continue;
                }
            }

            var textoFinal = string.Join(";", textoTitulosAux);

            bancoDadosService.Input(codigoArquivo, textoFinal, true);
        }

        public void Excluir(int codigo)
        {
            var textoTitulos = bancoDadosService.Output(codigoArquivo);

            var textoTitulosAux = textoTitulos.Split(";");

            for (int i = 0; i < textoTitulosAux.Length - 1; i += 4)
            {
                int codigoAux = int.Parse(textoTitulosAux[i]);
                if (codigoAux == codigo)
                {
                    textoTitulosAux[i + 3] = "true";
                    continue;
                }
            }

            var textoFinal = string.Join(";", textoTitulosAux);

            bancoDadosService.Input(codigoArquivo, textoFinal, true);
        }
    }
}
