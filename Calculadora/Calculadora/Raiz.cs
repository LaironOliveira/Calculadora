using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Raiz
    {
        private string Label1 = "";
        private string Label2 = "";

        public string getLabel1() 
        { 
            return Label1; 
        }
        public string getLabel2()
        {
            return Label2;
        }
        public void Calc(string operacao, string Label_Resultado, string Label_Calculando)
        {
            double resultado = double.Parse(Label_Resultado);
            Label2 = "sqrt(" + resultado.ToString() + ")";
            resultado = Math.Sqrt(resultado);
            Label1 = resultado.ToString("N2");
        }
    }
}
