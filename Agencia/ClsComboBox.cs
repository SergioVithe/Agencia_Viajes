using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agencia
{
    class ClsComboBox
    {
        public DataTable llenarcombo()
        {
            DataTable ds = new DataTable();
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            string cadena = "select * from tblSucursal";
            MySqlCommand cmd = new MySqlCommand(cadena, conexion);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable llenar()
        {
            DataTable tbl = new DataTable();
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            string texto = "select * from tblSucursal";
            MySqlCommand cmd = new MySqlCommand(texto, conexion);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(tbl);
            return tbl;

        }


        public void FillDrownList(string query, ComboBox DropDownName)
        {
            DataTable table = new DataTable();

            MySqlConnection con = ClsConexion.ObtenerConexion();
            using (var cmd=new SqlCommand())
            {
                try
                {
                    table.Load(cmd.ExecuteReader());
                }
                catch (Exception)
                {
                    
                    throw;
                }
                DropDownName.DataSource = table;
                DropDownName.ValueMember = table.Columns[0].ColumnName;
                DropDownName.DisplayMember = table.Columns[1].ColumnName;
                con.Close();
            }
        }

        internal void FillDrownList(string p, DataGridView dgvEmpleados)
        {
            throw new NotImplementedException();
        }
    }
}
