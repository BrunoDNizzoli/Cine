using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;

namespace BrujudamRemaster
{
    public partial class AMBusuario : Form
    {
        CN_Usuario objetoCN = new CN_Usuario();
        private string id_Usuario = null;
        private bool Editar = false;

        public AMBusuario()
        {
            SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = CineBruju2 ;Integrated Security=true");

            InitializeComponent();
        }

        private void MostrarProdctos()
        {

            CN_Usuario objeto = new CN_Usuario();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AMBusuario_Load(object sender, EventArgs e)
        {
            MostrarProdctos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                txtDni.Text = dataGridView1.CurrentRow.Cells["dni"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                txtContraseña.Text = dataGridView1.CurrentRow.Cells["Contraseña"].Value.ToString();
                id_Usuario = dataGridView1.CurrentRow.Cells["id_Usuario"].Value.ToString();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Text = "";
            txtDni.Clear();
            txtEmail.Clear();
            txtContraseña.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txtNombre.Text, txtApellido.Text, txtContraseña.Text,txtEmail.Text, txtDni.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarProdctos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {

                try
                {
                    objetoCN.EditarProd(txtNombre.Text, txtApellido.Text, txtContraseña.Text, txtDni.Text, txtEmail.Text, id_Usuario);
                    MessageBox.Show("se edito correctamente");
                    MostrarProdctos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id_Usuario = dataGridView1.CurrentRow.Cells["id_Usuario"].Value.ToString();
                objetoCN.EliminarPRod(id_Usuario);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtIdUsuario.Text != "")
            {
                id_Usuario = txtIdUsuario.Text;
                objetoCN.ConsultarUsuario(txtIdUsuario.Text);
                txtNombre.Text = objetoCN.nombre;
                txtApellido.Text = objetoCN.apellido;
                txtContraseña.Text = objetoCN.CONTRASEÑA;

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            PantallaEmpleados abrir = new PantallaEmpleados();
            abrir.Show();
            this.Hide();
        }

        private void txtIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

