using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int dni = 0;
            bool parseOK = false;
            string myDni;
            myDni=Console.ReadLine();
            parseOK = int.TryParse(myDni,out dni);

            Console.ReadKey();
            Console.WriteLine("Dni:{0}",dni);
        }

    }
}
