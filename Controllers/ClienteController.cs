using CrudCliente.Dominio.Entidades;
using CrudCliente.Servicos;

namespace CrudCliente.Controllers
{
    internal class ClienteController
    {
        private ClienteService _clienteService;

        public void AddCliente(string nome, string email, DateTime nascimento)
        {
            Cliente cliente = new Cliente()
            {
                Nome = nome,
                Email = email,
                DataNascimento = nascimento
            };

            _clienteService = new ClienteService();
            _clienteService.Add(cliente);
        }

        public List<Cliente> GetClientes()
        {
            _clienteService = new ClienteService();
            return _clienteService.GetAll();
        }

        public void DeleteClienteFisico(int clienteId)
        {
            _clienteService = new ClienteService();
            _clienteService.DeleteClienteFisico(clienteId);
        }
    }
}
