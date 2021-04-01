using System;
using System.Diagnostics;
using System.IO;
using CorePrueba.Basico;
using CorePrueba.Entidades;
using CorePrueba.JMeter;

namespace ConCore{
    class Program{
        static void Main(string[] args){
            bool runner =true;
            var JMT = new Jmeter();
            var prueba = new Prueba();    
            //var miMenu= new Menu();
            while (runner){
                //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                CmdExe();
                
                
                JMT.Run();
                //    Console.WriteLine(miMenu.cmdInfo["cmd"]);
                //    miMenu.ejecutar(Console.ReadLine());
                runner=!prueba.actuazliacion;
                if(!runner) Console.WriteLine("Variables actualizadas, Reinicie la aplicacion");                
            }
        }
        public static void CmdExe ()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            //startInfo.Arguments = @"/c d:\GIT\proj1\git pull origin master";
            //startInfo.Arguments = @"/c d:\JMeter\bin\jmeter";//.cmd -t d:\JMX\ej.jmx";
            startInfo.Arguments = @"/c jmeter";//.cmd -t d:\JMX\ej.jmx";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }
    }
}