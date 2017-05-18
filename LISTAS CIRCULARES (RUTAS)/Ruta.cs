using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTAS_CIRCULARES__RUTAS_
{
    class Ruta
    {
        public Base inicio;
        public Base ultimo;

        public void Agregar(Base nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.anterior = ultimo;
                inicio.siguiente = ultimo;
                ultimo = inicio;
                ultimo.anterior = inicio;
                ultimo.siguiente = inicio;
            }
            else
            {
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                ultimo = nuevo;
                ultimo.siguiente = inicio;
            }

        }

        public Base Buscar(string nombre)
        {
            Base buscado = null;
            Base temp = inicio;

                while (temp.Nombre != nombre)
                {
                    temp = temp.siguiente;
                }
                    buscado = temp;

            return buscado;
        }

        public string Reporte()
        {
            string datos = "";
            Base temp = inicio;

            while (temp!=ultimo)
            {
                datos += temp.ToString();
                temp = temp.siguiente;
            }
            return datos;
        }

        public void Eliminar(string nombre)
        {
            Base temp = inicio;
            if (inicio.Nombre == nombre)
            {
                inicio = inicio.siguiente;
            }
            else
                while (temp.siguiente.Nombre != nombre)
                {
                    temp = temp.siguiente;
                }
            temp.siguiente = temp.siguiente.siguiente;
            temp.siguiente.anterior = temp;
        }

        public void AgregarInicio(Base nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.anterior = ultimo;
                inicio.siguiente = ultimo;
                ultimo = inicio;
                ultimo.anterior = inicio;
                ultimo.siguiente = inicio;
            }
            else
            {
                nuevo.siguiente = inicio;
                inicio = nuevo;
                inicio.anterior = ultimo;
            }
        }

        public void EliminarUltimo()
        {
            ultimo = ultimo.anterior;
            ultimo.siguiente = inicio;
        }

        public void EliminarPrimero()
        {
            inicio = inicio.siguiente;
            inicio.anterior = ultimo;
        }

        public void InsertarDespuesDe(string nombre, Base nuevo)
        {
            Base temp = inicio;

            while (temp.siguiente.Nombre != nombre)
            {
                temp = temp.siguiente;
            }
            //nuevo.siguiente = temp.siguiente.siguiente;
            //temp.siguiente.siguiente = nuevo;
            nuevo.siguiente = temp.siguiente;
            nuevo.anterior = temp;
        }

        public string Recorrido(string nombre, DateTime inicioH, DateTime finalH)
        {
            string datos = "";
            string error = "Error";
            Base temp = inicio;

            while (temp != ultimo)
            {
                if (nombre == temp.Nombre)
                {
                    while (inicioH < finalH)
                    {
                        inicioH = inicioH.AddMinutes(temp.Minutos);
                        if (inicioH <= finalH)
                        {
                            datos += temp + inicioH.ToShortTimeString() + Environment.NewLine.ToString();
                            temp = temp.siguiente;
                        }
                    }
                    return datos;
                }
                temp = temp.siguiente;
            }
            return error;
        }
    }
}
