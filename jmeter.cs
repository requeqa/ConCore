using System;
using System.Collections.Generic;

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
            Console.WriteLine("parametros: {0}",string.Join(",",args));
        }        
    }
}