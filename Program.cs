using CrudCliente.Controllers;
using CrudCliente.Dominio.Enumeradores;
namespace CrudCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Opcao opcao = 0;

            do
            {
                Console.WriteLine("Escolha ");
                Console.WriteLine("1) Cadastrar cliente\n\t 2) Listar todos\n\t 3) Editar Cliente\n\t 4) Apagar um Cliente");
                Menu menu = Enum.Parse<Menu>(Console.ReadLine());

                ClienteController clienteController = new ClienteController();

                switch (menu)
                {
                    case Menu.Adicionar:
                        {
                            Console.WriteLine("Insira o nome do cliente");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o e-mail do cliente");
                            string email = Console.ReadLine();
                            Console.WriteLine("Informe a data de nascimento");
                            DateTime nascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.AddCliente(nome, email, nascimento);
                        }
                        break;

                    case Menu.ListarTodos:
                        {
                            var clientes = clienteController.GetClientes();
                            clientes.ForEach(cliente => Console.WriteLine(
                                                $"Cliente : {cliente.Nome}\n" +
                                                $"Data de Nascimento: {cliente.DataNascimento.ToString("dd-MM-yyyy")}\n" +
                                                $"Email : {cliente.Email}")
                                              );
                        }
                        break;
                    case Menu.EditarCliente:
                        {
                            Console.WriteLine("Informe o ID do cliente a ser editado");
                            int clienteId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira o novo nome do cliente");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Insira o novo e-mail do cliente");
                            string email = Console.ReadLine();
                            Console.WriteLine("Informe a nova data de nascimento");
                            DateTime nascimento = DateTime.Parse(Console.ReadLine());
                            clienteController.EditarCliente(clienteId, nome, email, nascimento);
                        }
                        break;

                    case Menu.DeletarClienteFisico:
                        {
                            Console.WriteLine("Informe o ID do cliente a ser deletado");
                            int clienteId = int.Parse(Console.ReadLine());
                            clienteController.DeleteClienteFisico(clienteId);
                        }
                        break;

                    default:
                        break;
                }

                Console.WriteLine("Deseja realizar outra operação?");
                opcao = Enum.Parse<Opcao>(Console.ReadLine());
                Console.Clear();

            } while (opcao != Opcao.Nao);
        }
    }
}