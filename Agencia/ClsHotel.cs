using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Configuration;

namespace Agencia
{
    class ClsHotel
    {
        public int IdHotel { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string LogoNombre { get; set; }
        public string LogoRuta { get; set; }

        public ClsHotel() { }

        public ClsHotel(int pIdHotel, string pNombre, string pCategoria, string pTelefono, string pCorreo, string pDireccion, string pLogoNombre, string pLogoRuta)
        {
            this.IdHotel = pIdHotel;
            this.Nombre = pNombre;
            this.Categoria = pCategoria;
            this.Telefono = pTelefono;
            this.Correo = pCorreo;
            this.Direccion = pDireccion;
            this.LogoNombre = pLogoNombre;
            this.LogoRuta = pLogoRuta;
        }

        public static int Guardar(ClsHotel variable)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tblHotel (intidhotel, vchnombre, vchcategoria, vchtelefono, vchcorreo, vchdireccion , vchlogoNombre, vchlogoruta) VALUES ('{0}','{1}','{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
            variable.IdHotel, variable.Nombre, variable.Categoria, variable.Telefono, variable.Correo, variable.Direccion, variable.LogoNombre, variable.LogoRuta), ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        public static int Actualizar(ClsHotel variables)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tblHotel set vchNombre='{0}', vchCategoria='{1}', vchTelefono='{2}', vchCorreo='{3}', vchdireccion='{4}', vchlogonombre='{5}', vchlogoruta='{6}' where intIdHotel={7}",
            variables.Nombre, variables.Categoria, variables.Telefono, variables.Correo, variables.Direccion, variables.LogoNombre, variables.IdHotel), conexion);//trono ya valio juven
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdHotel)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblHotel where intIdHotel={0}", IdHotel), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena tabla
        public static List<ClsHotel> MostrarDatos()
        {
            List<ClsHotel> lista = new List<ClsHotel>();

            MySqlCommand _comando = new MySqlCommand(String.Format("select * from tblhotel"), ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsHotel Hotel = new ClsHotel();
                Hotel.IdHotel = _reader.GetInt32(0);
                Hotel.Nombre = _reader.GetString(1);
                Hotel.Categoria = _reader.GetString(2);
                Hotel.Telefono = _reader.GetString(3);
                Hotel.Correo = _reader.GetString(4);
                Hotel.Direccion = _reader.GetString(5);

                lista.Add(Hotel);
            }
            return lista;
        }




    }
}
