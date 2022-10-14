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
    public class CN_Salas
    {
        private CD_Salas objetoCD = new CD_Salas();
        public string butacas { get; set; }
        public string idpelicula { get; set; }
        public string capacidad { get; set; }
        public string tiposala { get; set; }

        public int id { get; set; }
        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarSa(string butacas, string idpelicula, string capacidad, string tiposala)
        {

            objetoCD.Insertar(butacas, Convert.ToInt32(idpelicula), Convert.ToInt32(capacidad), tiposala);
        }

        public void EditarSa(string butacas, string idpelicula, string capacidad, string tiposala, string id)
        {
            objetoCD.Editar(butacas, Convert.ToInt32(idpelicula), Convert.ToInt32(capacidad), tiposala, Convert.ToInt32(id));
        }

        public void EliminarSa(string id)
        {

            objetoCD.Eliminar(Convert.ToInt32(id));
        }
        public void ConsultarProd(string id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Consultar(Convert.ToInt32(id));


            foreach (DataRow dr in tabla.Rows)
            {

                id = dr[0].ToString();
                butacas = dr[1].ToString();
                idpelicula = dr[2].ToString();
                capacidad = dr[3].ToString();
                tiposala = dr[4].ToString();

            }

        }

    }
}