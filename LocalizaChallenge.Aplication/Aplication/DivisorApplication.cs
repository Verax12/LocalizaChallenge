using LocalizaChallenge.Aplication.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LocalizaChallenge.Aplication.Aplication
{
    public class DivisorApplication : IDivisorApplication
    {

        /// <summary>
        /// Metodo Inicial que é chamado pelo Controllador
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string Divisores(double num)
        {
            int armazena = new int();

            List<int> resultadosDivisores = DescobreDivisores(num, armazena);
            List<int> resultadoPrimos = Primos(resultadosDivisores);

            return PreparaRetorno(resultadosDivisores, resultadoPrimos, num);
        }

        /// <summary>
        /// Prepara uma String para retornar ao Controllador
        /// </summary>
        /// <param name="resultadosDivisores"></param>
        /// <param name="resultadoPrimos"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private string PreparaRetorno(List<int> resultadosDivisores, List<int> resultadoPrimos, double num)
        {
            return @"Os divisores de " + num + " são:" + JsonConvert.SerializeObject(resultadosDivisores) + "\n" +
                            "E os divisores primos são: " + JsonConvert.SerializeObject(resultadoPrimos);

        }


        /// <summary>
        /// Metodo que descobre os divisores de algum numero
        /// </summary>
        /// <param name="num"></param>
        /// <param name="armazena"></param>
        /// <returns></returns>
        private static List<int> DescobreDivisores(double num, int armazena)
        {
            ///Lista para armazenar os resultados
            List<int> resultados = new List<int>();

            for (double i = 1; i <= num; i++)
            {
                double possivelDivisor = num / i;
                
                //Verifico se o possivel divisor é um numero inteiro se for, adiciono na lista de resultados.
                if (int.TryParse(possivelDivisor.ToString(), out armazena))
                {
                    resultados.Add(armazena);
                }
            }

            return resultados;
        }


        /// <summary>
        /// Metodo para descobrir os numeros Primos
        /// </summary>
        /// <param name="divisores"></param>
        /// <returns></returns>
        private List<int> Primos(List<int> divisores)
        {
            List<int> resultados = new List<int>();

            int armazena = new int();

            foreach (var item in divisores)
            {
                //Aproveito o meu metodo de descobrir divisores para verificar quantos divisores os meus divisores possuem.
                List<int> possiveisPrimos = DescobreDivisores(item, armazena);

                //Se for apenas dois divisores eu adiciono ele na lista de resultados.
                if (possiveisPrimos.Count.Equals(2))
                {
                    resultados.Add(item);
                }

            }

            return resultados;
        }

    }
}
