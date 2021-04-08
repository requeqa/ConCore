using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace CorePrueba.JMeter
{
    class Jmeter
    {
        public Jmeter(){Bibliotecas();}
        void Bibliotecas()
        {
            //  Metodos
            jmt.Add("ach", jmt_ACH);

            //  Directorio de jmx
            jmx.Add("ach-desa-pre-mld", "ach-desa-pre-mld.jmx");
            jmx.Add("ach-Pre-desa-mld", "ach-Pre-desa-mld.jmx");
            jmx.Add("ach-desa-pre-accl", "ach-desa-pre-accl.jmx");
            jmx.Add("ach-pre-desa-accl", "ach-pre-desa-accl.jmx");
            SetVariable("JMETER_HOME", "D:\\JMeter\\");//bin\\jmeter.bat
            SetVariable("JAVA_HOME", "C:\\Program Files\\Java\\jdk1.8.0_102");
        }
        public delegate void jmtOpt(params object[] args);
        public Dictionary<string, jmtOpt> jmt = new Dictionary<string, jmtOpt>();
        public Dictionary<string, string> jmx = new Dictionary<string, string>();
        public void Run()
        {
            Console.WriteLine("Bievenido al modulo de Jmeter");
            Console.WriteLine("Comandos disponibles: {0}",string.Join(" | ",jmt.Keys));
            string comando;
            object[] argumentos = null;
            comando = Console.ReadLine().Trim().ToLower();

            int Space = comando.IndexOf(" ");
            Console.WriteLine("Espacio en {0}", Space);
            if (Space > 0)
            {
                argumentos = comando.Substring(Space, comando.Length-Space).Split(',');                
                comando = comando.Substring(0, Space);
            }
            if (jmt.ContainsKey(comando))
            {
                Console.WriteLine("Comando: {0}", comando);
                jmt[comando](argumentos);
            }
        }
        void jmt_ACH(params object[] args)
        {
            Console.WriteLine("Tamos Dentro de ACH :v");
            Console.WriteLine();
            Console.WriteLine("parametros: {0}", string.Join(",", args));
        }
        //-----------------------------------------------------------------------------------------------
        //-----------------------------------   JMT   ---------------------------------------------------
        //-----------------------------------------------------------------------------------------------
        #region JMT_Variables
        public bool actuazlizado { get { return actualizar; } }
        bool actualizar = false;
        string nombre, tipo;
        Process process;
        ProcessStartInfo startInfo;
        public delegate string cmdDel(params object[] args);
        Dictionary<string, cmdDel> cmd = new Dictionary<string, cmdDel>();
        #endregion
        #region JMT_Update

        void SetVariable(string Variable, string Valor)
        {
            try
            {
                string XXX = System.Environment.GetEnvironmentVariable(Variable, EnvironmentVariableTarget.User);
                if (XXX == Valor) Console.WriteLine("Ya existe {0}: \"{1}\" .", Variable, Valor);
                else
                {
                    System.Environment.SetEnvironmentVariable(Variable, Valor, EnvironmentVariableTarget.User);
                    Console.WriteLine("Variable Creada {0}: \"{1}\"", Variable, Valor);
                    actualizar = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al crear varialbe {0}:\"{1}\"; {2}", Variable, Valor, e.Message);
            }
        }
        void AddPath(string Valor)
        {
            try
            {
                string XXX = System.Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
                if (XXX.Contains(Valor)) Console.WriteLine("Path: {0} ya existe.", Valor);
                else
                {
                    System.Environment.SetEnvironmentVariable("Path", Valor + XXX, EnvironmentVariableTarget.User);
                    Console.WriteLine("Path: \"{0}\" Agregado ", Valor);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al Agregar Path {0}; {1}", Valor, e.Message);
            }
        }
        #endregion

    }
    

}