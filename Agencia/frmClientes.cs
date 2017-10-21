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
    public partial class frmClientes : UserControl
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        public void MostrarDatos_dgvClientes()
        {
            dgvClientes.DataSource = ClsClientes.MostrarDatos();
            this.dgvClientes.Columns["IdCliente"].Visible = false;
            this.dgvClientes.Columns["IdSucursal"].Visible = false;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            MostrarDatos_dgvClientes();
            cmbSucursal.DataSource = ClsClientes.ObtenerSucursal();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
            txtIdCliente.Visible = false;

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvClientes.Rows[e.RowIndex];
            txtIdCliente.Text = row.Cells["IdCliente"].Value.ToString();

            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = row.Cells["Correo"].Value.ToString();
            //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
            //textBox1.Text = row.Cells["IdSucursal"].Value.ToString();

            //cuando se selecciona la fila el boton guardar se desactiva  
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            HabilitaCajas();
        }

        public void limpia_cajas()
        {
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            ClsClientes Instancia = new ClsClientes();
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Correo = txtCorreo.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();

            Instancia.IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);

            int respuesta = ClsClientes.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Cliente Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar datos del Cliente", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvClientes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            ClsClientes Instancia = new ClsClientes();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.Correo = txtCorreo.Text.Trim();
            Instancia.IdCliente = Convert.ToInt32(txtIdCliente.Text.Trim());
            Instancia.IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);

            if (ClsClientes.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Cliente se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGuardar.Enabled = true;
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsClientes Instancia = new ClsClientes();
                Instancia.IdCliente = Convert.ToInt32(txtIdCliente.Text);

                if (ClsClientes.Eliminar(Instancia.IdCliente) > 0)
                {
                    MessageBox.Show("Cliente Eliminado Correctamente!", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvClientes();
                    btnGuardar.Enabled = true;
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar datos del Cliente", "Cliente No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
        public void OpcionActualizar()
        {
            btnGuardar.Enabled = false;
        }
        public void OpcionCancelar()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbSucursal.Enabled = false;
            txtCorreo.Enabled = false;

            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            cmbSucursal.SelectedItem = "";

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }
        public void opcionNuevo()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            cmbSucursal.SelectedItem = 0;
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtCorreo.Enabled = true;
            cmbSucursal.Enabled = true;
            btnGuardar.Enabled = true;

        }
        public void HabilitaCajas()
        {
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            cmbSucursal.Enabled = true;
            txtCorreo.Enabled = true;
        }

        public void DesabilitarCajas()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbSucursal.Enabled = false;
            txtCorreo.Enabled = false;
        }

    }
}
