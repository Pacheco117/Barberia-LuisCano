using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Barberia_LuisCano
{
    public partial class ListaClientes : Form
    {
        public ListaClientes()
        {
            InitializeComponent();
        }

        static String Conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=barberiaproyectofinal;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(Conexion);

        private void buttoneditar_Click(object sender, EventArgs e)
        {
            Login2 ir = new Login2();
            ir.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu ir = new Menu();
            ir.Show();
            this.Hide();
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenargrid();
        }

        public DataTable llenargrid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            String llenar = "SELECT clientes.Nombre, clientes.ApellidoP, clientes.ApellidoM, sexo.Sexo FROM clientes, sexo WHERE sexo.ID_Sexo = clientes.ID_Sexo;";
            MySqlCommand cmd = new MySqlCommand(llenar, cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();

            return dt;
        }
    }
}
