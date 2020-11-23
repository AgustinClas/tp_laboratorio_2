using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Pantalon : Prenda
    {
        public bool conBolsillo;

        public bool ConBolsillo{
            get { return this.conBolsillo; }
            set { this.conBolsillo = value; }
        }

        public Pantalon()
        {

        }

        public Pantalon(ETalle talle, EEquipacion equipacion, int idStock, int numero, bool conBolsillo) : base(idStock, talle, equipacion, numero)
        {
            this.conBolsillo = conBolsillo;
        }

        public override string ToString()
        {
            if (conBolsillo)
            {
                return $"{idStock}       {talle}        {equipacion}         {numero}       Con bolsillo";
            }
            else
            { 
                return $"{idStock}       {talle}          {equipacion}        {numero}       Sin bolsillo";
            }
        }


    }
}
