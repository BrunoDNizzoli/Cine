using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;

namespace BrujudamRemaster
{
    public partial class AMBsalas : Form
    {
        CN_Salas objetoCN = new CN_Salas();
        private string idSala = null;
        private bool Editar = false;

        public AMBsalas()
        {
            SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = CineBruju2 ;Integrated Security=true");
            InitializeComponent();
        }

        private void AMBsalas_Load(object sender, EventArgs e)
        {
            MostrarProdctos();
        }

        private void limpiarForm()
        {

            txtIdPelicula.Text = "";
            txtTipoSala.Clear();
            txtCapacidad.Clear();
            txtButacas.Clear();
        }
        private void MostrarProdctos()
        {

            CN_Salas objeto = new CN_Salas();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRod(txtIdPelicula.Text, txtTipoSala.Text, txtCapacidad.Text, txtButacas.Text);
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
                    objetoCN.EditarProd(txtIdPelicula.Text, txtTipoSala.Text, txtCapacidad.Text, txtButacas.Text, idSala);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtIdPelicula.Text = dataGridView1.CurrentRow.Cells["Id_Pelicula"].Value.ToString();
                txtTipoSala.Text = dataGridView1.CurrentRow.Cells["TipoSala"].Value.ToString();

                txtCapacidad.Text = dataGridView1.CurrentRow.Cells["Capacidad"].Value.ToString();
                txtButacas.Text = dataGridView1.CurrentRow.Cells["Butacas"].Value.ToString();
                idSala = dataGridView1.CurrentRow.Cells["Id_Sala"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idSala = dataGridView1.CurrentRow.Cells["id_Sala"].Value.ToString();
                objetoCN.EliminarPRod(idSala);
                MessageBox.Show("Eliminado correctamente");
                MostrarProdctos();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
    
}
