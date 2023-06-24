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
            txtEdad.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            cmbPais.SelectedIndex = -1;
            txtPuntaje.Text = "";
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion de numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void txtPuntaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion de numeros 
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion de letras
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion de letras
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            optM.Checked = true;
            
            clsDatos datos = new clsDatos();
            datos.CargarDatos(cmbPais);
        }

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtNombre.Text != "" && cmbPais.Text != "" && txtEdad.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmInicio form = new frmInicio();
            form.Show();
            this.Hide();
        }
    }
}
