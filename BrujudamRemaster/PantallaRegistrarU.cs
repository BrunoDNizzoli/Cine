using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;

namespace BrujudamRemaster
{

    

    public partial class PantallaRegistrarU : Form
    {
        SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = Brujudam1.09 ;Integrated Security=true");
        CN_Usuario objetoCN = new CN_Usuario();
        public PantallaRegistrarU()
        {
            InitializeComponent();
        }

      


        private void mensajeError(Control control)
        {
            MessageBox.Show(
                "Se deben completar los campos.",
                "ERROR",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            control.Focus();
        }
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void PantallaRegistrarU_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.InsertarPRod(txtUsuario.Text, txtApellido.Text, txtContraseña.Text, txtEmail.Text, txtDni.Text);
                MessageBox.Show("se creo correctamente");
                 PantallaPrincipal abrir = new PantallaPrincipal();
                abrir.Show();
                this.Hide();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se pudo insertar los datos por: " + ex);
            }
        }
    }
    
}

