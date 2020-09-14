using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        #region Constructores

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numValidado;

            if (!(double.TryParse(strNumero, out numValidado)))
            {
                numValidado = 0;
            }

            return numValidado;
        }

        #endregion

        #region Operadores

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1.numero + n2.numero;
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado = n1.numero - n2.numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1.numero * n2.numero;
            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = 0;
            }

            return resultado;
        }

        #endregion

        private static bool EsBinario(string binario)
        {
            StringBuilder auxBinario = new StringBuilder(binario);
            bool esBinario = true;

            for (int i = (auxBinario.Length - 1); i >= 0; i--)
            {
                if (auxBinario[i] != '1' && auxBinario[i] != '0')
                {
                    esBinario = false;
                }
                break;
            }

            return esBinario;
        }

        public static string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            double resto;
            double numeroEntero = Math.Floor(numero);

            if (numeroEntero > 0)
            {
                while (numeroEntero > 1)
                {
                    resto = numeroEntero % 2;
                    numeroEntero = Math.Floor(numeroEntero / 2);

                    numeroBinario = resto.ToString() + numeroBinario;
                }

                numeroBinario = numeroEntero.ToString() + numeroBinario;
            }
            else
            {
                numeroBinario = "Numero invalido";
            }
            return numeroBinario;
        }

        public static string DecimalBinario(string numero)
        {
            return DecimalBinario(double.Parse(numero));
        }

        public static string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
            string numeroDecimalStr = "Valor invalido";
            char[] numeroBinario = binario.ToCharArray();


            if (Numero.EsBinario(binario))
            {
                Array.Reverse(numeroBinario);

                for(int i=0; i < numeroBinario.Length; i++)
                {
                    if(numeroBinario[i] == '1')
                    {
                        numeroDecimal += (int)Math.Pow(2, i);
                    }
                }

                numeroDecimalStr = "" + numeroDecimal;
            }

            return numeroDecimalStr;
        }
    }
}
