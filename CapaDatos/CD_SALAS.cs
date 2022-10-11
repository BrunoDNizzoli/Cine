using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_SALAS
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarSala";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string Butacas, string id_pelicula, string Tipo_sala, string Capacidad)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarSalas";
            comando.CommandType = CommandType.StoredProcedure;
            
            comando.Parameters.AddWithValue("@butacas", Butacas);
            comando.Parameters.AddWithValue("@idpelicula", id_pelicula);
            comando.Parameters.AddWithValue("@tiposala", Tipo_sala);
            comando.Parameters.AddWithValue("@capacidad", Capacidad);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string Butacas, string id_pelicula, string Tipo_sala, string Capacidad, string id_sala)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarSalas";
            comando.CommandType = CommandType.StoredProcedure;
           
            comando.Parameters.AddWithValue("@butacas", Butacas);
            comando.Parameters.AddWithValue("@idpelicula", id_pelicula);
            comando.Parameters.AddWithValue("@tiposala", Tipo_sala);
            comando.Parameters.AddWithValue("@capacidad", Capacidad);
            comando.Parameters.AddWithValue("@id", id_sala);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int Id_Sala)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarSala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idsa", Id_Sala);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Consultar(int Id_Sala)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ConsultarSala";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idsa", Id_Sala);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}