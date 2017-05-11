using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCircularEnlazadaDoble
{
    class Base
    {
        private string _nombre;
        DateTime _fecha;


        public DateTime Fecha { get { return _fecha; } }

        private int _minutos;
        public int Minutos { get { return _minutos; } set { _minutos = value; } }

        private Base _siguiente;
        public Base Siguiente { get { return _siguiente; } set { _siguiente = value; } }

        private Base _anterior;
        public Base Anterior { get { return _anterior; } set { _anterior = value; } }


        public Base()
        {
            this._nombre = string.Empty;
            this._siguiente = null;
            this._fecha = new DateTime();
        }

        public void setNombre(string nombre)
        {
            this._nombre = nombre;
        }

        public string getNombre()
        {
            return this._nombre;
        }

        public void setFecha(DateTime fecha)
        {
            this._fecha = fecha;
        }

        public override string ToString()
        {
            return _nombre + " " + _fecha.Hour + ":" + _fecha.Minute;
        }
    }
}
