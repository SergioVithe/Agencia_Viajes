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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsAcceso acceso = new ClsAcceso();
            acceso.pass = txtPassword.Text;
            acceso.usuario = txtUsuario.Text;

            string mensaje = "";
            switch(acceso.segurity()){
                case "1":
                    mensaje = "Bienvenido Administrador";
                    System.Windows.Forms.MessageBox.Show(mensaje);
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    Hide();

                    break;
                case "":
                    mensaje = "Usuario no encontrado ";
                    System.Windows.Forms.MessageBox.Show(mensaje);
                    break;

                default:
                    
                    break;
            }
            

        }
    }
}
