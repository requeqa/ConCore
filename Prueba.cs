using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CorePrueba.Entidades
{    
    
    class Prueba
    {
        public Prueba()
        {
            //nombre = n;
            //tipo = t;
            //process = new Process();
            //startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "jmeter\\bin\\jmeter-n";
            SetVariable("JMETER_HOME","D:\\JMeter\\");//bin\\jmeter.bat
            SetVariable("JAVA_HOME","C:\\Program Files\\Java\\jdk1.8.0_102");
            //AddPath("%JMETER_HOME%\\bin;");            
        }

    #region Variables
        public bool actuazliacion {get{return actualizar;}}
        bool actualizar=false;
        string nombre;
        string tipo;
        Process process;
        ProcessStartInfo startInfo;
    #endregion
        public delegate string cmdDel(params object[] args);
        Dictionary<string, cmdDel> cmd = new Dictionary<string, cmdDel>();
        void SetVariable(string Variable, string Valor){
            try{
                string XXX = System.Environment.GetEnvironmentVariable(Variable,EnvironmentVariableTarget.User);
                if(XXX == Valor) Console.WriteLine("Ya existe {0}: \"{1}\" .",Variable,Valor);
                else{
                    System.Environment.SetEnvironmentVariable(Variable,Valor,EnvironmentVariableTarget.User);
                    Console.WriteLine("Variable Creada {0}: \"{1}\"",Variable,Valor);
                    actualizar=true;
                }
            }catch(Exception e){
                Console.WriteLine("Error al crear varialbe {0}:\"{1}\"; {2}",Variable,Valor,e.Message);
            }
        }
        void AddPath(string Valor){
            try{
                string XXX=System.Environment.GetEnvironmentVariable("Path",EnvironmentVariableTarget.Machine);
                if(XXX.Contains(Valor))Console.WriteLine("Path: {0} ya existe.",Valor);
                else{
                    System.Environment.SetEnvironmentVariable("Path",Valor+XXX,EnvironmentVariableTarget.Machine);
                    Console.WriteLine("Path: \"{0}\" Agregado ",Valor);
                }

            }catch(Exception e){                
                Console.WriteLine("Error al Agregar Path {0}; {1}",Valor,e.Message);
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

/*

C:\Program Files (x86)\Common Files\Oracle\Java\javapath;C:\Program Files\Microsoft MPI\Bin\;C:\ProgramData\Oracle\Java\javapath;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\iCLS\;C:\Program Files\Intel\Intel(R) Management Engine Components\iCLS\;%SystemRoot%\system32;%SystemRoot%;%SystemRoot%\System32\Wbem;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\;%SYSTEMROOT%\System32\OpenSSH\;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files (x86)\Sennheiser\SoftphoneSDK\;C:\Program Files (x86)\Microsoft SQL Server\Client SDK\ODBC\130\Tools\Binn\;C:\Program Files (x86)\Microsoft SQL Server\130\Tools\Binn\;C:\Program Files (x86)\Microsoft SQL Server\130\DTS\Binn\;C:\Program Files (x86)\Microsoft SQL Server\130\Tools\Binn\ManagementStudio\;C:\Program Files\dotnet\;C:\Program Files\Microsoft SQL Server\130\Tools\Binn\;C:\Program Files\Java\jdk1.8.0_102\bin;C:\Program Files\nodejs\;

*/