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
             panel9.Height = btnMenuPrincipal.Height;
             panel9.Top = btnMenuPrincipal.Top;
             frmPrincipal1.BringToFront();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        

        private void btnMenuPaquetes_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenuEmpleados_Click(object sender, EventArgs e)
        {
            panel9.Height = btnMenuPaquetes.Height;
            panel9.Top = btnMenuPaquetes.Top;
            frmEmpleado1.BringToFront();
        }

        private void btnMenuSucursal_Click(object sender, EventArgs e)
        {
            panel9.Height = btnMenuSucursal.Height;
            panel9.Top = btnMenuSucursal.Top;
            frmSucursal1.BringToFront();
            
        }

        private void btnEventos_Click(object sender, EventArgs e)
        {
            panel9.Height = btnEventos.Height;
            panel9.Top = btnEventos.Top;
            frmEventos1.BringToFront();
        }

        private void btnMenuLugares_Click(object sender, EventArgs e)
        {
            panel9.Height = btnMenuLugares.Height;
            panel9.Top = btnMenuLugares.Top;
            frmLugares1.BringToFront();
        }

        private void btnMenuClientes_Click(object sender, EventArgs e)
        {
            panel9.Height = btnMenuClientes.Height;
            panel9.Top = btnMenuClientes.Top;
            frmClientes1.BringToFront();
        }
       
    }
}
