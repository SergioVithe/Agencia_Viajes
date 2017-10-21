using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agencia
{
    class ClsClientes
    {

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }

        public ClsClientes() { }

        //estos son los variables que se mandan a llamar
        public ClsClientes(int pIdCliente, string pNombre, string pApellidos, string pDireccion, string pTelefono, string pCorreo, int pIdSucursal)
        {
            this.IdCliente = pIdCliente;
            this.Nombre = pNombre;
            this.Apellidos = pApellidos;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.Correo = pCorreo;
            this.IdSucursal = pIdSucursal;
        }

        public static int Guardar(ClsClientes variable)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblclientes (intidcliente, vchnombre, vchapellidos, vchdireccion, vchtelefono, vchemail, intidsucursal) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}','{6}')",
            variable.IdCliente, variable.Nombre, variable.Apellidos, variable.Direccion, variable.Telefono, variable.Correo, variable.IdSucursal), ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        public static int Actualizar(ClsClientes variables)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblClientes set vchNombre='{0}', vchApellidos='{1}', vchDireccion='{2}', vchTelefono='{3}', vchemail='{4}', intIdSucursal='{5}' where intIdCliente={6}",
            variables.Nombre, variables.Apellidos, variables.Direccion, variables.Telefono, variables.Correo, variables.IdSucursal, variables.IdCliente), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdCliente)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblClientes where intIdCliente={0}", IdCliente), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }
        //llena tabla
        public static List<ClsClientes> MostrarDatos()
        {
            List<ClsClientes> lista = new List<ClsClientes>();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT tblclientes.intIdCliente,tblclientes.vchnombre,tblclientes.vchApellidos, tblclientes.vchDireccion,tblclientes.vchTelefono,tblclientes.vchemail, tblsucursales.vchNombre FROM tblclientes, tblsucursales WHERE tblclientes.intIdSucursal=tblsucursales.intIdSucursal; "), ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsClientes Cliente = new ClsClientes();
                Cliente.IdCliente = _reader.GetInt32(0);
                Cliente.Nombre = _reader.GetString(1);
                Cliente.Apellidos = _reader.GetString(2);
                Cliente.Direccion = _reader.GetString(3);
                Cliente.Telefono = _reader.GetString(4);
                Cliente.Correo = _reader.GetString(5);
                Cliente.Sucursal = _reader.GetString(6);

                lista.Add(Cliente);
            }
            return lista;
        }

        //llena combo
        public static List<ClsSucursal> ObtenerSucursal()
        {
            List<ClsSucursal> lista = new List<ClsSucursal>();

            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand("select intIdSucursal , vchNombre from tblsucursales", conexion);
            MySqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ClsSucursal Sucursal = new ClsSucursal();
                Sucursal.IdSucursal = reader.GetInt32(0);
                Sucursal.Nombre = reader.GetString(1);
                lista.Add(Sucursal);
            }
            return lista;
        }
    }
}
