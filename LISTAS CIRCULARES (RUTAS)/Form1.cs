using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISTAS_CIRCULARES__RUTAS_
{
    public partial class Form1 : Form
    {
        Ruta ruta = new Ruta();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Minutos = Convert.ToInt32(txtMinutos.Text);

            ruta.Agregar(nuevo);

            txtMinutos.Clear();
            txtNombre.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Base buscado = ruta.Buscar(txtNombre.Text);
            if (buscado == null)
            {
                MessageBox.Show("No existe");
            }
            else
                txtReporte.Text = buscado.ToString();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Clear();
            txtReporte.Text += ruta.Reporte();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ruta.Eliminar(txtNombre.Text);
            txtNombre.Clear();
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Minutos = Convert.ToInt32(txtMinutos.Text);

            ruta.AgregarInicio(nuevo);

            txtMinutos.Clear();
            txtNombre.Clear();
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            ruta.EliminarUltimo();
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            ruta.EliminarPrimero();
        }

        private void btnInsertarDespues_Click(object sender, EventArgs e)
        {
            Base nuevo = new Base();
            nuevo.Nombre = txtNombre.Text;
            nuevo.Minutos = Convert.ToInt32(txtMinutos.Text);

            ruta.InsertarDespuesDe(txtBase2.Text, nuevo);

            txtMinutos.Clear();
            txtNombre.Clear();
            txtBase2.Clear();
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            txtReporte.Text = ruta.Recorrido(txtBase.Text, dtpInicio.Value, dtpFin.Value);
        }
    }
}
