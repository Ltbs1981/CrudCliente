﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCliente.Dominio.Entidades
{
    internal class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string  Email { get; set; }
        public DateTime DataNascimento  { get; set; }
        public bool  Ativo { get; set; }

        public Cliente()
        {
            Ativo = true;
        }
    }
}
