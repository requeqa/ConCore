using System;
using CorePrueba.Basico;
using CorePrueba.JMeter;

namespace ConCore{
    class Program{
        static void Main(string[] args){
            bool runner =true;
            var JMT = new Jmeter();
            //var miMenu= new Menu();
            while (runner){
                Random rnd = new Random();
                // Generate five random Boolean values.                
                JMT.Run();
                //    Console.WriteLine(miMenu.cmdInfo["cmd"]);
                //    miMenu.ejecutar(Console.ReadLine());
                //    runner=miMenu.irun();
            }
        }        
    }
}