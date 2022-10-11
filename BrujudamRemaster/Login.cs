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



namespace BrujudamRemaster
{
    public partial class Login : Form
    {
        #region Eventos

        SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = CineBruju2 ;Integrated Security=true");

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(CerrarForm);


        }

        private void CerrarForm(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                mensajeError(txtUsuario);
                return;
            }


            Conexion.Close();
            Conexion.Open();
            SqlCommand Comando = new SqlCommand("SELECT Nombre, CONTRASEÑA FROM Usuario WHERE Nombre = @nombre AND CONTRASEÑA = @CONTRASEÑA", Conexion);
            Comando.Parameters.AddWithValue("@nombre", txtUsuario.Text);
            Comando.Parameters.AddWithValue("@CONTRASEÑA", txtContraseña.Text);
            SqlDataReader Lector = Comando.ExecuteReader();

            if (Lector.Read())
            {
                MessageBox.Show("INGRESO EXITOSO",
                    "Notificacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                PantallaPrincipal abrir = new PantallaPrincipal();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("USUARIO INEXISTENTE",
                    "Notificacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }



        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Desea Cancelar su ingreso?",
                "CANCELAR INGRESO",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
            if (Resultado == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }

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

        private bool isNumeric(string valor)
        {
            try
            {
                Convert.ToDouble(valor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            PantallaRegistrarU abrir = new PantallaRegistrarU();
            abrir.Show();
            this.Hide();
        }

        private void abmpelis_Click(object sender, EventArgs e)
        {
            AMBpeliculas abrir = new AMBpeliculas();
            abrir.Show();
            this.Hide();
        }

        private void AMBusuario_Click(object sender, EventArgs e)
        {
            AMBusuario abrir = new AMBusuario();
            abrir.Show();
            this.Hide();
        }

        private void AMBproductos_Click(object sender, EventArgs e)
        {

            AMBproductos abrir = new AMBproductos();
            abrir.Show();
            this.Hide();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            PantallaEmpleados abrir = new PantallaEmpleados();
            abrir.Show();
            this.Hide();
        }
    }


}
