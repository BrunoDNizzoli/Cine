using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrujudamRemaster
{
    public partial class PantallaEmpleados : Form
    {
        public PantallaEmpleados()
        {
            InitializeComponent();
        }

        private void btnAMBU_Click(object sender, EventArgs e)
        {
            AMBusuario abrir = new AMBusuario();
            abrir.Show();
            this.Hide();
        }

        private void btnAMBP_Click(object sender, EventArgs e)
        {
            AMBpeliculas abrir = new AMBpeliculas();
            abrir.Show();
            this.Hide();
        }

        private void btnAMBPRO_Click(object sender, EventArgs e)
        {
            AMBproductos abrir = new AMBproductos();
            abrir.Show();
            this.Hide();
        }

        private void btnAMBS_Click(object sender, EventArgs e)
        {
            AMBsalas abrir = new AMBsalas();
            abrir.Show();
            this.Hide();
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Login abrir = new Login();
            abrir.Show();
            this.Hide();
        }
    }
}
