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
    public partial class frmLugares : UserControl
    {
        public frmLugares()
        {
            InitializeComponent();
        }

        public void MostrarDatos_dgvLugares()
        {
            dgvLugares.DataSource = ClsLugares.MostrarDatos();
            this.dgvLugares.Columns["IdLugar"].Visible = true;
        }

        private void frmLugares_Load(object sender, EventArgs e)
        {
            txtIdLugar.Visible = false;
            MostrarDatos_dgvLugares();
        }

        private void dgvLugares_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvLugares.Rows[e.RowIndex];
                txtIdLugar.Text = row.Cells["IdLugar"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();

                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
            }
            catch (Exception)
            {
                
              //  throw;
            }

           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsLugares Instancia = new ClsLugares();
            //Instancia.IdLugar = Convert.ToInt32(txtIdLugar.Text.Trim());
            Instancia.Nombre = txtNombre.Text.Trim();

            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Descripcion = txtDescripcion.Text.Trim();

            int respuesta = ClsLugares.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Empleado Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el empleado", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvLugares();
        }

        public void limpia_cajas()
        {
            txtIdLugar.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClsLugares Instancia = new ClsLugares();
            Instancia.IdLugar = Convert.ToInt32(txtIdLugar.Text.Trim());
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Descripcion = txtDescripcion.Text.Trim();


            if (ClsLugares.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Lugar se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvLugares();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Lugar Actual", "Eliminar Lugar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsLugares Instancia = new ClsLugares();
                Instancia.IdLugar = Convert.ToInt32(txtIdLugar.Text);

                if (ClsLugares.Eliminar(Instancia.IdLugar) > 0)
                {
                    MessageBox.Show("Lugar Eliminado Correctamente!", "Lugar Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvLugares();
                    btnGuardar.Enabled = true;
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Lugar", "Lugar No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
