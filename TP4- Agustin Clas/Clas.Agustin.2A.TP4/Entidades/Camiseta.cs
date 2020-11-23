using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Camiseta : Prenda
    {

        public bool mangaLarga;

        public bool MangaLarga
        {
            get { return this.mangaLarga; }
            set { this.mangaLarga = value; }
        }

        public Camiseta()
        {

        }

        public Camiseta(ETalle talle, EEquipacion equipacion, int idStock, int numero, bool mangaLarga) : base(idStock, talle, equipacion, numero)
        {
            this.mangaLarga = mangaLarga;
        }

        public override string ToString()
        {
            if (mangaLarga)
            {
                return $"{idStock}       {talle}        {equipacion}       {numero}       Manga larga";
            }
            else
            {
                return $"{idStock}       {talle}         {equipacion}       {numero}       Manga corta";
            }
        }
    }
}
