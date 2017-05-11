﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaCircularEnlazadaDoble
{
    public partial class FormMain : Form
    {
        Ruta listaRuta = new Ruta();
        string cadena;
        bool fechaGuardar;
        DateTime fechaTemp;

        public FormMain()
        {
            InitializeComponent();
            cadena = string.Empty;
            fechaGuardar = false;

            dTimerFecha.Value = fechaTemp = DateTime.Now;

            txtHora.Text = dTimerFecha.Value.Hour.ToString();
            txtMinutos.Text = dTimerFecha.Value.Minute.ToString();
            txtSegundos.Text = dTimerFecha.Value.Second.ToString();
        }

        private void bttonInsertarDespuesDe_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            DateTime fecha = dTimerFecha.Value;

            nuevo.setNombre(txtNombre.Text);
            nuevo.setFecha(fecha);
            nuevo.Minutos = Convert.ToInt16(txtAddMinutos.Text);

            listaRuta.insertarDespuesDe(txtNombreD.Text, nuevo);
        }

        private void bttonAgregar_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            DateTime fecha = dTimerFecha.Value;

            nuevo.setNombre(txtNombre.Text);
            nuevo.setFecha(fecha);
            nuevo.Minutos = Convert.ToInt16(txtAddMinutos.Text);

            listaRuta.Agregar(nuevo);

            txtNombre.Text = string.Empty;
            fechaGuardar = true;
        }

        private void bttonAddPrincipio_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            DateTime fecha = dTimerFecha.Value;

            nuevo.setNombre(txtNombre.Text);
            nuevo.setFecha(fecha);
            nuevo.Minutos = Convert.ToInt16(txtAddMinutos.Text);

            listaRuta.agregarInicio(nuevo);
            fechaGuardar = true;
        }

        private void bttonAddFinal_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            DateTime fecha = dTimerFecha.Value;

            nuevo.setNombre(txtNombre.Text);
            nuevo.setFecha(fecha);
            nuevo.Minutos = Convert.ToInt16(txtAddMinutos.Text);

            listaRuta.agregarFinal(nuevo);
            fechaGuardar = true;
        }

        private void bttonBuscar_Click(object sender, EventArgs e)
        {
            Base temp = listaRuta.Buscar(txtNombre.Text);

            if (temp != null)
            {
                txtHora.Text = temp.Fecha.Hour.ToString();
                txtSegundos.Text = "00";
                txtMinutos.Text = temp.Fecha.Minute.ToString();
                txtAddMinutos.Text = temp.Minutos.ToString();
                dTimerFecha.Value = temp.Fecha;

                timer1.Enabled = false;
            }
            else
                MessageBox.Show("No se encontraron resultados o elemento no existe", 
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void bttonEliminar_Click(object sender, EventArgs e)
        {
            listaRuta.Eliminar(txtNombre.Text);
        }

        private void bttonEliminarPrimero_Click(object sender, EventArgs e)
        {
            listaRuta.eliminarPrimero();
        }

        private void bttonEliminarUltimo_Click(object sender, EventArgs e)
        {
            listaRuta.eliminarUltimo();
        }

        private void bttonMostrarReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = listaRuta.ToString();
        }

        private void bttonRecorrido_Click(object sender, EventArgs e)
        {
            txtReporte.Text = listaRuta.recorrido(txtNombreRecorrido.Text, dHoraInicio.Value, dHoraFinal.Value);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(txtAddMinutos.Text == string.Empty)
            {
                if(listaRuta.Count == 0)
                    dTimerFecha.Value = dTimerFecha.Value.AddSeconds(1);

                txtSegundos.Text = dTimerFecha.Value.Second.ToString();
            }
            else
                txtSegundos.Text = "00";

            txtHora.Text = dTimerFecha.Value.Hour.ToString();
            txtMinutos.Text = dTimerFecha.Value.Minute.ToString();

            if (txtAddMinutos.Text != cadena)
            {
                if (!fechaGuardar)
                {
                    if (listaRuta.Count == 0)
                        fechaTemp = DateTime.Now;

                    dTimerFecha.Value = fechaTemp;
                }
                else
                    fechaTemp = dTimerFecha.Value;

                if (txtAddMinutos.Text != "")
                    dTimerFecha.Value = dTimerFecha.Value.AddMinutes(Convert.ToInt32(txtAddMinutos.Text));

                txtHora.Text = dTimerFecha.Value.Hour.ToString();
                txtMinutos.Text = dTimerFecha.Value.Minute.ToString();
                txtSegundos.Text = "00";

                cadena = txtAddMinutos.Text;

                fechaGuardar = false;
            }
        }

        private void txtAddMinutos_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtAddMinutos.Text == string.Empty)
            {
                timer1.Enabled = true;
            }
        }

        private void bttonReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            dTimerFecha.Value = DateTime.Now;
            txtAddMinutos.Text = string.Empty;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
