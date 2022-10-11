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
    public partial class AMBpeliculas : Form
    {
        CN_pelicula objetoCN = new CN_pelicula();
        private string id_Pelicula = null;
        private bool Editar = false;

        public AMBpeliculas()
        {
            SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = CineBruju2 ;Integrated Security=true");

            InitializeComponent();
        }





        private void MostrarProdctos()
        {

            CN_pelicula objeto = new CN_pelicula();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void AMBpeliculas_Load(object sender, EventArgs e)
        {
            MostrarProdctos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtDuracion.Text = dataGridView1.CurrentRow.Cells["Duracion"].Value.ToString();
                    txtSinopsis.Text = dataGridView1.CurrentRow.Cells["Sinopsis"].Value.ToString();
                    id_Pelicula = dataGridView1.CurrentRow.Cells["Id_Pelicula"].Value.ToString();

                }
                else
                    MessageBox.Show("seleccione una fila por favor");
            
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtDuracion.Text = "";
            txtSinopsis.Clear();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txtNombre.Text, txtSinopsis.Text, txtDuracion.Text, textBox1.Text, textBox2.Text );
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
                    objetoCN.EditarProd(txtNombre.Text, txtDuracion.Text, txtSinopsis.Text, Convert.ToInt32 (id_Pelicula), textBox1.Text, textBox2.Text);
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
                id_Pelicula = dataGridView1.CurrentRow.Cells["id_Pelicula"].Value.ToString();
                objetoCN.EliminarPRod(id_Pelicula);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtIdProd.Text != "")
            {
                id_Pelicula = txtIdProd.Text;
                objetoCN.ConsultarProd(id_Pelicula);
                txtNombre.Text = objetoCN.nombre;
                txtSinopsis.Text = objetoCN.sinopsis;
                txtDuracion.Text = objetoCN.duracion;
                
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            PantallaEmpleados abrir = new PantallaEmpleados();
            abrir.Show();
            this.Hide();
        }
    }
}
