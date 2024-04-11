using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MathService.Math)))
            {
                host.Open();

                Console.WriteLine("Servicio ejecutándose. Pulsa <enter- para terminar");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}
