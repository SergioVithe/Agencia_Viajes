using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agencia
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            ClsConexion conexion = new ClsConexion();
            if (txtBaseDatos.Text == string.Empty)
            {
                txtBaseDatos.Focus();

            }
            else
            {

                string cadena = "Server=" + txtServidor.Text + ";Database=" + txtBaseDatos.Text + "; User Id=" + txtUsuario.Text + ";Password=" + txtPassword.Text;
                conexion.cadenadesencriptada = cadena;
                if (conexion.conexion())
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                    lblEstado.Text = "Conexión estable";
                }
                else if (conexion.conexion() == false)
                {
                    lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                    lblEstado.Text = "Conexión no establecida";
                }
            }
        }

        private void txtConectar_Click(object sender, EventArgs e)
        {
            string sFileName = @"C:\Users\sergi\Desktop\sysinit.ini";
            ClsConexion conexion = new ClsConexion();
            conexion.bd = txtBaseDatos.Text;
            conexion.pass = txtPassword.Text;
            conexion.servidor = txtServidor.Text;
            conexion.user = txtUsuario.Text;

            string cadena = "Server=" + conexion.servidor + ";Database=" + conexion.bd + "; User Id=" + conexion.user + ";Password=" + conexion.pass;

            conexion.cadenadesencriptada = cadena;

            if (conexion.conexion())
            {
                File.Delete(sFileName);
                lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
                lblEstado.Text = "Conexión estable";

                conexion.creararchivo();

                frmLogin login = new frmLogin();
                login.Show();
                Hide();


            }
            else if (conexion.conexion() == false)
            {
                lblEstado.ForeColor = System.Drawing.Color.DarkRed;
                lblEstado.Text = "Conexión no establecida";
            }



             
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            string sFileName = @"C:\Users\sergi\Desktop\sysinit.ini";

            
            if (File.Exists(sFileName))
            {
                string[] cadenas = { };
                ClsInicio inicio = new ClsInicio();
                cadenas = inicio.datosBaseDatos().Split('=',';');

                txtServidor.Text = cadenas[1];
                txtBaseDatos.Text = cadenas[3];
                txtUsuario.Text = cadenas[5];
                txtPassword.Text = cadenas[7];
            }
        }
    }
}
