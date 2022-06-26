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
using Barberia_LuisCano.Controlador;

namespace Barberia_LuisCano
{
    public partial class CambiarDatos : Form
    {
        ConstructorCliente actualizar = new ConstructorCliente();
        public CambiarDatos()
        {
            InitializeComponent();
        }

        static String Conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=barberiaproyectofinal;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(Conexion);

        public void Modificar()
        {
            actualizar.Telefono = Convert.ToString(CuadroTelefono.Text);
            actualizar.Nombre = Convert.ToString(CuadroNombre.Text);
            actualizar.ApellidoP = Convert.ToString(CuadroApellidoP.Text);
            actualizar.ApellidoM = Convert.ToString(CuadroApellidoM.Text);
            actualizar.ID_Sexo = Convert.ToString(CuadroSexo.Text);
            Funciones2.ActualizarCliente(actualizar);
        }

        public void Limpiar()
        {
            CuadroTelefono.Clear();
            CuadroNombre.Clear();
            CuadroApellidoP.Clear();
            CuadroApellidoM.Clear();
            CuadroSexo.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListaClientes ir = new ListaClientes();
            ir.Show();
            this.Hide();
        }

        private void CambiarDatos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenargrid();
        }

        public DataTable llenargrid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            String llenar = "select * from clientes";
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
            CuadroTelefono.Text = this.dataGridView1[0, posicion].Value.ToString();
            CuadroNombre.Text = this.dataGridView1[1, posicion].Value.ToString();
            CuadroApellidoP.Text = this.dataGridView1[2, posicion].Value.ToString();
            CuadroApellidoM.Text = this.dataGridView1[3, posicion].Value.ToString();
            CuadroSexo.Text = this.dataGridView1[4, posicion].Value.ToString();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar();
            Limpiar();
            editarToolStripMenuItem.Enabled = false;

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String id = CuadroTelefono.Text;

            string sql = "DELETE FROM clientes WHERE Telefono='" + id + "'";

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
