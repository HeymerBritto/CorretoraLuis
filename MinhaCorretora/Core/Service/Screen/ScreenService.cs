using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaCorretora.Core.Service.Screen
{
    public class ScreenService
    {
        public int ImprimirMenu(string texto, int[] condicao)
        {
            int resposta;
            bool atendeuCondicao = false;

            do
            {
                Console.Clear();
                Console.WriteLine(texto);

                resposta = ConverterValorDigitado(texto);

                foreach (var valor in condicao)
                {
                    if (valor == resposta)
                    {
                        atendeuCondicao = true;
                        continue;
                    }
                }
            }
            while (atendeuCondicao == false);

            return resposta;
        }

        public int ConverterValorDigitado(string menu)
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor informado inválido, tente novamente!");
                Console.ForegroundColor = ConsoleColor.White;

                return ConverterValorDigitado(menu);
            }
        }
    }
}
