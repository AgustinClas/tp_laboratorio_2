using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Stock<T> where T : Prenda
    {
        public List<T> prendas;

        public Stock()
        {
            prendas = new List<T>();
        }

        public List<T> Prendas
        {
            get { return this.prendas; }
            set { this.prendas = value; }
        }


        public bool buscarPrenda(int id, out T prenda)
        {
            bool retorno = false;
            prenda = default;

            foreach(T p in this.prendas)
            {
                if(p.IdStock == id)
                {
                    prenda = p;
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public Camiseta agregarCamiseta(string numero, Prenda.ETalle talle, Prenda.EEquipacion equipacion, string manga)
        {
            int auxNum = 0;
            int auxManga = 0;
            Camiseta camiseta;

            int.TryParse(numero, out auxNum);
            
            if(manga == "Manga larga")
            {
                auxManga = 1;
            }

            if (auxManga == 1)
                camiseta = new Camiseta(talle, equipacion, 10000, auxNum, true);
            else
                camiseta = new Camiseta(talle, equipacion, 10000, auxNum, false);

            return camiseta;
        }

        public Pantalon agregarPantalon(string numero, Prenda.ETalle talle, Prenda.EEquipacion equipacion, string bolsillo)
        {
            int auxNum = 0;
            int auxBolsillo = 0;
            Pantalon pantalon;

            int.TryParse(numero, out auxNum);

            if (bolsillo == "Con bolsillo")
            {
                auxBolsillo = 1;
            }

            if (auxBolsillo == 1)
                pantalon = new Pantalon(talle, equipacion, 10000, auxNum, true);
            else
               pantalon = new Pantalon(talle, equipacion, 10000, auxNum, false);

            return pantalon;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id    Talle    Equipacion   Numero    Manga/Bolsillo");

            foreach(T item in this.prendas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static Stock<T> operator +(Stock<T> stock, T p)
        {
            bool noIncluido = true;

            foreach(T item in stock.prendas)
            {
                if (item == p)
                {
                    noIncluido = false;
                    break;
                }
            }

            if (noIncluido)
            {
                stock.prendas.Add(p);
            }

            return stock;
        }

        public static Stock<T> operator -(Stock<T> stock, T p)
        {
            if (stock.prendas.Contains(p)){
                stock.prendas.Remove(p);
            }

            return stock;
        }
    }
}
