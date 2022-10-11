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
        private CD_SALAS objetoCD = new CD_SALAS();
        public string butacas { get; set; }

        public string id_pelicula { get; set; }
        public string tipo_sala { get; set; }
        public string capacidad { get; set; }
        public int id_sala { get; set; }
        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string id_pelicula, string tipo_sala, string butacas, string capacidad)
        {

            objetoCD.Insertar(id_pelicula, tipo_sala, butacas , capacidad);
        }

        public void EditarProd(string id_pelicula, string tipo_sala, string butacas, string capacidad, string id_sala)
        {
            objetoCD.Editar(id_pelicula,tipo_sala, butacas, capacidad, id_sala);
        }

        public void EliminarPRod(string id_sala)
        {

            objetoCD.Eliminar(Convert.ToInt32(id_sala));
        }

        public void ConsultarProd(string id_sala)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Consultar(Convert.ToInt32(id_sala));


            foreach (DataRow dr in tabla.Rows)
            {

                id_sala = dr[0].ToString();
                butacas = dr[1].ToString();

                capacidad = dr[3].ToString();
                tipo_sala = dr[4].ToString();
                id_pelicula = dr[5].ToString();
            }

        }

    }
}