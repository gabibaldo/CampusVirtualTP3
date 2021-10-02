using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Pais
    {
        #region Propiedades
        public int? IdPais { get; private set; }
        public string Descripcion { get; private set; }
        #endregion


        #region Constructores

        public Pais()
        {
        }
        
        public Pais(int idPais, string descripcion)
        {
            Descripcion = descripcion;
            IdPais = idPais;
        }
        #endregion

        #region Metodos publicos

        public static List<Pais> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Paises.Listar();
            List<Pais> listaPaises = new List<Pais>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }

            return listaPaises;
        }
        public static Pais Obtener(int idPais)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.Obtener(idPais);

            return ArmarDatos(dt.Rows[0]);
        }
        public static List<Pais> Buscar(string descripcion)
        {
            DataTable dt = new DataTable();
            dt = Datos.Paises.Buscar(descripcion);
            List<Pais> listaPaises = new List<Pais>();

            foreach (DataRow item in dt.Rows)
            {
                listaPaises.Add(ArmarDatos(item));
            }

            return listaPaises;
        }
        public static void Eliminar(int idPais)
        {
            Datos.Paises.Eliminar(idPais);
        }
        public int Grabar()
        {
            try
            {
                if (Validar(out string error))
                {
                    if (IdPais == null)
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
            return Datos.Paises.Insertar(Descripcion);
        }
        private int Modificar()
        {
            Datos.Paises.Modificar(IdPais.Value, Descripcion);
            return IdPais.Value;
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
        private static Pais ArmarDatos(DataRow item)
        {
            Pais pais = new Pais();
            pais.IdPais = Convert.ToInt32(item["IdPais"]);
            pais.Descripcion = item["Descripcion"].ToString();
            
            return pais;
        }
        #endregion
    }
}