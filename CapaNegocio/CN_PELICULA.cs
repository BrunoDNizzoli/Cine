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
    public class CN_pelicula
    {
        private CD_PELICULAS objetoCD = new CD_PELICULAS();
       
        public string nombre { get; set; }

        public string sinopsis { get; set; }
        public string duracion { get; set; }

        public string imagenPelicula { get; set; }

        public string Trailer { get; set; }
        public int  id_Pelicula { get; set; }
       
        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, string sinopsis, string duracion, string imagenPelicula, string Trailer)
        {

            objetoCD.Insertar(nombre, sinopsis, duracion, imagenPelicula, Trailer);
        }

        public void EditarProd(string nombre, string sinopsis, string duracion, int id_Pelicula, string imagenPelicula, string Trailer)
        {
            objetoCD.Editar(nombre, sinopsis, duracion, Convert.ToInt32(id_Pelicula), imagenPelicula, Trailer);
        }

        public void EliminarPRod(string id_Pelicula)
        {

            objetoCD.Eliminar(Convert.ToInt32(id_Pelicula));
        }

        public void ConsultarProd(string id_Pelicula)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Consultar(Convert.ToInt32(id_Pelicula));


            foreach (DataRow dr in tabla.Rows)
            {

                id_Pelicula = dr[0].ToString();
                nombre = dr[1].ToString();
                sinopsis = dr[2].ToString();
                duracion = dr[3].ToString();
                
            }

        }

    }
}