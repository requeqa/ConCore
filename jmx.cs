using System;
using System.Xml.Linq;
using System.Xml.XPath;
namespace CorePrueba.JMeter
{
    public class JmtXml
    {
        public JmtXml()
        {
            Archivo = @"D:\JMeter\JMX\RD-0000\Ej.jmx";
            xdoc = XDocument.Load(Archivo);
            Console.WriteLine("Abriendo archivo: {0}", Archivo);
        }
        string Archivo = "";
        XDocument xdoc;
        public void Run()
        {
            cambiaVariable("Directorio", @"D:/New");
            //ChangeXpah();
        }
        void cambiaVariable(string Variable, string Valor)
        {
            try
            {
                var parametro = "//jmeterTestPlan/hashTree/TestPlan/elementProp/collectionProp/elementProp[name='" + Variable + "']/stringProp[name='Argument.value']";
                xdoc.XPathSelectElement(parametro).Value = Valor;
                Console.WriteLine("Variable {0} = \"{1}\"", Variable, Valor);
            }
            catch (Exception e) { Console.WriteLine("Error al Modificar la variable {0} con \"{1}\"; {2}", Variable, Valor, e.Message); }
        }
        void Cerrar()
        {
            xdoc.Save(Archivo);
            Console.WriteLine("Archivo Cerrado y cargado;");
        }
    }
}