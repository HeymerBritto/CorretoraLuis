using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Model
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Excluido { get; set; }
    }
}
