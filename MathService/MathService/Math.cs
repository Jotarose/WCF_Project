using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathService
{
    internal class Math : IMath
    {


        //https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
        public bool Prime(int value)
        {

            if (value == 0 || value == 1)
            {
                Console.WriteLine(value + " is not prime number");
                return false;
            }
            else
            {
                for (int a = 2; a <= value / 2; a++)
                {
                    if (value % a == 0)
                    {
                        Console.WriteLine(value + " is not prime number");
                        return false;
                    }

                }
                Console.WriteLine(value + " is a prime number");
                return true;
            }

        }

        public Tuple sumaInterna(Tuple tupla)
        {
            String name = tupla.Name;
            double[] resultado = new double[1];

            double sumaTupla = tupla.Data.Sum();
            resultado[0] = sumaTupla;

            Tuple tuplaFinal = new Tuple();
            tuplaFinal.Name = $"Suma interna de la tupla: {name}";
            tuplaFinal.Data = resultado;
            return tuplaFinal;
        }

    }
}
