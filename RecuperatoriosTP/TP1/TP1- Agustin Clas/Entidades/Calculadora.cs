using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            string operadorValidado;

            if (operador == '*')
            {
                operadorValidado = "*";

            }else if(operador == '/')
            {
                operadorValidado = "/";

            }
            else if (operador == '-')
            {
                operadorValidado = "-";

            }
            else
            {
                operadorValidado = "+";
            }

            return operadorValidado;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            StringBuilder operadorAux;

            if (operador != "")
                operadorAux = new StringBuilder(operador);
            else
                operadorAux = new StringBuilder("+");

            operador = ValidarOperador(operadorAux[0]);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            
            return resultado;
        }
    }
}
