using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Materia
    {
        #region Propiedades
        public int? IdMateria { get; set; }
        public string Descripcion { get; set; }
        #endregion


        #region Constructores
        public Materia()
        {
        }

        public Materia(int idMateria, string descripcion)
        {
            IdMateria = idMateria;
            Descripcion = descripcion;
        }
        #endregion


        #region Metodos publicos

        public static List<Materia> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Materias.Listar();
            List<Materia> listaMaterias = new List<Materia>();

            foreach (DataRow item in dt.Rows)
            {
                listaMaterias.Add(ArmarDatos(item));
            }

            return listaMaterias;
        }
        
        public static Materia Obtener(int idMateria)
        {
            DataTable dt = new DataTable();
            dt = Datos.Materias.Obtener(idMateria);

            return ArmarDatos(dt.Rows[0]);
        }

        /*public static List<Pais> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.Buscar(descripcion);
            List<Pais> listaPaises = new List<Pais>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }

            return listaPaises;
        }*/

        public static void Eliminar(int idMateria)
        {
            Datos.Paises.Eliminar(idMateria);
        }
        
        public int Grabar()
        {
            try
            {
                if (Validar(out string error))
                {
                    if (IdMateria == null)
                    {
                        return Insertar();
                    }
                    else
                    {
                        return Modificar();
                    }
                }
                else
                    throw new Exception(error);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Metodos privados

        private int Insertar()
        {
            return Datos.Materias.Insertar(Descripcion);
        }
        private int Modificar()
        {
            Datos.Materias.Modificar(IdMateria.Value, Descripcion);
            return IdMateria.Value;
        }
        private bool Validar(out string error)
        {
            error = "";

            if (string.IsNullOrEmpty(Descripcion))
                error += "La descripción ingresada se encuentra vacia ";

            if (string.IsNullOrEmpty(error))
                return true;
            else
                return false;               
        }
        private static Materia ArmarDatos(DataRow item)
        {
            Materia materia = new Materia();
            materia.IdMateria = Convert.ToInt32(item["IdMateria"]);
            materia.Descripcion = item["Descripcion"].ToString();
            
            return materia;
        }
        #endregion
    }
}