using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MinhaCorretora.Core.Service.BancoDados
{
    public class BancoDadosService
    {
        private string[] caminho = {
            @"C:\Users\heyme\source\repos\MinhaCorretora\MinhaCorretora\Cliente.txt",
            @"C:\Users\heyme\source\repos\MinhaCorretora\MinhaCorretora\Titulo.txt",
            @"C:\Users\heyme\source\repos\MinhaCorretora\MinhaCorretora\Portifolio.txt",
        };

        //Bancos (Arquivo Texto, Access, Excel, SQL, Oracle)
        //I/O - Input / Output

        public void Input(int arquivo, string texto, bool substituir = false)
        {
            var stringBuilder = new StringBuilder();

            if (!substituir)
                stringBuilder.Append(File.ReadAllText(caminho[arquivo]));
            stringBuilder.Append(texto);

            File.WriteAllText(caminho[arquivo], stringBuilder.ToString());
        }

        public string Output(int arquivo)
        {
            return File.ReadAllText(caminho[arquivo]);
        }

        public int Count(int arquivo)
        {
            return Output(arquivo).Split("\n").Length;
        }
    }
}
