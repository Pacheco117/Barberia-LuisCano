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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }

        static String Conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=barberiaproyectofinal;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(Conexion);

        private void button1_Click(object sender, EventArgs e)
        {
            Login1 ir = new Login1();
            ir.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu ir = new Menu();
            ir.Show();
            this.Hide();
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("tahoma", 12, FontStyle.Bold);
            dataGridView1.DataSource = llenargrid();
        }
        public DataTable llenargrid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            String llenar = "select * from servicios";
            MySqlCommand cmd = new MySqlCommand(llenar, cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();

            return dt;
        }
    }
}
