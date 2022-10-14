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
    public partial class AMBSalas2 : Form
    {

        CN_Salas objetoCN = new CN_Salas();
        private string idSala = null;
        private bool Editar = false;



        public AMBSalas2()
        {
            SqlConnection Conexion = new SqlConnection("Data Source = DESKTOP-C1L7NRC\\BRUNEROSERVER; Initial Catalog = CineBruju2 ;Integrated Security=true");
            InitializeComponent();
        }

        private void AMBSalas2_Load(object sender, EventArgs e)
        {
            MostrarSalas();
        }


        private void MostrarSalas()
        {

            CN_Salas objeto = new CN_Salas();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void limpiarForm()
        {
            txtButacas.Clear();
            txtidPelicula.Text = "";
            txtCapacidad.Clear();
            txtTipoSala.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarSa(txtButacas.Text, txtidPelicula.Text, txtCapacidad.Text, txtTipoSala.Text);
                    MessageBox.Show("se inserto correctamente");
                    MostrarSalas();
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
                    objetoCN.EditarSa(txtButacas.Text, txtidPelicula.Text, txtCapacidad.Text, txtTipoSala.Text, idSala);
                    MessageBox.Show("se edito correctamente");
                    MostrarSalas();
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
                txtButacas.Text = dataGridView1.CurrentRow.Cells["Butacas"].Value.ToString();
                txtidPelicula.Text = dataGridView1.CurrentRow.Cells["IdPelicula"].Value.ToString();
                txtCapacidad.Text = dataGridView1.CurrentRow.Cells["Capacidad"].Value.ToString();
                txtTipoSala.Text = dataGridView1.CurrentRow.Cells["TipoSala"].Value.ToString();

                idSala = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idSala = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarSa(idSala);
                MessageBox.Show("Eliminado correctamente");
                MostrarSalas();
            }
            else
                MessageBox.Show("seleccione una fila por favor");


        }
    
    }
}
