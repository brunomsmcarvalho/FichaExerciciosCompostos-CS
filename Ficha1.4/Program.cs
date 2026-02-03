using System;
using System.Text;

namespace Ficha1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            var agencia = new AgenciaImobiliaria();
            agencia.Menu();
        }
    }
}