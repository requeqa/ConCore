using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CorePrueba.Entidades
{    
    
    class Prueba
    {
        public Prueba(string n, string t)
        {
            nombre = n;
            tipo = t;
            process = new Process();
            startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "jmeter\\bin\\jmeter-n";
            SetVariable("JMETER_HOME","D:\\apache-jmeter-5.4.1\\bin");
            SetVariable("JAVA_HOME","C:\\Program Files\\Java\\jdk1.8.0_102");
            
        }
    #region Variables
        string nombre;
        string tipo;
        Process process;
        ProcessStartInfo startInfo;
    #endregion
        public delegate string cmdDel(params object[] args);
        Dictionary<string, cmdDel> cmd = new Dictionary<string, cmdDel>();
        public void SetVariable(string Variable, string valor){
            try{
                string XXX;
                XXX = System.Environment.GetEnvironmentVariable(Variable,EnvironmentVariableTarget.User);
                if(XXX == valor) Console.WriteLine("Variable {0} ya existe.",Variable);
                else{
                    System.Environment.SetEnvironmentVariable(Variable,valor,EnvironmentVariableTarget.User);
                    Console.WriteLine("Variable \"{0}\" Creada ",Variable);
                }
            }catch(Exception e){
                Console.WriteLine("Error al crear varialbe {0}; {1}",Variable,e.Message);
            }
        }
        public void timbreMario()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Thread.Sleep(65);
            Console.Beep(659, 250);
            Thread.Sleep(65);
            Console.Beep(523, 125);
            Console.Beep(659, 250);
            Console.Beep(784, 500);
            Thread.Sleep(125);
            Console.Beep(392, 250);
        }
        public void Saludo()
        {
            Console.WriteLine("Hello World!, Iniciando Prueba {0} de tipo {1}", nombre, tipo);
        }
        public void execCMD(string strCmdText)
        {
            string comando = "D:\\apache-jmeter-5.4.1\\bin\\jmeter-n.cmd";
            string parametros = "";
            try
            {                     
                Process.Start(comando,parametros);
                //Console.WriteLine(cmd[""]);
                //strCmdText = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
                //System.Diagnostics.Process.Start("CMD.exe",comando);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar \"{0}\"; {1}", comando,e.Message);
            }
        }  
    }
    
}
//7431