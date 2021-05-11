using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace CorePrueba.JMeter
{
    class Jmeter
    {
        public Jmeter() { Bibliotecas(); }
        #region JMT_Variables
        public delegate void jmtOpt(params object[] args);
        public Dictionary<string, jmtOpt> JMT = new Dictionary<string, jmtOpt>();
        public Dictionary<string, string[]> JMX = new Dictionary<string, string[]>();
        public Dictionary<string, string> JMX_Info = new Dictionary<string, string>();
        public bool actuazlizado { get { return actualizar; } }
        bool actualizar = false;
        //string nombre, tipo;
        Process process;
        ProcessStartInfo startInfo;
        public delegate string cmdDel(params object[] args);
        Dictionary<string, cmdDel> cmd = new Dictionary<string, cmdDel>();
        #endregion
        public void Run()
        {
            Console.WriteLine("Bievenido al modulo de Jmeter");
            Console.WriteLine("Comandos disponibles: {0}", string.Join(" | ", JMT.Keys));
            string comando;
            object[] argumentos = null;
            comando = Console.ReadLine().Trim().ToLower();

            int Space = comando.IndexOf(" ");
            //Console.WriteLine("Espacio en {0}", Space);
            if (Space > 0)
            {
                argumentos = comando.Substring(Space, comando.Length - Space).Split(',');
                comando = comando.Substring(0, Space);
            }
            if (JMT.ContainsKey(comando))
            {
                //Console.WriteLine("Comando: {0}", comando);
                JMT[comando](argumentos);
            }
        }
        void Bibliotecas()
        {
            JMT.Add("ach", jmt_ACH);
            JMT.Add("tcf", jmt_TCF);
            JMX_Prop();
            // SetVariable("JMETER_HOME", "D:\\JMeter\\");//bin\\jmeter.bat
            //SetVariable("JAVA_HOME", "C:\\Program Files\\Java\\jdk1.8.0_102");
        }
        void jmt_ACH(params object[] args)
        {
            String comando;
            bool OK = true;
            Console.WriteLine("Bienvenido al modulo de ACH :D");
            do
            {
                if (args == null)
                {
                    // Ofrecer Comandos
                    Console.WriteLine("Comandos disponibles:");
                    foreach (KeyValuePair<string, string> kvp in JMX_Info) Console.WriteLine(" {0,-20} : {1}", kvp.Key, kvp.Value);
                    //Leer Comando
                    comando = Console.ReadLine().Trim().ToLower();
                }
                else
                {
                    comando = args[0].ToString();
                    //Ejecutar comando 
                }
                if (!JMX.ContainsKey(comando))
                {
                    OK = false;
                    Console.WriteLine("No es una Accion ACH Valida\nporfavor intente otra vez");
                }
            }
            while (!OK);
            CmdExe("EJ ACH");
            // AQUI CORRER CMD!!!!!!


            //Console.WriteLine("parametros: {0}", string.Join(",", args));
        }
        string getParams(string comando){
            return"";
        }
        void jmt_TCF(params object[] args) // Pruebas apra tarjetas TCF
        {
            Console.WriteLine("Targetas de Credito Fassil, aun en produccion");
            Console.WriteLine("Precione una tecla para continuar");
            Console.ReadKey();
            //Console.WriteLine("Comandos disponibles: {0}", string.Join(" | ", jmx.Keys));
            //Console.WriteLine("parametros: {0}", string.Join(",", args));
        }
        void JMX_Prop()
        {
            JMX.Add("desa-pre-mld", new string[] { "MLD1035", "Roy Guido", "4885681", "10", "2", "sqlcnx" });
            JMX.Add("desa-pre-accl", new string[] { "1035", "Roy Guido", "4885681", "10", "1", "sqlcnxaccl" });
            JMX.Add("pre-desa-mld", new string[] { "MLD91035", "Roy Guido", "4885681", "10", "2", "sqlcnxPRE" });
            JMX.Add("pre-desa-accl", new string[] { "3510", "Roy Guido", "4885681", "10", "1", "sqlcnxPRE" });

            JMX_Info.Add("desa-pre-mld", "Alasita > FASSIL, Por Camara MLD");
            JMX_Info.Add("desa-pre-accl", "Alasita > FASSIL, Por Camara ACCL");
            JMX_Info.Add("pre-desa-mld", "FASSIL > Alasita, Por Camara MLD");
            JMX_Info.Add("pre-desa-accl", "FASSIL > Alasita, Por Camara ACCL");

            JMX.Add("desa-accl-pre-mld", new string[] { "MLD1035", "Roy Guido", "4885681", "10", "1", "sqlcnxaccl" });
            JMX.Add("desa-mld-pre-accl", new string[] { "1035", "Roy Guido", "4885681", "10", "2", "sqlcnx" });
            JMX.Add("pre-accl-desa-mld", new string[] { "MLD91035", "Roy Guido", "4885681", "10", "1", "sqlcnxPRE" });
            JMX.Add("pre-mld-desa-accl", new string[] { "3510", "Roy Guido", "4885681", "10", "2", "sqlcnxPRE" });
            JMX_Info.Add("desa-accl-pre-mld", "Alasita ACCL > Fassil MLD");
            JMX_Info.Add("desa-mld-pre-accl", "Alasita MLD > Fassil ACCL");
            JMX_Info.Add("pre-accl-desa-mld", "Fassil ACCL > Alasita MLD");
            JMX_Info.Add("pre-mld-desa-accl", "Fassil MLD > Alasita ACCL");

            //JMX.Add("inter-mld-accl", new string[] { "1035", "Roy Guido", "4885681", "10", "2", "sqlcnxaccl" });
            //JMX_Info.Add("inter-mld-accl", "");

            JMX.Add("custom", new string[] { });
            JMX_Info.Add("custom", "Consulta personalizada");
        }
        string[] ACH_Prop() // para consulta personalizada
        {
            string[] args = { "", "", "", "", "", "" };
            Console.WriteLine("Introduzca los parametros en orden como en el ejemplo,");
            Console.WriteLine("Tambien puede introducrlos en diferentes lineas.");
            Console.WriteLine("{0-30},{1-21},{2-9},{3-7},{4-18},{5-22}", new string[] { "[Camara destino]", "[Nombre destinatario]", "[Cuenta]", "[Monto]", "[Camara de salida]", "[Base de datos]" });
            Console.WriteLine("{0-30},{1-21},{2-9},{3-7},{4-18},{5-22}", new string[] { "[MLD1035|1035|MLD91035|3510]", "[ej: Juan Peres]", "[4885681]", "[ej:10]", "[Por 1=ACCL|2=MLD]", "[1=pre|2=desaMLD|3=desaACCL]" });
            do
            {
                Console.WriteLine("{0-30},{1-21},{2-9},{3-7},{4-18},{5-22}", new string[] { "[Camara destino]", "[Nombre destinatario]", "[Cuenta]", "[Monto]", "[Camara de salida]", "[Base de datos]" });
                Console.WriteLine("{0-30},{1-21},{2-9},{3-7},{4-18},{5-22}", args);

                args = Console.ReadLine().ToLower().Split(",");

            }
            while (args.Length != 6);
            switch (args[5])
            {
                case "pre":
                    args[5] = "sqlcnxPRE";
                    break;
                case "desamld":
                    args[5] = "sqlcnx";
                    break;
                case "desaaccl":
                    args[5] = "sqlcnxaccl";
                    break;
                default:
                    break;
            }
            return args;
        }//""


        //EJECUTAR JMETER CON PROPIEDADES
        public void CmdExe(string File, string parametros = "", bool oFile = false)
        { // jmeter -n -t D:\JMeter\JMX\RD-0000\Ej,jmx -l C:\Users\aaguirre\Desktop\jmt-n.XML -JHILOS=5 -J REPES=5
            string DirROOT = "D:\\JMETER\\";
            string DirJMX = DirROOT + "JMX\\";
            string DirLOG = DirROOT + "LOGS\\";
            string ArchivoJMX = DirJMX + File + ".jmx";
            string ArchivoOUT = DirLOG + File + ".csv";
            string cmdJmt = "jmeter -n -t \"" + ArchivoJMX + "\" " + parametros;
            cmdJmt = oFile ? " -l " + ArchivoOUT : "";
            process = new Process();
            startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "CMD.exe";
            //startInfo.Arguments = @"/c d:\GIT\proj1\git pull origin master";
            //startInfo.Arguments = @"/c d:\JMeter\bin\jmeter";//.cmd -t d:\JMX\ej.jmx";
            //startInfo.Arguments = @"/c jmeter";//.cmd -t d:\JMX\ej.jmx";
            startInfo.Arguments = cmdJmt;
            process.StartInfo = startInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            process.WaitForExit();
        }


        void SetVariable(string Variable, string Valor)
        {
            try
            {
                string XXX = Environment.GetEnvironmentVariable(Variable, EnvironmentVariableTarget.User);
                if (XXX == Valor) Console.WriteLine("Ya existe {0}: \"{1}\" .", Variable, Valor);
                else
                {
                    Environment.SetEnvironmentVariable(Variable, Valor, EnvironmentVariableTarget.User);
                    Console.WriteLine("Variable Creada {0}: \"{1}\"", Variable, Valor);
                    actualizar = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al crear varialbe {0}:\"{1}\"; {2}", Variable, Valor, e.Message);
            }
        }//*/
        void AddPath(string Valor)
        {
            try
            {
                string XXX = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
                if (XXX.Contains(Valor)) Console.WriteLine("Path: {0} ya existe.", Valor);
                else
                {
                    Environment.SetEnvironmentVariable("Path", Valor + XXX, EnvironmentVariableTarget.User);
                    Console.WriteLine("Path: \"{0}\" Agregado ", Valor);
                    actualizar = true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al Agregar Path {0}; {1}", Valor, e.Message);
            }
        }

    }
}