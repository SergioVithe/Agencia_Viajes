using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Agencia
{
    class ClsEventos
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Fecha { get; set; }

        public ClsEventos() { }

        //estos son los variables que se mandan a llamar
        public ClsEventos(int pIdEventos, string pNombre, string pDescripcion, string pDireccion, string pFecha)
        {
            this.IdEvento = pIdEventos;
            this.Nombre = pNombre;
            this.Descripcion = pDescripcion;
            this.Direccion = pDireccion;
            this.Fecha = pFecha;
        }


        public static int Guardar(ClsEventos variable)
        {
            int bandera = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("INSERT INTO tbleventos (intidevento, vchnombre, vchdescripcion, vchdireccion, vchfecha) VALUES ('{0}','{1}','{2}', '{3}', '{4}')",
            variable.IdEvento, variable.Nombre, variable.Descripcion, variable.Direccion, variable.Fecha), ClsConexion.ObtenerConexion());
            bandera = comando.ExecuteNonQuery();
            return bandera;
        }

        public static int Actualizar(ClsEventos variable)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update tbleventos set vchNombre='{0}', vchDescripcion='{1}', vchDireccion='{2}', vchFecha='{3}' where intIdEvento='{4}'",
            variable.Nombre, variable.Descripcion, variable.Direccion, variable.Fecha, variable.IdEvento), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        public static int Eliminar(int IdEvento)
        {
            int bandera = 0;
            MySqlConnection conexion = ClsConexion.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(string.Format("Delete From tblEventos where intIdEvento={0}", IdEvento), conexion);
            bandera = comando.ExecuteNonQuery();
            conexion.Close();
            return bandera;
        }

        //llena tabla
        public static List<ClsEventos> MostrarDatos()
        {
            List<ClsEventos> lista = new List<ClsEventos>();

            MySqlCommand comando = new MySqlCommand(String.Format("select * from tblEventos"), ClsConexion.ObtenerConexion());
            MySqlDataReader _reader = comando.ExecuteReader();
            while (_reader.Read())
            {
                ClsEventos Evento = new ClsEventos();
                Evento.IdEvento = _reader.GetInt32(0);
                Evento.Nombre = _reader.GetString(1);
                Evento.Descripcion = _reader.GetString(2);
                Evento.Direccion = _reader.GetString(3);
                Evento.Fecha = _reader.GetString(4);

                lista.Add(Evento);
            }
            return lista;
        }
    }
}
