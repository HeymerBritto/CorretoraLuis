using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Core.Service.Screen;
using MinhaCorretora.Domain.Model;
using MinhaCorretora.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Front
{
    public class ClienteTituloFront
    {
        public void Novo()
        {
            var screenService = new ScreenService();
            var clienteTitulo = new ClienteTitulo();
            var bancoDadosService = new BancoDadosService();
            var clienteTituloRepository = new ClienteTituloRepository();

            string textoMenu = "Informe o código do usuário:";
            string textoMenu2 = "Informe o código do titulo:";

            Console.WriteLine(textoMenu);
            clienteTitulo.ClienteID = screenService.ConverterValorDigitado(textoMenu);

            Console.WriteLine(textoMenu2);
            clienteTitulo.TituloID = screenService.ConverterValorDigitado(textoMenu2);

            clienteTitulo.Codigo = bancoDadosService.Count(2);

            clienteTituloRepository.Novo(clienteTitulo);
        }

        public void Editar()
        {
            var screenService = new ScreenService();
            var clienteTitulo = new ClienteTitulo();
            var clienteTituloRepository = new ClienteTituloRepository();

            string textoMenu = "Informe o código do portifolio:";

            Console.WriteLine(textoMenu);
            clienteTitulo.Codigo = screenService.ConverterValorDigitado(textoMenu);

            var clientetitulos = clienteTituloRepository.BuscarTodos();
            if (clientetitulos.Count > 0)
            {
                var clienteTitulos = clientetitulos.Find(cliente => cliente.Codigo == clienteTitulo.Codigo);
                if (clienteTitulos != null)
                {
                    string textoMenu2 = "Informe o código do usuário:";
                    string textoMenu3 = "Informe o código do titulo:";

                    Console.WriteLine(textoMenu2);
                    clienteTitulo.ClienteID = screenService.ConverterValorDigitado(textoMenu2);

                    Console.WriteLine(textoMenu3);
                    clienteTitulo.TituloID = screenService.ConverterValorDigitado(textoMenu3);

                    clienteTituloRepository.Editar(clienteTitulo);
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
            var clienteTituloRepository = new ClienteTituloRepository();

            string textoMenu = "Informe o código do portifolio:";

            Console.WriteLine(textoMenu);
            int codigo = screenService.ConverterValorDigitado(textoMenu);

            clienteTituloRepository.Excluir(codigo);
        }
    }
}
