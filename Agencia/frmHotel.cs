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
    public partial class frmHotel : UserControl
    {
        public frmHotel()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
   
           
        }

        public void limpia_cajas()
        {
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtIdHotel.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            cmbCategoria.Text = "...";
        }

        private void frmHotel_Load(object sender, EventArgs e)
        {
            txtIdHotel.Visible = false;
            MostrarDatos_dgvHotel();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            
        }

        public void MostrarDatos_dgvHotel()
        {
            dgvHotel.DataSource = ClsHotel.MostrarDatos();
            this.dgvHotel.Columns["IdHotel"].Visible = false;
            //this.dgvEmpleados.Columns[""].Visible = false;          
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }
           

        private void dgvHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dgvHotel.Rows[e.RowIndex];
            txtIdHotel.Text = row.Cells["IdHotel"].Value.ToString();

            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            cmbCategoria.Text = row.Cells["Categoria"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            txtCorreo.Text = row.Cells["Correo"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
         
            //    txtSucursal.Text = row.Cells["Sucursal"].Value.ToString();
            //textBox1.Text = row.Cells["IdSucursal"].Value.ToString();

            //cuando se selecciona la fila el boton guardar se desactiva  
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            HabilitaCajas();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            ClsHotel Instancia = new ClsHotel();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Categoria = cmbCategoria.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.Correo = txtCorreo.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();

            Instancia.LogoNombre = "logo";

            int respuesta = ClsHotel.Guardar(Instancia);
            if (respuesta > 0)
            {
                MessageBox.Show("Hotel Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatos_dgvHotel();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el Hotel", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            limpia_cajas();
            //   MostrarDatos_dgvEmpleados();
        }

        private void btnActualizar1_Click(object sender, EventArgs e)
        {
            ClsHotel Instancia = new ClsHotel();

            Instancia.Nombre = txtNombre.Text.Trim();
            Instancia.Categoria = cmbCategoria.Text.Trim();
            Instancia.Telefono = txtTelefono.Text.Trim();
            Instancia.Correo = txtCorreo.Text.Trim();
            Instancia.Direccion = txtDireccion.Text.Trim();

            Instancia.IdHotel = Convert.ToInt32(txtIdHotel.Text.Trim());

            //falta la ruta 
            //vchlogonombre
            //vchlogoRuta


            if (ClsHotel.Actualizar(Instancia) > 0)
            {
                MessageBox.Show("Los datos del Empleado se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //OpcionActualizar();
                //DesabilitarCajas();
                limpia_cajas();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MostrarDatos_dgvHotel();
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Esta Seguro que desea eliminar el Empleado Actual", "Esta Seguro??", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClsHotel Instancia = new ClsHotel();
                Instancia.IdHotel = Convert.ToInt32(txtIdHotel.Text);

                if (ClsHotel.Eliminar(Instancia.IdHotel) > 0)
                {
                    MessageBox.Show("Hotel Eliminado Correctamente!", "Hotel Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatos_dgvHotel();
                    //OpcionEliminar();
                    limpia_cajas();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el Empleado", "Hotel No Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se cancelo la eliminacion", "Eliminacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtLogoRuta.Text = "";
            cmbCategoria.SelectedItem = 0;


            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtLogoRuta.Enabled = true;
            cmbCategoria.SelectedItem = 0;
           
            

            btnGuardar.Enabled = true;

        }
        public void HabilitaCajas()
        {
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtLogoRuta.Enabled = true;
            cmbCategoria.SelectedItem = 0;
        }

        private void dgvHotel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            OpcionCancelar();
        }
        public void OpcionCancelar()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtLogoRuta.Text = "";
            cmbCategoria.SelectedItem = 0;


            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            txtLogoRuta.Enabled = false;
            cmbCategoria.SelectedItem = 0;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }
        
    
   
    }
}
