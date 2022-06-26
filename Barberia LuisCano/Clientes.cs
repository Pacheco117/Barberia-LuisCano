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
    public partial class Clientes : Form
    {
        public Clientes()
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
            
            
        public void BtnConfirmar_Click(object sender, EventArgs e)
        {
            cn.Open();
            string insertar = "INSERT INTO clientes(Nombre,ApellidoP,ApellidoM,Telefono,ID_Sexo)values(@Nombre,@ApellidoP,@ApellidoM,@Telefono,@ID_Sexo)";
            string insertar2 = "INSERT INTO agendar(agendar.Telefono,agendar.Nservicio,agendar.ID_Hora,agendar.Fecha)VALUES(@Telefono,@Nservicio,@ID_Hora,@Fecha)";


            MySqlCommand cmd = new MySqlCommand(insertar, cn);
            MySqlCommand cmd2 = new MySqlCommand(insertar2, cn);

            cmd2.Parameters.AddWithValue("@Fecha", CuadroFecha.Text);
            cmd2.Parameters.AddWithValue("@Telefono", CuadroTelefono.Text);

            cmd.Parameters.AddWithValue("@Nombre", CuadroNombre.Text);
            cmd.Parameters.AddWithValue("@ApellidoP", CuadroApellidoP.Text);
            cmd.Parameters.AddWithValue("@ApellidoM", CuadroApellidoM.Text);
            cmd.Parameters.AddWithValue("@Telefono", CuadroTelefono.Text);

            if (radioButtonadulto.Checked == true)
            {
                radioButtonadulto.Text = "1";
                cmd2.Parameters.AddWithValue("@Nservicio", radioButtonadulto.Text);
            }

            if (radioButtonnino.Checked == true)
            {
                radioButtonnino.Text = "2";
                cmd2.Parameters.AddWithValue("@Nservicio", radioButtonnino.Text);
            }

            if (radioButtonblackmask.Checked == true)
            {
                radioButtonblackmask.Text = "3";
                cmd2.Parameters.AddWithValue("@Nservicio", radioButtonblackmask.Text);
            }

            if (radioButtonceja.Checked == true)
            {
                radioButtonceja.Text = "4";
                cmd2.Parameters.AddWithValue("@Nservicio", radioButtonceja.Text);
            }

            if (radioButtoncortebarba.Checked == true)
            {
                radioButtoncortebarba.Text = "5";
                cmd2.Parameters.AddWithValue("@Nservicio", radioButtoncortebarba.Text);
            }

            if (radioButtonDOS.Checked == true)
            {
                radioButtonDOS.Text = "1";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonDOS.Text);
            }

            if (radioButtonTRES.Checked == true)
            {
                radioButtonTRES.Text = "2";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonTRES.Text);
            }

            if (radioButtonCUATRO.Checked == true)
            {
                radioButtonCUATRO.Text = "3";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonCUATRO.Text);
            }

            if (radioButtonCINCO.Checked == true)
            {
                radioButtonCINCO.Text = "4";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonCINCO.Text);
            }

            if (radioButtonSEIS.Checked == true)
            {
                radioButtonSEIS.Text = "5";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonSEIS.Text);
            }

            if (radioButtonSIETE.Checked == true)
            {
                radioButtonSIETE.Text = "6";
                cmd2.Parameters.AddWithValue("@ID_Hora", radioButtonSIETE.Text);
            }


            if (radioButtonHOMBRE.Checked == true)
            {
                radioButtonHOMBRE.Text = "1";
                cmd.Parameters.AddWithValue("@ID_Sexo", radioButtonHOMBRE.Text);             
            }

            if (radioButtonMUJER.Checked == true)
            {
                radioButtonMUJER.Text = "2";
                cmd.Parameters.AddWithValue("@ID_Sexo", radioButtonMUJER.Text);
            }

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            cn.Close();

            Menu ir = new Menu();
            ir.Show();
            this.Hide();
        }

        public void CuadroTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        public void CuadroNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void CuadroApellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        public void CuadroApellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
