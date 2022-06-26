using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Barberia_LuisCano
{
    internal class Funciones
    {
        public static bool ActualizarServicio(ConstructorServicio upd)
        {
            bool retorno;
            
                MySqlCommand cmd = new MySqlCommand(string.Format("UPDATE servicios SET Servicio = '{0}', Precio = '{1}' WHERE Nservicio = '{2}'", upd.Servicio,upd.precio,upd.Nservicio), Conexion.obtenerconexion());
                retorno = Convert.ToBoolean(cmd.ExecuteNonQuery());
                return retorno;
                      
        }
    }
}
