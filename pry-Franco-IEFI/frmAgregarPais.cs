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
    public partial class frmAgregarPais : Form
    {
        public frmAgregarPais()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInicio form = new frmInicio();
            form.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsDatos datos = new clsDatos();
            datos.AgregarPais(txtPais.Text);
        }

        private void frmAgregarPais_Load(object sender, EventArgs e)
        {

        }
    }
}
