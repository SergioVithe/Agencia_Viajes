using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agencia
{
    class ClsEmpleado
    {

        public void ProcedimientosBasicos( string query)
        {
            string[] cadenas = { };
            ClsInicio inicio = new ClsInicio();
            cadenas = inicio.datosBaseDatos().Split('=', ';');
            MySqlConnection con = new MySqlConnection("Server=" + cadenas[1] + ";Database=" + cadenas[3] + "; User Id=" + cadenas[5] + ";Password=" + cadenas[7]);
            
            using (con)
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                
            }
           
                
        }

        public DataTable consultasDataGridView(string query)
        {
            DataTable dtdatos = new DataTable();
            string[] cadenas = { };
            ClsInicio inicio = new ClsInicio();
            cadenas = inicio.datosBaseDatos().Split('=', ';');
            MySqlConnection con = new MySqlConnection("Server=" + cadenas[1] + ";Database=" + cadenas[3] + "; User Id=" + cadenas[5] + ";Password=" + cadenas[7]);

            using (con)
            {
                con.Open();
                
                MySqlDataAdapter mdaDatos = new MySqlDataAdapter(query, con);
                mdaDatos.Fill(dtdatos);
                
                

            }
            return dtdatos;
        
        }


    }
}
