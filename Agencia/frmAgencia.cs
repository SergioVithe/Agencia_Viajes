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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
       
            panel9.Height = btnMenuPrincipal.Height;
            panel9.Top = btnMenuPrincipal.Top;
            frmPrincipal1.BringToFront();
        }
        


        public void ventana()
        {
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void oculta_panel()
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPrincipal_Click(object sender, EventArgs e)
        {
           
        }

       

        private void txtCerrarSesion_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtconectar_Click(object sender, EventArgs e)
        {
           // ClsConexion.ObtenerConexion();
            MessageBox.Show("conectado");
        }

        private void txtCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMenuEmpleado_Click(object sender, EventArgs e)
        {
            panel9.Height = btnMenuClientes.Height;
            panel9.Top = btnMenuClientes.Top;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        
        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
           // pic_img.ImageLocation = "C:\\Developer\\Documents\\Visual Studio 2012\\Projects\\Agencia\\Agencia\\Imagen\\us.png";
           // pnlselect1.BackColor = Color.FromArgb(26, 188, 156);
           // pnlSeleccion.BackColor = Color.FromArgb(26, 188, 156);
            //panelsuperior.BackColor=Color.FromArgb(26,188,156);
           // lbl_desc.Text = "Bienvenido";
            panel9.Height = btnMenuPrincipal.Height;
            panel9.Top = btnMenuPrincipal.Top;
            frmPrincipal1.BringToFront();
            PanelSeleccion();
            pnlselect1.Visible = true;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            PanelSeleccion();
        }

        

        private void btnMenuPaquetes_Click(object sender, EventArgs e)
        {
            //pnlselect2.BackColor = Color.FromArgb(230,126,34);
            //pnlSeleccion.BackColor = Color.FromArgb(230, 126, 34);
            //panelsuperior.BackColor = Color.FromArgb(230, 126, 34);
            PanelSeleccion();
            pnlselect2.Visible = true;
        }

        private void btnMenuEmpleados_Click(object sender, EventArgs e)
        {

            //pnlselect3.BackColor = Color.FromArgb(44,62,80);
            //pnlSeleccion.BackColor = Color.FromArgb(44, 62, 80);
            //panelsuperior.BackColor = Color.FromArgb(44, 62, 80);
           // lbl_desc.Text = "Empleados";
            PanelSeleccion();
            pnlselect3.Visible = true;
            panel9.Height = btnMenuPaquetes.Height;
            panel9.Top = btnMenuPaquetes.Top;
            frmEmpleado1.BringToFront();
        }

        private void btnMenuSucursal_Click(object sender, EventArgs e)
        {

            //pnlselect7.BackColor = Color.FromArgb(153, 51, 255);
            //pnlSeleccion.BackColor = Color.FromArgb(153, 51, 255);
            //panelsuperior.BackColor = Color.FromArgb(153, 51, 255);
            //lbl_desc.Text = "Sucursales";
            PanelSeleccion();
            pnlselect7.Visible = true;
            panel9.Height = btnMenuSucursal.Height;
            panel9.Top = btnMenuSucursal.Top;
            frmSucursal1.BringToFront();
            
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            //pnlselect8.BackColor = Color.FromArgb(149,165,166);
            //pnlSeleccion.BackColor = Color.FromArgb(149, 165, 166);
            //panelsuperior.BackColor = Color.FromArgb(149, 165, 166);
            //lbl_desc.Text = "Eventos";
            PanelSeleccion();
            pnlselect8.Visible = true;
            panel9.Height = btnEventos.Height;
            panel9.Top = btnEventos.Top;
            frmEventos1.BringToFront();
        }

        private void btnMenuLugares_Click(object sender, EventArgs e)
        {
            //pnlselect6.BackColor = Color.FromArgb(0, 125, 0);
            //pnlSeleccion.BackColor = Color.FromArgb(0, 125, 0);
            //panelsuperior.BackColor = Color.FromArgb(0, 125, 0);
            //lbl_desc.Text = "Lugares";
            PanelSeleccion();
            pnlselect6.Visible = true;
            panel9.Height = btnMenuLugares.Height;
            panel9.Top = btnMenuLugares.Top;
            frmLugares1.BringToFront();
        }

        private void btnMenuClientes_Click(object sender, EventArgs e)
        {
            //pnlselect4.BackColor = Color.FromArgb(231,76,60);
            //pnlSeleccion.BackColor = Color.FromArgb(231, 76, 60);
            //panelsuperior.BackColor = Color.FromArgb(231, 76, 60);
            //lbl_desc.Text = "Clientes";
            PanelSeleccion();
            pnlselect4.Visible = true;
            panel9.Height = btnMenuClientes.Height;
            panel9.Top = btnMenuClientes.Top;
            frmClientes1.BringToFront();
        }
        public void PanelSeleccion()
        {
            pnlselect1.Visible = false;
            pnlselect2.Visible = false;
            pnlselect3.Visible = false;
            pnlselect4.Visible = false;
            pnlselect5.Visible = false;
            pnlselect6.Visible = false;
            pnlselect7.Visible = false;
            pnlselect8.Visible = false;
        }

        

        private void btnMenuHoteles_Click(object sender, EventArgs e)
        {
            //pnlselect5.BackColor = Color.FromArgb(241,196,15);
            //pnlSeleccion.BackColor = Color.FromArgb(241, 196, 15);
            //panelsuperior.BackColor = Color.FromArgb(241, 196, 15);
            //lbl_desc.Text = "Hoteles";
            panel9.Height = btnMenuHoteles.Height;
            panel9.Top = btnMenuHoteles.Top;
            frmHotel1.BringToFront();
            PanelSeleccion();
            pnlselect5.Visible = true;
        }

        private void frmCatalogos1_Load(object sender, EventArgs e)
        {
           // PanelSeleccion(3);
           // pnlselect3.Visible=tr
            panel9.Height = btnMenuPaquetes.Height;
            panel9.Top = btnMenuPaquetes.Top;
            frmEmpleado1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}

