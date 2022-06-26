using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Barberia_LuisCano.Controlador;

namespace Barberia_LuisCano
{
    internal class Funciones2
    {
        public static bool ActualizarCliente(ConstructorCliente upd)
        {
            bool retorno;

            MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE clientes SET Nombre = '{0}', ApellidoP = '{1}', ApellidoM = '{2}', Telefono = '{3}' , ID_Sexo = '{4}' WHERE Telefono = '{3}'", upd.Nombre, upd.ApellidoP, upd.ApellidoM, upd.Telefono, upd.ID_Sexo), Conexion.obtenerconexion());
            retorno = Convert.ToBoolean(cmd.ExecuteNonQuery());
            return retorno;
        }
    }
}
