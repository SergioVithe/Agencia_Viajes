using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Agencia
{
    class ClsEmpleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdSucursal { get; set; }

       

        public ClsEmpleado() {
        }

        

        //estos son los variables que se mandan a llamar
        public ClsEmpleado(int pIdEmpleado, string pNombre, string pApellidos, string pDireccion, string pTelefono, int pSucursal)
        {
            this.IdEmpleado = pIdEmpleado;
            this.Nombre = pNombre;
            this.Apellidos = pApellidos;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
            this.IdSucursal = pSucursal;
        }

        public static int Guardar(ClsEmpleado variables)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblempleados (intidempleado, vchnombre, vchapellidos, vchdireccion, vchtelefono, intidsucursal) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}')",
            variables.IdEmpleado, variables.Nombre, variables.Apellidos, variables.Direccion, variables.Telefono, variables.IdSucursal),ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        //llena tabla
        public static List<ClsEmpleado> MostrarDatos()
        {
            List<ClsEmpleado> lista = new List<ClsEmpleado>();

            MySqlCommand _comando = new MySqlCommand(String.Format("select * from tblempleados"), ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsEmpleado Empleado = new ClsEmpleado();
                Empleado.IdEmpleado = _reader.GetInt32(0);
                Empleado.Nombre = _reader.GetString(1);
                Empleado.Apellidos = _reader.GetString(2);
                Empleado.Direccion = _reader.GetString(3);
                Empleado.Telefono = _reader.GetString(4);
                Empleado.IdSucursal = _reader.GetInt32(5);

                lista.Add(Empleado);
            }
            return lista;
        }

        //buscar por nombre o apellido
        public static List<ClsEmpleado> Buscar(string Nombre, string Apellidos)
        {
            List<ClsEmpleado> lista = new List<ClsEmpleado>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
           "SELECT intIdEmpleado, vchNombre, vchApellidos, vchDireccion, vchTelefono, intIdSucursal FROM tblEmpleados  where vchNombre ='{0}' or vchApellidos='{1}'", Nombre, Apellidos),ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsEmpleado Empleado = new ClsEmpleado();
                Empleado.IdEmpleado = _reader.GetInt32(0);
                Empleado.Nombre = _reader.GetString(1);
                Empleado.Apellidos = _reader.GetString(2);
                Empleado.Direccion = _reader.GetString(3);
                Empleado.Telefono = _reader.GetString(4);
                Empleado.IdSucursal = _reader.GetInt32(5);

                lista.Add(Empleado);
            }
            return lista;
        }

        public static int Actualizar(ClsEmpleado variables)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion(); 

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblEmpleados set vchNombre='{0}', vchApellidos='{1}', vchDireccion='{2}', vchTelefono='{3}', intIdSucursal='{4}' where intIdEmpleado={5}",
            variables.Nombre, variables.Apellidos, variables.Direccion, variables.Telefono, variables.IdSucursal,variables.IdEmpleado), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdEmpleado)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblEmpleados where intIdEmpleado={0}", IdEmpleado), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena combo
        public static List<ClsSucursal> ObtenerSucursal()
        {
           List<ClsSucursal> lista = new List<ClsSucursal>();

           MySqlConnection conexion = ClsConexion.ObtenerConexion();
           MySqlCommand comando = new MySqlCommand("select intIdSucursal , vchNombre from tblSucursales", conexion);
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
