using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidades;
using CrudCliente.Infra.Repositorio;

namespace CrudCliente.Servicos
{
    internal class ClienteService
    {
        private ClienteRepositorio _clienteRepositorio;

        public void Add(Cliente cliente)
        {
            if (!ValidarCliente(cliente))
                Console.WriteLine("Erro ao adicionar cliente");
            _clienteRepositorio = new ClienteRepositorio();
            _clienteRepositorio.Add(cliente);
        }

        public List<Cliente> GetAll()
        {
            _clienteRepositorio = new ClienteRepositorio();
            return _clienteRepositorio.GetClientes();
        }

        private bool ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;
            else if (string.IsNullOrWhiteSpace(cliente.Nome) &&
                    string.IsNullOrWhiteSpace(cliente.Email) &&
                    cliente.DataNascimento != DateTime.MinValue)
                return false;
            return true;
        }
    }
}
