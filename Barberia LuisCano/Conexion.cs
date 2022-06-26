using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Barberia_LuisCano
{
    internal class Conexion
    {
        public static MySqlConnection obtenerconexion()
        {
            MySqlConnection connect;
            string server = "127.0.0.1";
            string database = "barberiaproyectofinal";
            string user = "root";
            string pass = "";

            try
            {
                connect = new MySqlConnection("server = " + server + "; database = " + database + "; Uid = " + user + "; pwd = " + pass);
                connect.Open();
                return connect;
            }
            catch (Exception)
            {
                return connect = new MySqlConnection();
            }
        }
    }
}
