using System;
using System.Diagnostics;
using System.IO;
//using CorePrueba.Basico;
using CorePrueba.JMeter;

namespace ConCore
{
    class Program
    {
        static void Main(string[] args)
        {            
            var jxml = new JmtXml();
            //var miMenu= new Menu();

            jxml.Run();
            /*
            var JMT = new Jmeter();
            bool runner = true;
            while (runner)
            {
                //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                CmdExe("");


                JMT.Run();
                //    Console.WriteLine(miMenu.cmdInfo["cmd"]);
                //    miMenu.ejecutar(Console.ReadLine());
                runner = !JMT.actuazlizado;
                if (!runner) Console.WriteLine("Variables actualizadas, Reinicie la aplicacion");
            }
            // */
        }
        public static void CmdExe(string File)
        { // jmeter -n -t D:\JMeter\JMX\RD-0000\Ej,jmx -l C:\Users\aaguirre\Desktop\jmt-n.XML -JHILOS=5 -J REPES=5
            string DirROOT = "D:\\JMETER\\";
            string DirJMX = DirROOT + "JMX\\";
            string DirOUT = DirROOT +"LOGS\\";
            string ArchivoJMX = DirJMX+ File+".jmx";
            string ArchivoOUT = DirOUT+ File +".csv";
            string XX = "jmeter -n -t " +  ArchivoJMX + " -l " + ArchivoOUT;
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