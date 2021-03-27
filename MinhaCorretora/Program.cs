using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Core.Service.Captions;
using MinhaCorretora.Core.Service.Screen;
using MinhaCorretora.Domain.Front;
using MinhaCorretora.Domain.Repository;

namespace MinhaCorretora
{
    class Program
    {
        //CRUD

        //Create
        //Read
        //Update
        //Delete

        static void Main(string[] args)
        {
            int resposta;
            var screenService = new ScreenService();
            var bancoDadosService = new BancoDadosService();

            do
            {
                resposta = screenService.ImprimirMenu(CaptionsService.GetMenuPrincipal(), new int[] { 1, 2, 3, 4 });

                if (resposta == 1)
                {
                    MenuCliente(screenService, bancoDadosService);
                }
                else if (resposta == 2)
                {
                    MenuTitulo(screenService);
                }
                else if (resposta == 3)
                {
                    MenuPortifolio(screenService);
                }

            } while (resposta != 4);
        }

        static void MenuCliente(ScreenService screenService, BancoDadosService bancoDadosService)
        {
            int resposta;
            var clienteFront = new ClienteFront(); //Construtor
            var clienteRepository = new ClienteRepository();

            do
            {
                resposta = screenService.ImprimirMenu(
                    CaptionsService.GetMenuCliente(clienteRepository.BuscarTodos()),
                    new int[] { 1, 2, 3, 4 });

                if (resposta == 1)
                {
                    clienteFront.Novo();
                }
                else if (resposta == 2)
                {
                    clienteFront.Editar();
                }
                else if (resposta == 3)
                {
                    clienteFront.Excluir();
                }

            } while (resposta != 4);
        }

        static void MenuTitulo(ScreenService screenService)
        {
            int resposta;
            var tituloRepository = new TituloRepository();
            var tituloFront = new TituloFront();

            do
            {
                resposta = screenService.ImprimirMenu(
                    CaptionsService.GetMenuTitulo(tituloRepository.BuscarTodos()),
                    new int[] { 1, 2, 3, 4 });

                if (resposta == 1)
                {
                    tituloFront.Novo();
                }
                else if (resposta == 2)
                {
                    tituloFront.Editar();
                }
                else if (resposta == 3)
                {
                    tituloFront.Excluir();
                }

            } while (resposta != 4);
        }

        static void MenuPortifolio(ScreenService screenService)
        {
            int resposta;
            var clienteTituloFront = new ClienteTituloFront();
            var clienteTituloRepository = new ClienteTituloRepository();

            do
            {
                resposta = screenService.ImprimirMenu(
                    CaptionsService.GetMenuPortifolio(clienteTituloRepository.BuscarTodos()),
                    new int[] { 1, 2, 3, 4 });

                if (resposta == 1)
                {
                    clienteTituloFront.Novo();
                }
                else if (resposta == 2)
                {
                    clienteTituloFront.Editar();
                }
                else if (resposta == 3)
                {
                    clienteTituloFront.Excluir();
                }

            } while (resposta != 4);
        }
    }
}
