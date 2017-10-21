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
    public partial class frmSucursal : UserControl
    {
        public frmSucursal()
        {
            InitializeComponent();
        }

        public void MostrarDatos_dgvSucursal()
        {
            dgvSucursal.DataSource = ClsSucursal.MostrarDatos();
            this.dgvSucursal.Columns["IdSucursal"].Visible = false;
            this.dgvSucursal.Columns["IdAgencia"].Visible = false;
        }

        public void limpia_cajas()
        {
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";

        }



        private void frmSucursal_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvSucursal();

            cmbEncargado.DataSource = ClsSucursal.ObtenerSucursal();
            cmbEncargado.DisplayMember = "Nombre";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
        }
        public void HabilitaCajas()
        {
            
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            cmbEncargado.Enabled = true;
        }

        private void dgvSucursal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvSucursal.Rows[e.RowIndex];
                txtIdSucursal.Text = row.Cells["IdSucursal"].Value.ToString();

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                cmbEncargado.Text = row.Cells["Encargado"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
                //textBox1.Text = row.Cells["IdSucursal"].Value.ToString();

                //cuando se selecciona la fila el boton guardar se desactiva  
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                btnActualizar.Enabled = true;
                btnEliminar.Enabled = true;
                HabilitaCajas();
            }
            catch (Exception)
            {

                //throw;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsSucursal Instancia = new ClsSucursal();
            //   Instancia.IdSucursal = Convert.ToInt32(txtIdSucursal.Text.Trim());
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Encargado = cmbEncargado.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.IdAgencia = 1;  //¿? En agencia solo va a ver un registro nombre de la agencia
            //Convert.ToInt32(cmbAgencia.SelectedValue);

            int respuesta = ClsSucursal.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Sucursal Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Sucursal", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvSucursal();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsSucursal Instancia = new ClsSucursal();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Encargado = cmbEncargado.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.IdAgencia = 1;

            Instancia.IdSucursal = Convert.ToInt32(txtIdSucursal.Text.Trim());

            if (ClsSucursal.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Sucursal se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvSucursal();
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro que desea eliminar el Sucursal Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsSucursal Instancia = new ClsSucursal();
                Instancia.IdSucursal = Convert.ToInt32(txtIdSucursal.Text);

                if (ClsSucursal.Eliminar(Instancia.IdSucursal) > 0)
                {
                    MessageBox.Show("Sucursal Eliminado Correctamente!", "Sucursal Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvSucursal();
                    btnGuardar.Enabled = true;
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Sucursal", "sucursal No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvSucursal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try {
                 DataGridViewRow row = (DataGridViewRow)dgvSucursal.Rows[e.RowIndex];
                 txtNombre.Text = row.Cells["IdEmpleado"].Value.ToString();

                 cmbEncargado.Text = row.Cells["Nombre"].Value.ToString();
                 txtDireccion.Text = row.Cells["Apellidos"].Value.ToString();
                 txtTelefono.Text = row.Cells["Direccion"].Value.ToString();
                // txtAgencia.Text = row.Cells["Telefono"].Value.ToString(); 
                 //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
                 //textBox1.Text = row.Cells["IdSucursal"].Value.ToString();

                 //cuando se selecciona la fila el boton guardar se desactiva  
                 btnGuardar.Enabled = false;
                 btnNuevo.Enabled = false;
                 btnActualizar.Enabled = true;
                 btnEliminar.Enabled = true;
                // HabilitaCajas();
             }
             catch (Exception)
             {

                 // throw;
             }
         }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }
        public void opcionNuevo()
        {
           
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cmbEncargado.SelectedItem = 0;
          
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            cmbEncargado.Enabled = true;
            btnGuardar.Enabled = true;

        }
        public void OpcionCancelar()
        {
           
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbEncargado.Enabled = false;

           
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cmbEncargado.SelectedItem = 0;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
    }
}