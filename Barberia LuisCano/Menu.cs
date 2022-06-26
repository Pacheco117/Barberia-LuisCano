using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia_LuisCano
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clientes ir = new Clientes();
            ir.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Servicios ir = new Servicios();
            ir.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lista ir = new Lista();
            ir.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaClientes ir = new ListaClientes();
            ir.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
