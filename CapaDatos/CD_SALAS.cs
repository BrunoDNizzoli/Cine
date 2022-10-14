using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace CapaDatos
{
    public class CD_Salas
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarSalas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public void Insertar(string butacas, int idpelicula, int capacidad, string tiposala)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarSalas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@butacas", butacas);
            comando.Parameters.AddWithValue("@idPelicula", idpelicula);
            comando.Parameters.AddWithValue("@capacidad", capacidad);
            comando.Parameters.AddWithValue("@tiposala", tiposala);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        public void Editar(string butacas, int idpelicula, int capacidad, string tiposala, int id)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@butacas", butacas);
            comando.Parameters.AddWithValue("@idPelicula", idpelicula);
            comando.Parameters.AddWithValue("@capacidad", capacidad);
            comando.Parameters.AddWithValue("@tiposala", tiposala);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarSalas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idsa", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        public DataTable Consultar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ConsultarSalas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idsa", id);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }
    }
}

