using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace MathService
{
    public class Math : IMath
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
            tuplaFinal.Name = $"Suma interna de {name}";
            tuplaFinal.Data = resultado;
            return tuplaFinal;
        }

        public double[] resolverEcuaciones(Tuple tupla)
        {
            //Datos
            // Extraer la matriz de ecuaciones y el vector de datos de la tupla
            Matrix<double> ecuaciones = tupla.Equation;
            double[] datos = tupla.Data;

            // Resolver el sistema de ecuaciones
            Vector<double> resultado = ecuaciones.Solve(Vector<double>.Build.DenseOfArray(datos));

            // Convertir el resultado a un array de doubles
            double[] soluciones = resultado.ToArray();

            return soluciones;

        }

    }
}
