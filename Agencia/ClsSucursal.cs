using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agencia
{
    class ClsSucursal
    {

        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Encargado { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdAgencia { get; set; }
        public string Agencia { get; set; }

        public ClsSucursal() { }

        //estos son los variables que se mandan a llamar
        public ClsSucursal(int pIdSucursal, string pNombre, string pEncargado, string pDireccion, string pTelefono, int pIdAgencia)
        {
            this.IdSucursal = pIdSucursal;
            this.Nombre = pNombre;
            this.Encargado = pEncargado;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.IdAgencia = pIdAgencia;
        }

        public static int Guardar(ClsSucursal variable)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblsucursales (intidsucursal, vchnombre, vchencargado, vchdireccion, vchtelefono, intidagencia) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}')",
            variable.IdSucursal, variable.Nombre, variable.Encargado, variable.Direccion, variable.Telefono, variable.IdAgencia), ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        public static int Actualizar(ClsSucursal variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblsucursales set vchNombre='{0}', vchencargado='{1}', vchDireccion='{2}', vchTelefono='{3}', intIdagencia='{4}' where intIdsucursal={5}",
            variable.Nombre, variable.Encargado, variable.Direccion, variable.Telefono, variable.IdAgencia, variable.IdSucursal), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdSucursal)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblsucursales where intIdSucursal={0}", IdSucursal), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena tabla
        public static List<ClsSucursal> MostrarDatos()
        {
            List<ClsSucursal> lista = new List<ClsSucursal>();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT tblsucursales.intIdSucursal, tblsucursales.vchNombre,tblsucursales.vchEncargado, tblsucursales.vchDireccion,tblsucursales.vchTelefono, tblagencia_viajes.vchNombre FROM tblsucursales, tblagencia_viajes WHERE tblsucursales.intIdAgencia = tblagencia_viajes.intIdAgencia; "), ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsSucursal Sucursal = new ClsSucursal();
                Sucursal.IdSucursal = _reader.GetInt32(0);
                Sucursal.Nombre = _reader.GetString(1);
                Sucursal.Encargado = _reader.GetString(2);
                Sucursal.Direccion = _reader.GetString(3);
                Sucursal.Telefono = _reader.GetString(4);
                Sucursal.Agencia = _reader.GetString(5);

                lista.Add(Sucursal);
            }
            return lista;
        }

        //llena combo
        public static List<ClsEmpleado> ObtenerSucursal()
        {
            List<ClsEmpleado> lista = new List<ClsEmpleado>();

            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand("select vchNombre, vchApellidos from tblEmpleados", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ClsEmpleado Empleado = new ClsEmpleado();
                Empleado.Nombre = reader.GetString(0) + " " + reader.GetString(1);

                lista.Add(Empleado);
            }
            return lista;
        }







    }
}
