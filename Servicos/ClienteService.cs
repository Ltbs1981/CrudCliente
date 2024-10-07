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
            {
                Console.WriteLine("Erro ao adicionar cliente");
                return;
            }

            _clienteRepositorio = new ClienteRepositorio();
            _clienteRepositorio.Add(cliente);
        }

        public List<Cliente> GetAll()
        {
            _clienteRepositorio = new ClienteRepositorio();
            return _clienteRepositorio.GetClientes();
        }

        public void DeleteClienteFisico(int clienteId)
        {
            _clienteRepositorio = new ClienteRepositorio();
            var cliente = _clienteRepositorio.GetClientes().FirstOrDefault(c => c.Id == clienteId);

            if (cliente != null)
            {
                _clienteRepositorio.DeleteFisico(cliente);
                Console.WriteLine("Cliente deletado com sucesso");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        private bool ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                return false;
            else if (string.IsNullOrWhiteSpace(cliente.Nome) ||
                    string.IsNullOrWhiteSpace(cliente.Email) ||
                    cliente.DataNascimento == DateTime.MinValue)
                return false;
            return true;
        }
    }
}
