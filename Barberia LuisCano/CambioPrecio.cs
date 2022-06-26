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
    public partial class CambioPrecio : Form
    {
        ConstructorServicio actualizar = new ConstructorServicio();
        
        public CambioPrecio()
        {
            InitializeComponent();
        }

        static String Conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=barberiaproyectofinal;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(Conexion);

        public void Modificar()
        {
            actualizar.Nservicio = Convert.ToString(CuadroNServicio.Text);
            actualizar.Servicio = Convert.ToString(CuadroServicio.Text);
            actualizar.precio = Convert.ToString(CuadroPrecio.Text);        
            Funciones.ActualizarServicio(actualizar);
        }
        public void Limpiar()
        {
            CuadroNServicio.Clear();
            CuadroServicio.Clear();
            CuadroPrecio.Clear();
        }
        private void CambioPrecio_Load(object sender, EventArgs e)
        {
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int posicion;
            posicion = this.dataGridView1.CurrentRow.Index;
            CuadroNServicio.Text = this.dataGridView1[0, posicion].Value.ToString();
            CuadroServicio.Text = this.dataGridView1[1, posicion].Value.ToString();
            CuadroPrecio.Text = this.dataGridView1[2, posicion].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicios ir = new Servicios();
            ir.Show();
            this.Hide();
        }

        private void buttoneditar_Click(object sender, EventArgs e)
        {
            Modificar();
            Limpiar();
            buttoneditar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String id = CuadroNServicio.Text;

            string sql = "DELETE FROM servicios WHERE Nservicio='" + id + "'";

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
    }
}
