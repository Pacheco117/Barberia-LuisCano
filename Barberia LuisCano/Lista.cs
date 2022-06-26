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
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
        }

        static String Conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=barberiaproyectofinal;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(Conexion);

        private void button1_Click(object sender, EventArgs e)
        {
            Menu ir = new Menu();
            ir.Show();
            this.Hide();
        }

        private void Lista_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenargrid();
        }

        public void Limpiar()
        {
            CuadroNCita.Clear();
        }

        public DataTable llenargrid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            String llenar = "SELECT agendar.N_cita, agendar.telefono, servicios.Servicio ,hora.Hora, agendar.Fecha FROM hora, agendar, servicios WHERE hora.ID_Hora = agendar.ID_Hora && servicios.Nservicio = agendar.Nservicio ORDER BY agendar.N_cita; ";
            MySqlCommand cmd = new MySqlCommand(llenar, cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();

            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String id = CuadroNCita.Text;

            string sql = "DELETE FROM agendar WHERE N_cita='" + id + "'";

            cn.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, cn);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
                Limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion;
            posicion = this.dataGridView1.CurrentRow.Index;
            CuadroNCita.Text = this.dataGridView1[0, posicion].Value.ToString();
        }
    }
}
