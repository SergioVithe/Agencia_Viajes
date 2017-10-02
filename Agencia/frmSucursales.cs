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
    public partial class frmSucursales : Form
    {
        public frmSucursales()
        {
            InitializeComponent();
        }
        public void cajaslimpias()
        {
            txtDirección.Text = "";
            txtEncargado.Text = "";
            txtSucursal.Text = "";
            txtTelefono.Text = "";
            lblIdentificador.Text = "0";
        }

        ClsCatalogos catalogos = new ClsCatalogos();
        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            dtaSucursales.DataSource = null;
            dtaSucursales.DataSource = catalogos.consultasDataGridView("SELECT * FROM tblsucursales WHERE vchNombre LIKE '"+txtBusqueda.Text+"%'");
        }

        public void databd()
        {
            dtaSucursales.DataSource = catalogos.consultasDataGridView("SELECT * FROM tblsucursales");
            cajaslimpias();
        }

        private void frmSucursales_Load(object sender, EventArgs e)
        {
            databd();   
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            catalogos.ProcedimientosBasicos("INSERT INTO tblsucursales(vchNombre,vchEncargado,vchDireccion,vchTelefono) VALUES('"+txtSucursal.Text+"','"+txtEncargado.Text+"','"+txtDirección.Text+"','"+txtTelefono.Text+"')");
            databd();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            catalogos.ProcedimientosBasicos("update tblsucursales set vchNombre='" + txtSucursal.Text + "',vchEncargado='" + txtEncargado.Text + "',vchDireccion='" + txtDirección.Text + "',vchTelefono='" + txtTelefono.Text + "' where intIdSucursal="+lblIdentificador.Text+"");
            databd();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            catalogos.ProcedimientosBasicos("delete from tblsucursales where intIdSucursal='"+lblIdentificador.Text+"'");
            databd();
        }

        private void dtaSucursales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdentificador.Text = dtaSucursales.CurrentRow.Cells[0].Value.ToString();
            txtSucursal.Text = dtaSucursales.CurrentRow.Cells[1].Value.ToString();
            txtEncargado.Text = dtaSucursales.CurrentRow.Cells[2].Value.ToString();
            txtDirección.Text = dtaSucursales.CurrentRow.Cells[3].Value.ToString();
            txtTelefono.Text = dtaSucursales.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
