using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class ActividadEmpresa
    {
        /* Propiedades de la entidad */
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        public ActividadEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            IdActividadEmpresa = 0;
            Descripcion = string.Empty;
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.ActividadEmpresa tipo = bbdd.ActividadEmpresa.First(tb => tb.IdActividadEmpresa == IdActividadEmpresa);
                CommonBC.Syncronize(tipo, this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ActividadEmpresa> ReadAll()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                List<Datos.ActividadEmpresa> listaDatos = bbdd.ActividadEmpresa.ToList<Datos.ActividadEmpresa>();
                List<ActividadEmpresa> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception ex)
            {
                return new List<ActividadEmpresa>();
            }
        }

        private List<ActividadEmpresa> GenerarListado(List<Datos.ActividadEmpresa> listaDatos)
        {
            List<ActividadEmpresa> listaNegocio = new List<ActividadEmpresa>();

            foreach (Datos.ActividadEmpresa datos in listaDatos)
            {
                ActividadEmpresa negocio = new ActividadEmpresa();
                CommonBC.Syncronize(datos, negocio);

                listaNegocio.Add(negocio);
            }

            return listaNegocio;
        }
    }
}
