using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class TipoEvento
    {
        /* Propiedades de la entidad */
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento()
        {
            this.Init();
        }

        private void Init()
        {
            IdTipoEvento = 0;
            Descripcion = string.Empty;
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.TipoEvento tipo = bbdd.TipoEvento.First(tb => tb.IdTipoEvento == IdTipoEvento);
                CommonBC.Syncronize(tipo, this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TipoEvento> ReadAll()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                List<Datos.TipoEvento> listaDatos = bbdd.TipoEvento.ToList<Datos.TipoEvento>();
                List<TipoEvento> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception ex)
            {
                return new List<TipoEvento>();
            }
        }

        private List<TipoEvento> GenerarListado(List<Datos.TipoEvento> listaDatos)
        {
            List<TipoEvento> listaNegocio = new List<TipoEvento>();

            foreach (Datos.TipoEvento datos in listaDatos)
            {
                TipoEvento negocio = new TipoEvento();
                CommonBC.Syncronize(datos, negocio);

                listaNegocio.Add(negocio);
            }

            return listaNegocio;
        }
    }
}
