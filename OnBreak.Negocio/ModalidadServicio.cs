using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    class ModalidadServicio
    {
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public float ValorBase { get; set; }
        public int PersonalBase { get; set; }
        

        public ModalidadServicio()
        {
            this.Init();
        }

        private void Init()
        {
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            Nombre = string.Empty;
            ValorBase = 0;
            PersonalBase = 0;
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.ModalidadServicio tipo = bbdd.ModalidadServicio.First(tb => tb.IdModalidad == IdModalidad);
                CommonBC.Syncronize(tipo, this);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ModalidadServicio> ReadAll()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                List<Datos.ModalidadServicio> listaDatos = bbdd.ModalidadServicio.ToList<Datos.ModalidadServicio>();
                List<ModalidadServicio> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception ex)
            {
                return new List<ModalidadServicio>();
            }
        }

        private List<ModalidadServicio> GenerarListado(List<Datos.ModalidadServicio> listaDatos)
        {
            List<ModalidadServicio> listaNegocio = new List<ModalidadServicio>();

            foreach (Datos.ModalidadServicio datos in listaDatos)
            {
                ModalidadServicio negocio = new ModalidadServicio();
                CommonBC.Syncronize(datos, negocio);

                listaNegocio.Add(negocio);
            }

            return listaNegocio;
        }
    }
}
