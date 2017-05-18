using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTAS_CIRCULARES__RUTAS_
{
    class Base
    {
        private string _Nombre;
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }

        private int _Minutos;
        public int Minutos { get { return _Minutos; } set { _Minutos = value; } }

        public Base siguiente { get; set; }
        public Base anterior { get; set; }

        public Base()
        {
            _Nombre = "";
            _Minutos = 0;
            siguiente = null;
            anterior = null;
        }

        public override string ToString()
        {
            return Nombre + ": " + Minutos + "min. "+Environment.NewLine;
        }
    }
}
