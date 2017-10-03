using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia
{
    class ClsConexion
    {
        public MySqlConnection conectar;
        public string servidor;
        public string bd;
        public string user;
        public string pass;
        public string cadenadesencriptada;

        public string recservidor
        {
            get { return servidor; }
            set { servidor = value; }
        }

        public string recbd
        {
            get { return bd; }
            set { bd = value; }
        }

        public string recuser
        {
            get { return user; }
            set { user = value; }
        }

        public string recpass
        {
            get { return pass; }
            set { pass = value; }
        }

        public string reccadenadesencriptada
        {
            get { return cadenadesencriptada; }
            set { cadenadesencriptada = value; }
        }


        public Boolean conexion()
        {
            try
            {
                conectar = new MySqlConnection(cadenadesencriptada);
                //System.Windows.Forms.MessageBox.Show("Conexion Establecida !!!");
                conectar.Open();

                return true;
            }
            catch (Exception)
            {
                return false;
                //System.Windows.Forms.MessageBox.Show("No se pudo conectar!!!");
            }
        }



        public void creararchivo()
        {
            ClsDatos datos = new ClsDatos();
            string cadena;
            string filename = @"C:\Users\sergi\Desktop\sysinit.ini";
            FileStream Stream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(Stream);
            cadena = "Server=" + servidor + ";Database=" + bd + "; User Id=" + user + ";Password=" + pass;
            string cadenaencriptada = datos.Encriptar(cadena);
            writer.WriteLine(cadenaencriptada);
            writer.Close();


        }


        




    }
}
