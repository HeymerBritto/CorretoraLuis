using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Domain.Model
{
    public class ClienteTitulo
    {
        public int Codigo { get; set; }
        public int ClienteID { get; set; }
        public int TituloID { get; set; }
        public bool Excluido { get; set; }

        //Prop Extras
        public Cliente Cliente { get; set; }
        public Titulo Titulo { get; set; }
    }
}
