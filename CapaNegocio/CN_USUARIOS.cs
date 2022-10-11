using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_USUARIOS objetoCD = new CD_USUARIOS();
        public string nombre { get; set; }

        public string apellido { get; set; }
        public string CONTRASEÑA { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        
        public int id_Usuario { get; set; }
        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, string apellido, string dni, string CONTRASEÑA, string email)
        {

            objetoCD.Insertar(nombre, apellido, dni, CONTRASEÑA, email);
        }

        public void EditarProd(string nombre, string apellido, string CONTRASEÑA, string dni, string email, string id_Usuario)
        {
            objetoCD.Editar(nombre, apellido, CONTRASEÑA, email, dni, Convert.ToInt32(id_Usuario));
        }

        public void EliminarPRod(string id_Usuario)
        {

            objetoCD.Eliminar(Convert.ToInt32(id_Usuario));
        }

        public void ConsultarUsuario(string dni)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Consultar(dni);
          

           foreach (DataRow dr in tabla.Rows)
            {
                
                nombre = dr[1].ToString();
                apellido = dr[2].ToString();
                CONTRASEÑA = dr[4].ToString();
                dni = dr[3].ToString();
                email = dr[5].ToString();
            }
           
        }

    }
}
