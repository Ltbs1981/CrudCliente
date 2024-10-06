using CrudCliente.Controllers;
using System;
using CrudCliente.Dominio.Entidades;
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
            Console.WriteLine("Escolha dentre as opções");
            Console.WriteLine("1) Cadastrar cliente\n2) Listar todos");
            Menu menu = Enum.Parse<Menu>(Console.ReadLine());

            switch (menu)
            {
                case Menu.Adicionar:
                    {
                        ClienteController clienteController = new ClienteController();
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
                        ClienteController clienteController = new ClienteController();
                        var clientes = clienteController.GetClientes();
                        clientes.ForEach(cliente => Console.WriteLine(
                                        $"Cliente : {cliente.Nome}\n" +
                                        $"Data de Nascimento: {cliente.DataNascimento.ToString("dd-MM-yyyy")}\n" +
                                        $"Email : {cliente.Email}")
                                      );
                        break;
                    }
                default:
                    break;
            }

            Console.WriteLine("Deseja realizar outra operação");
            opcao = Enum.Parse<Opcao>(Console.ReadLine());
            Console.Clear();

        } while (opcao != Opcao.Nao);
    }
}
}
    