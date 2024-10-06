using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudCliente.Dominio.Entidades;

namespace CrudCliente.Infra.Repositorio
{
    internal class ClienteRepositorio
    {
        private static List<Cliente> clientes = new List<Cliente>();
        private static int id = 0;

        public void Add(Cliente cliente)
        {
            cliente.Id = id++;
            clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            Cliente banco = clientes.FirstOrDefault(x => x.Id == cliente.Id);
        }

        public void DeleteFisico(Cliente cliente)
        {
            clientes.Remove(cliente);
        }

        public void DeleteLogico(int id)
        {
            var cliente = clientes.FirstOrDefault(x => x.Id == id);
            cliente.Ativo = false;
        }

        public List<Cliente> GetClientes()
        {
            return clientes;
        }

        public List<Cliente> ListarClientesAtivos()
        {
            return clientes.Where(x => x.Ativo == true).ToList();
        }

    }
}
