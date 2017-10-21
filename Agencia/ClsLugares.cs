using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace Agencia
{
    class ClsLugares
    {
        public int IdLugar { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }

        public ClsLugares() { }

        //estos son los variables que se mandan a llamar
        public ClsLugares(int pIdLugar, string pNombre, string pDireccion, string pDescripcion)
        {
            this.IdLugar = pIdLugar;
            this.Nombre = pNombre;
            this.Direccion = pDireccion;
            this.Descripcion = pDescripcion;
        }

        public static int Guardar(ClsLugares variables)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblLugares (intIdLugar, vchNombre, vchDireccion, vchDescripcion) VALUES ('{0}','{1}','{2}', '{3}')",
            variables.IdLugar, variables.Nombre, variables.Direccion, variables.Descripcion), ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        public static int Actualizar(ClsLugares variables)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblLugares set vchNombre='{0}', vchDireccion='{1}', vchDescripcion='{2}' where intIdLugar={3}",
            variables.Nombre, variables.Direccion, variables.Descripcion, variables.IdLugar), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdLugar)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblLugares where intIdLugar={0}", IdLugar), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena tabla
        public static List<ClsLugares> MostrarDatos()
        {
            List<ClsLugares> lista = new List<ClsLugares>();

            MySqlCommand comando = new MySqlCommand(String.Format("select * from tbllugares"), ClsConexion.ObtenerConexion());
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ClsLugares Lugar = new ClsLugares();
                Lugar.IdLugar = reader.GetInt32(0);
                Lugar.Nombre = reader.GetString(1);
                Lugar.Direccion = reader.GetString(2);
                Lugar.Descripcion = reader.GetString(3);
                lista.Add(Lugar);
            }
            return lista;
        }

    }
}
