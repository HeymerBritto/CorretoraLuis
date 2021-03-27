using MinhaCorretora.Core.Service.Screen;
using MinhaCorretora.Domain.Model;
using MinhaCorretora.Domain.Service;
using System;

namespace MinhaCorretora.Domain.Front
{
    public class ClienteFront
    {
        private readonly ScreenService screenService;
        private readonly ClienteService clienteService;

        public ClienteFront()
        {
            screenService = new ScreenService();
            clienteService = new ClienteService();
        }

        private Cliente SolicitaDadosUsuario(Cliente cliente)
        {
            if (cliente == null)
                cliente = new Cliente();

            Console.WriteLine("Informe o nome do usuário:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Informe a senha do usuário:");
            cliente.Senha = Console.ReadLine();

            return cliente;
        }

        private int SolicitaCodigoUsuario()
        {
            string textoMenu = "Informe o código do usuário:";
            Console.WriteLine(textoMenu);
            return screenService.ConverterValorDigitado(textoMenu);
        }

        public void Novo()
        {
            clienteService.Novo(
                SolicitaDadosUsuario(null));
        }

        public void Editar()
        {
            int codigo = SolicitaCodigoUsuario();

            var clientes = clienteService.BuscarTodos();
            if (clientes.Count > 0)
            {
                var cliente = clientes.Find(cliente => cliente.Codigo == codigo);
                if (cliente != null)
                {
                    clienteService.Editar(
                        SolicitaDadosUsuario(cliente));
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
            clienteService.Excluir(
                SolicitaCodigoUsuario());
        }
    }
}
