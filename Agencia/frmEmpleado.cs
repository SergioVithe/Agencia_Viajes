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
    public partial class frmEmpleado : UserControl
    {
        public frmEmpleado()
        {
            InitializeComponent();
          
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            
        }

        public void limpia_cajas()
        {
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtIdEmpleado.Text = "";
            txtTelefono.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEmpleado Instancia = new ClsEmpleado();
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
     
            Instancia.IdSucursal = Convert.ToInt32 (cmbSucursal.SelectedValue.ToString());//inserta el sucursal ojo revisar esto

            int respuesta = ClsEmpleado.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Empleado Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el empleado", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvEmpleados();

        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            DesabilitarCajas();
            MostrarDatos_dgvEmpleados();
            txtIdEmpleado.Visible = false;
            cmbSucursal.DataSource = ClsEmpleado.ObtenerSucursal();
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
        }

        public void MostrarDatos_dgvEmpleados()
        {
            dgvEmpleados.DataSource = ClsEmpleado.MostrarDatos();
            //this.dgvEmpleados.Columns["intIdEmpleado"].Visible = false;
            //this.dgvEmpleados.Columns[""].Visible = false;          
        }

        

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dgvEmpleados.Rows[e.RowIndex];
                txtIdEmpleado.Text = row.Cells["IdEmpleado"].Value.ToString();

                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
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
                
               // throw;
            }
           
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsEmpleado Instancia = new ClsEmpleado();
                Instancia.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

                if ( ClsEmpleado.Eliminar(Instancia.IdEmpleado) > 0)
                {
                    MessageBox.Show("Empleado Eliminado Correctamente!", "Empleado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvEmpleados();
                    btnGuardar.Enabled = true;
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Empleado", "Empleado No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbSucursal_DrawItem(object sender, DrawItemEventArgs e)
        {
          
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            opcionNuevo();
        }


        public void OpcionCancelar()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbSucursal.Enabled = false;

            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cmbSucursal.SelectedItem ="";

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }
        public void OpcionActualizar()
        {
            btnGuardar.Enabled = false;
        }
        public void opcionNuevo()
        {
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            cmbSucursal.SelectedItem = 0;
            txtApellidos.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
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
        }

        public void DesabilitarCajas()
        {
            txtApellidos.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            cmbSucursal.Enabled = false;
        }

        public void OpcionEliminar()
        {
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            ClsEmpleado Instancia = new ClsEmpleado();
            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();

            Instancia.IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);

            int respuesta = ClsEmpleado.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Empleado Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Empleado", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            MostrarDatos_dgvEmpleados();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ClsEmpleado Instancia = new ClsEmpleado();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Apellidos = txtApellidos.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.IdSucursal = Convert.ToInt32(cmbSucursal.SelectedValue);
            Instancia.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

            if (ClsEmpleado.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Empleado se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpcionActualizar();
                DesabilitarCajas();
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvEmpleados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsEmpleado Instancia = new ClsEmpleado();
                Instancia.IdEmpleado = Convert.ToInt32(txtIdEmpleado.Text);

                if (ClsEmpleado.Eliminar(Instancia.IdEmpleado) > 0)
                {
                    MessageBox.Show("Empleado Eliminado Correctamente!", "Empleado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvEmpleados();
                    OpcionEliminar();
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Empleado", "Empleado No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
         //txtApellidos.Focus();
         
    }
}
