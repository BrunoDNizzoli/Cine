using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_USUARIOS
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, string apellido, string dni, string email, string CONTRASEÑA)
        {
            //PROCEDIMNIENTO

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@dni", dni);


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Editar(string nombre, string apellido, string CONTRASEÑA, string email, string dni, int id_Usuario)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@dni", dni);
            comando.Parameters.AddWithValue("@id_Usuario", id_Usuario);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id_Usuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_Usuario", id_Usuario);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable Consultar(string dni)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ConsultarDni";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dni", dni);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            adaptador.Fill(tabla);
            conexion.CerrarConexion();
            return tabla;
        }


    }
}
