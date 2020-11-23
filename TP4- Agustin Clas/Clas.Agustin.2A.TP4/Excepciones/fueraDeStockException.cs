using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class fueraDeStockException : Exception
    {
        public fueraDeStockException() : base("Este item no se se encuentra en stock") { }
    }
}
