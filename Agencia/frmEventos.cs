using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class frmEventos : UserControl
    {
        public frmEventos()
        {
            InitializeComponent();
        }
        public void limpia_cajas()
        {
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            txtIdEvento.Text = "";
            txtNombre.Text = "";
        }

        //muestra informacion en la tabla
        public void MostrarDatos_dgvEventos()
        {
            dgvEventos.DataSource = ClsEventos.MostrarDatos();
            // this.dgvEventos.Columns["IdEmpleado"].Visible = true;
            //this.dgvEmpleados.Columns["IdSucursal"].Visible = true;
        }

        private void frmEventos_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvEventos();
            txtIdEvento.Visible = false;
        }

        private void dgvEventos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvEventos.Rows[e.RowIndex];
            txtIdEvento.Text = row.Cells["IdEvento"].Value.ToString();

            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();

            //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
            dtFecha.Text = row.Cells["Fecha"].Value.ToString();

            //cuando se selecciona la fila el boton guardar se desactiva  
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            ClsEventos Instancia = new ClsEventos();
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Descripcion = txtDescripcion.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Fecha = dtFecha.Text.Trim();

            int respuesta = ClsEventos.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Evento Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Evento", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvEventos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsEventos Instancia = new ClsEventos();
            Instancia.IdEvento = Convert.ToInt32(txtIdEvento.Text.Trim());
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Descripcion = txtDescripcion.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Fecha = dtFecha.Text.Trim();

            if (ClsEventos.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Evento se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvEventos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsEventos Instancia = new ClsEventos();
                Instancia.IdEvento = Convert.ToInt32(txtIdEvento.Text);

                if (ClsEventos.Eliminar(Instancia.IdEvento) > 0)
                {
                    MessageBox.Show("Evento Eliminado Correctamente!", "Evento Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvEventos();
                    btnGuardar.Enabled = true;
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Evento", "Evento No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
