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
    public partial class Login1 : Form
    {
        string Usuario = "Luis Cano";
        string Contraseña = "admin12345";

        public Login1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Servicios ir = new Servicios();
            ir.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CajaUsuario.Text != Usuario || CajaContraseña.Text != Contraseña)
            {
                if (CajaUsuario.Text != Usuario)
                {

                    MessageBox.Show("Usuario Incorrecto");
                    CajaUsuario.Clear();
                    CajaUsuario.Focus();
                    return;

                }

                if (CajaContraseña.Text != Contraseña)
                {

                    MessageBox.Show("Contraseña Incorrecta");
                    CajaContraseña.Clear();
                    CajaContraseña.Focus();
                    return;

                }
            }
            else
            {
                CambioPrecio ir = new CambioPrecio();
                ir.Show();
                this.Hide();

            }
        }
    }
}
