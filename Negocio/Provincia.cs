using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Provincia
    {
        #region Propiedades
        public int? IdProvincia { get; private set; }
        public string Descripcion { get; private set; }
        #endregion


        #region Constructores

        public Provincia()
        {
        }
        
        public Provincia(int idProvincia, string descripcion)
        {
            Descripcion = descripcion;
            IdProvincia = idProvincia;
        }
        #endregion


        #region Metodos publicos
        public static List<Provincia> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Provincias.Listar();
            List<Provincia> listaProvincias = new List<Provincia>();

            foreach (DataRow item in dt.Rows)
            {
                listaProvincias.Add(ArmarDatos(item));
            }

            return listaProvincias;
        }

        public static Provincia Obtener(int idProvincia)
        {
            DataTable dt = new DataTable();
            dt = Datos.Provincias.Obtener(idProvincia);

            return ArmarDatos(dt.Rows[0]);
        }

        /*public static List<Provincia> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Provincias.Buscar(descripcion);
            List<Provincia> listaProvincias = new List<Provincia>();

            foreach (DataRow item in dt.Rows)
            {
                listaProvincias.Add(ArmarDatos(item));
            }

            return listaProvincias;
        }*/

        public static void Eliminar(int idProvincia)
        {
            Datos.Provincias.Eliminar(idProvincia);
        }

        public int Grabar()
        {
            if (IdProvincia == null)
            {
                if (Validar())
                    return Insertar();
                else
                    return 0;
            }
            else
            {
                if (Validar())
                    return Modificar();
                else
                    return 0;
            }
                
        }

        #endregion


        #region Metodos privados

        private int Insertar()
        {
            return Datos.Provincias.Insertar(Descripcion);
        }
        private int Modificar()
        {
            Datos.Provincias.Modificar(IdProvincia.Value, Descripcion);
            return IdProvincia.Value;
        }
        private bool Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
                return false;
            else
                return true;
        }
        private static Provincia ArmarDatos(DataRow item)
        {
            Provincia Provincia = new Provincia();
            Provincia.IdProvincia = Convert.ToInt32(item["IdProvincia"]);
            Provincia.Descripcion = item["Descripcion"].ToString();

            return Provincia;
        }
        #endregion
    }
}