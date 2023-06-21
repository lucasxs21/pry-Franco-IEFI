using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry_Franco_IEFI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal ingreso = 1000;
            bool sexo1 = true;
            if (optM.Checked == true)
            {
                sexo1 = true;
            }
            else if (optM.Checked == false)
            {
                sexo1 = false;
            }
            clsDatos datos = new clsDatos();
            datos.Registrar(txtNombre.Text, txtApellido.Text, cmbPais.Text, Convert.ToInt32(txtEdad.Text), sexo1, ingreso, Convert.ToInt32(txtPuntaje.Text));
        }
    }
}
