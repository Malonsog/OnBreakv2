using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class TipoEmpresa
    {
        /* Propiedades de la entidad */
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpresa()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoEmpresa = 0;
            Descripcion = string.Empty;
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.TipoEmpresa tipo = bbdd.TipoEmpresa.First(tb => tb.IdTipoEmpresa == IdTipoEmpresa);
                CommonBC.Syncronize(tipo, this);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<TipoEmpresa> ReadAll()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();
            try
            {
                List<Datos.TipoEmpresa> listaDatos = bbdd.TipoEmpresa.ToList<Datos.TipoEmpresa>();
                List<TipoEmpresa> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception)
            {
                return new List<TipoEmpresa>();
            }
        }

        private List<TipoEmpresa> GenerarListado(List<Datos.TipoEmpresa> listaDatos)
        {
            List<TipoEmpresa> listaNegocio = new List<TipoEmpresa>();

            foreach (Datos.TipoEmpresa datos in listaDatos)
            {
                TipoEmpresa negocio = new TipoEmpresa();
                CommonBC.Syncronize(datos, negocio);

                listaNegocio.Add(negocio);
            }

            return listaNegocio;
        }
    }
}
