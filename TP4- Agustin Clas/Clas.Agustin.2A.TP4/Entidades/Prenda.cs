using System;

namespace Entidades
{
    public abstract class Prenda
    {
        public enum ETalle
        {
            S,
            M,
            L,
            XL
        }

        public enum EEquipacion
        {
            titular,
            suplente
        }

        public int numero;

        protected int idStock;
        protected ETalle talle;
        protected EEquipacion equipacion;

        public ETalle Talle
        { 
            get { return this.talle; }
            set { this.talle = value; }
        }

        public EEquipacion Equipacion
        {
            get { return this.equipacion; }
            set { this.equipacion = value; }
        }

        public int IdStock
        {
            get { return this.idStock; }
            set { this.idStock = value; }
        }

        public int Numero
        {
            get { return this.numero; }
            set 
            { 
                if (value > 0 && value < 100)
                    this.numero = value;
                else
                    this.numero = 1;
            }
        }
        public Prenda()
        {
        }

        protected Prenda(int idStock, ETalle talle, EEquipacion equipacion, int numero)
        {
            this.idStock = idStock;
            this.talle = talle;
            this.equipacion = equipacion;
            this.numero = numero;
        }

        public static bool operator ==(Prenda p1, Prenda p2)
        {
            if (p1.idStock == p2.idStock)
                return true;
            else
                return false;
        }

        public static bool operator !=(Prenda p1, Prenda p2)
        {
            return !(p1 == p2);
        }

    }
}
