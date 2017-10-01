using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia
{
    class ClsDatos
    {
        public string Encriptar(string cadenaAencriptar)
        {
            string resultado = string.Empty;
            Byte[] encriptado = System.Text.Encoding.Unicode.GetBytes(cadenaAencriptar);
            resultado = Convert.ToBase64String(encriptado);

            return resultado;

        }


        public string Desencriptar(string cadenadesencriptar)
        {
            string resultado = string.Empty;
            try
            {
                Byte[] desencriptado = Convert.FromBase64String(cadenadesencriptar);
                resultado = System.Text.Encoding.Unicode.GetString(desencriptado);
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("El desencriptado fallo!!!");
            }
            return resultado;
        }
    }
}
