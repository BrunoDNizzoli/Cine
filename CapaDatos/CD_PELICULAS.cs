using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PELICULAS
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarPelicula";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, string sinopsis, string duracion, string imagenPelicula, string trailer)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarPelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@sinopsis", sinopsis);
            comando.Parameters.AddWithValue("@duracion", duracion);

            //comando.Parameters.AddWithValue("@imagenPelicula", imagenPelicula);
            //comando.Parameters.AddWithValue("@Trailer", trailer);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string nombre, string sinopsis, string duracion, int id_pelicula, string imagenPelicula, string trailer)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarPelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@sinopsis", sinopsis);
            comando.Parameters.AddWithValue("@duracion", duracion);
            //comando.Parameters.AddWithValue("@imagenPelicula", imagenPelicula);
            //comando.Parameters.AddWithValue("@Trailer", trailer);
            comando.Parameters.AddWithValue("@id", id_pelicula);


           comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id_Pelicula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarPelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id_Pelicula);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Consultar(int id_Pelicula)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ConsultarPelicula";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id_Pelicula);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
