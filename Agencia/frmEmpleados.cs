using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }
        ClsEmpleados empleado = new ClsEmpleados();
        public void tablaReload()
        {
            dtaEmpleados.DataSource = empleado.consultasDataGridView("select * from tblEmpleados");
        }

        public void datosLimpios()
        {
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtApellidos.Text = "";
            lblIdentificador.Text = "0";
        }
        private void frmEmpleados_Load(object sender, EventArgs e)
        {

            tablaReload();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           empleado.ProcedimientosBasicos("INSERT INTO tblempleados(vchNombre,vchApellido,vchDireccion,vchTelefono) VALUES('"+txtNombre.Text+"','"+txtApellidos.Text+"','"+txtDireccion.Text+"','"+txtTelefono.Text+"');");
           datosLimpios();
           tablaReload();
            
        }

        private void txtBorrar_Click(object sender, EventArgs e)
        {
            empleado.ProcedimientosBasicos("delete from tblempleados where intIdEmpleado='"+lblIdentificador.Text+"'");
            datosLimpios();
            tablaReload();

        }

        private void dtaEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            //lblIdentificador.Text = dtaEmpleados.Rows[0].Cells[0].Value.ToString();// dtaEmpleados.Rows[0].Cells[1].Value.ToString();
        }

        private void dtaEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdentificador.Text = dtaEmpleados.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dtaEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dtaEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtDireccion.Text = dtaEmpleados.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dtaEmpleados.CurrentRow.Cells[4].Value.ToString();
        }

        private void frmEmpleados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Escape))
            {
                datosLimpios();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datosLimpios();

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            dtaEmpleados.DataSource = null;
            dtaEmpleados.DataSource = empleado.consultasDataGridView("select * from tblEmpleados where vchNombre like '" + txtBuscar.Text + "%'");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            empleado.ProcedimientosBasicos("update tblempleados set vchNombre='"+txtNombre.Text+"',vchApellido='"+txtApellidos.Text+"',vchDireccion='"+txtDireccion.Text+"',vchTelefono='"+txtTelefono.Text+"' where intIdEmpleado="+lblIdentificador.Text+"");
            datosLimpios();
            tablaReload();
        }
    }
}
