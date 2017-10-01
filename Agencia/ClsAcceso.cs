using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agencia
{
    class ClsAcceso
    {
        public string usuario = "";
        public string pass = "";



        public string segurity()
        {

            ClsInicio inicio = new ClsInicio();
            ClsConexion conexion = new ClsConexion();
            string cadena = "Server=" + inicio.datosBaseDatos()[1] + ";Database=" + inicio.datosBaseDatos()[3] + "; User Id=" + inicio.datosBaseDatos()[5] + ";Password=" + inicio.datosBaseDatos()[7];
            string output = "";
            string query = "select tblUsuario.intIdNivel from tblUsuario where vchUsuario='" + usuario + "' and vchPassword='" + pass + "'";
            try
            {
                conexion.cadenadesencriptada = cadena;
                if (conexion.conexion())
                {

                    MySqlCommand cmd = new MySqlCommand(query, conexion.conectar);
                    cmd.ExecuteNonQuery();
                    output = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception)
            {
                output = "";

            }

            conexion.conectar.Close();
            return output;

        }


    }
}
