using System;
using System.Diagnostics;
using CorePrueba.Basico;
using CorePrueba.JMeter;

namespace ConCore
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runner = true;
            var JMT = new Jmeter();
            var miMenu = new Menu();
            runner = !JMT.actuazlizado;
            if (!runner) Console.WriteLine("Variables actualizadas, Reinicie la aplicacion");
            while (runner)
            {
                JMT.Run();
                //    Console.WriteLine(miMenu.cmdInfo["cmd"]);
                //    miMenu.ejecutar(Console.ReadLine());
                // */
            }
            Console.WriteLine("Gracias vuelva prontos :D");
        }
    }
}