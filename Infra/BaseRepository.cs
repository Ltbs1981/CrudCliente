using CrudCliente.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCliente.Infra
{
    internal abstract class BaseRepository
    {

        public abstract void Add(Cliente cliente);
        public abstract void Update(Cliente cliente);
        public abstract void Delete(Cliente cliente);
        public abstract List<Cliente> ListarClientes();
    }
}
