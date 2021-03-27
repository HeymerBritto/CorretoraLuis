using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Core.Service.Screen;
using MinhaCorretora.Domain.Repository;
using MinhaCorretora.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Front
{
    public class TituloFront
    {
        public void Novo()
        {
            var bancoDadosService = new BancoDadosService();
            var tituloRepository = new TituloRepository();
            var titulo = new Titulo();

            Console.WriteLine("Informe a descrição do titulo:");
            titulo.Descricao = Console.ReadLine();

            Console.WriteLine("Informe o tipo do titulo:");
            titulo.Tipo = Console.ReadLine();

            titulo.Codigo = bancoDadosService.Count(1);

            tituloRepository.Novo(titulo);
        }

        public void Editar()
        {
            var screenService = new ScreenService();
            var tituloRepository = new TituloRepository();

            string textoMenu = "Informe o código do usuário:";

            Console.WriteLine(textoMenu);
            int codigo = screenService.ConverterValorDigitado(textoMenu);

            var titulos = tituloRepository.BuscarTodos();
            if (titulos.Count > 0)
            {
                var Titulo = titulos.Find(Titulo => Titulo.Codigo == codigo);
                if (Titulo != null)
                {
                    Console.WriteLine("Informe a descrição do titulo:");
                    Titulo.Descricao = Console.ReadLine();

                    Console.WriteLine("Informe o tipo do titulo:");
                    Titulo.Tipo = Console.ReadLine();

                    tituloRepository.Editar(Titulo);
                }
                else
                {
                    Console.WriteLine("Registro não localizado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum registro cadastrado no banco de dados.");
            }
        }

        public void Excluir()
        {
            var screenService = new ScreenService();
            var tituloRepository = new TituloRepository();

            string textoMenu = "Informe o código do titulo:";

            Console.WriteLine(textoMenu);
            int codigo = screenService.ConverterValorDigitado(textoMenu);

            tituloRepository.Excluir(codigo);
        }
    }
}
