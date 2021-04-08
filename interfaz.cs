using System;
using System.Collections.Generic;
using System.Threading;

namespace CorePrueba.Basico{
    class Menu{
        public Menu()   //Constructor
        {
            getMainStyle();
            crearTemas();
                cmd.Add("info",cmd_info);
                cmd.Add("tema",cmd_tema);
                cmd.Add("jmt",cmd_jmt);
                cmd.Add("exit",cmd_exit);
            //    cmd.GetValueOrDefault("na",cmd_void);            
            //cmdInfo.GetValueOrDefault<string,string>("na","Comando no Valido");
            cmdInfo.Add("info","Comandos disponibles: "+string.Join(" | ",cmd.Keys));
            cmdInfo.Add("cmd","Comandos disponibles: "+string.Join(" | ",cmd.Keys));
            cmdInfo.Add("temas","temas disponibles: "+string.Join(" | ",tema.Keys));
            cmdInfo.Add("jmt","Bienvenido a Zona JMeter");
            cmdInfo.Add("exit","Esta Seguro? si | no");            
        }
        #region Variables
        bool runner = true;
        string comando ="";
        object[] parametros;       
        public delegate void cmdOpt();
        public Dictionary<string, cmdOpt> cmd = new Dictionary<string, cmdOpt>();
        public delegate void jmtOpt(params object[] args);
        public Dictionary<string, jmtOpt> jmt = new Dictionary<string, jmtOpt>();
        public Dictionary<string, string> cmdInfo = new Dictionary<string,string>();
        public Dictionary<string, object[] > tema = new Dictionary<string, object[]>();
        ConsoleColor MainBG, MainFG; // 4 Reset
        #endregion
        public void executar(string Linea){
            int x=0;
            try{
                if(Linea.Substring(0,1)==" ")
                x=Linea.IndexOf(" ");
                if (x==-1){
                    jmt["asd"](new object[]{""});
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }
        public void ejecutar(string Linea){
            int x =0;
            try{

                x=Linea.IndexOf(" ");                
                    Console.WriteLine("IndexOf: {0}",x);
                comando = Linea.Substring(0,x);//.PadLeft(x);                
                    Console.WriteLine("Comando: {0}",comando);
                string xx = Linea.Substring(x,Linea.Length-x).Trim();
                    Console.WriteLine("pam: {0}",xx);
                parametros=xx.Split(new char[]{','});                
                    Console.WriteLine("parametros: {0}",string.Join(", ",parametros));
            
            }catch(Exception e){
                Console.WriteLine("no se encontro el espacio:{0}: {1}", x, e.Message);
            }            
            Console.WriteLine("Ingrese un comando");
            Console.WriteLine(cmdInfo["cmd"]);
            
            comando =  Console.ReadLine().ToLower();
            if(cmd.ContainsKey(comando)){
                cmd[comando]();
            }
            else cmd["void"]();
            Console.Write("OK, Precione una tecla para continuar.");
            Console.ReadKey();            
        }
        #region Comandos
        public void cmd_jmt(){            
            Console.WriteLine(cmdInfo["jmt"]);
            //Console.WriteLine("Im alive : {0}",string.Join(", ",));
        }
        public void cmd_void(){Console.WriteLine("Im Void ;D");}
        public void cmd_exit(){            
            Console.WriteLine( cmdInfo["exit"]);
            if("si"==Console.ReadLine().ToLower()){
                Console.WriteLine("Im not alive any more, nice to meet u. :,)");
                resetStyle();
                Thread.Sleep(2000);
                //runner = false;
                Environment.Exit(0);
            }else{Console.WriteLine("Estuvo cerca");}
        }
        public void cmd_tema(){
            try{
                Console.WriteLine( cmdInfo["temas"]);
                parametros= Console.ReadLine().Split(',');
                setStyle(tema[parametros[0].ToString()]);
                Console.WriteLine("Im alive");
            }
            catch(Exception e){
                Console.WriteLine("Valor no valido, Msj: {0}",e.Message);
            }
        }
        public void cmd_info(){

        }
        #endregion

        #region Tema
        public void getMainStyle()  //Constructor 1
        {
            MainBG = Console.BackgroundColor;
            MainFG = Console.ForegroundColor;
            //Console.WriteLine("Tema Inicial: {0} | {1}",MainBG.ToString(),MainFG.ToString());
        } 
        public void setStyle(params object[] args){
            Console.BackgroundColor = (ConsoleColor)args[0];
            Console.ForegroundColor = (ConsoleColor)args[1];
            Console.WriteLine("Tema actual: {0} | {1}",args[0].ToString(),args[1].ToString());
        }
        public void resetStyle(){
            Console.BackgroundColor=MainBG;
            Console.ForegroundColor=MainFG;
            Console.WriteLine("Regresando a Tema: {0} | {1}",MainBG.ToString(),MainFG.ToString());
        }
        private void crearTemas()   //Constructor 2
        {
            tema.Add("Azul",new object[]{ConsoleColor.Blue,ConsoleColor.White});
            tema.Add("Negro",new object[]{ConsoleColor.Black,ConsoleColor.White});
            tema.Add("Blanco",new object[]{ConsoleColor.White,ConsoleColor.Black});
            tema.Add("Matrix",new object[]{ConsoleColor.Black,ConsoleColor.Green});
        }
        #endregion
        public bool irun(){return runner;}
    }
    class jmtr{
        //  
        public static void gitClone ()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = @"/c d:\QaCore\git clone https://github.com/apache/jmeter.git";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }
        public static void gitPull ()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = @"/c d:\GIT\proj1\git pull origin master";
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }
    }



}