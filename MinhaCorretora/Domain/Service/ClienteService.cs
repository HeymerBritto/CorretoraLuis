using MinhaCorretora.Core.Service.BancoDados;
using MinhaCorretora.Domain.Model;
using MinhaCorretora.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Service
{
    public class ClienteService
    {
        private ClienteRepository clienteRepository;
        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
        }

        public int Count()
        {
            var bancoDadosService = new BancoDadosService();
            return bancoDadosService.Count(0);
        }

        public void Novo(Cliente cliente)
        {
            if (cliente.Excluido)
                return;

            cliente.Codigo = Count();

            clienteRepository.Novo(cliente);
        }

        public List<Cliente> BuscarTodos()
        {
            return clienteRepository.BuscarTodos();
        }

        public void Editar(Cliente cliente)
        {
            clienteRepository.Editar(cliente);
        }

        public void Excluir(int codigo)
        {
            clienteRepository.Excluir(codigo);
        }
    }
}
