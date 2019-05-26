using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class Cliente
    {
        /* Campos */
        string _descripcionTipo;
        string _descripcionActividad;

        /* Propiedades de la entidad */
        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }

        /* Propiedades customizadas */
        public string DescripcionTipo { get { return _descripcionTipo; } }
        public string DescripcionActividad { get { return _descripcionActividad; } }

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            RutCliente = string.Empty;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            MailContacto = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            IdActividadEmpresa = 0;
            IdTipoEmpresa = 0;

            _descripcionTipo = string.Empty;
            _descripcionActividad = string.Empty;
        }

        public bool Create()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();
            Datos.Cliente cte = new Datos.Cliente();
            try
            {
                CommonBC.Syncronize(this, cte);
                bbdd.Cliente.Add(cte);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.Cliente.Remove(cte);
                return false;
            }
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.Cliente cte = bbdd.Cliente.First(b => b.RutCliente == RutCliente);
                CommonBC.Syncronize(cte, this);

                /* Carga descripción del Tipo */
                LeerDescripcionTipo();
                /* Carga descripción de la Actividad */
                LeerDescripcionActividad();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.Cliente cte = bbdd.Cliente.First(b => b.RutCliente == RutCliente);
                CommonBC.Syncronize(this, cte);

                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.Cliente cte = bbdd.Cliente.First(b => b.RutCliente == RutCliente);

                bbdd.Cliente.Remove(cte);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LeerDescripcionTipo()
        {
            TipoEmpresa tipo = new TipoEmpresa() { IdTipoEmpresa = IdTipoEmpresa };

            if (tipo.Read())
            {
                _descripcionTipo = tipo.Descripcion;
            }
            else
            {
                _descripcionTipo = string.Empty;
            }
        }

        public void LeerDescripcionActividad()
        {
            ActividadEmpresa actividad = new ActividadEmpresa() { IdActividadEmpresa = IdActividadEmpresa };

            if (actividad.Read())
            {
                _descripcionActividad = actividad.Descripcion;
            }
            else
            {
                _descripcionActividad = string.Empty;
            }
        }

        public List<Cliente> ReadAll()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();
            try
            {
                List<Datos.Cliente> listaDatos = bbdd.Cliente.ToList<Datos.Cliente>();
                List<Cliente> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        private List<Cliente> GenerarListado(List<Datos.Cliente> listaDatos)
        {
            List<Cliente> listaNegocio = new List<Cliente>();
            foreach (Datos.Cliente datos in listaDatos)
            {
                Cliente negocio = new Cliente();
                CommonBC.Syncronize(datos, negocio);
                negocio.LeerDescripcionTipo();

                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
        
        public List<Cliente> ReadByTipoEmpresa(int idTipoEmpresa)
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                List<Datos.Cliente> listaDatos =
                    bbdd.Cliente.Where(b => b.IdTipoEmpresa == idTipoEmpresa).ToList<Datos.Cliente>();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public List<Cliente> ReadByTipoActividad(int idTipoActividad)
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                List<Datos.Cliente> listaDatos =
                    bbdd.Cliente.Where(b => b.IdActividadEmpresa == idTipoActividad).ToList<Datos.Cliente>();

                List<Cliente> listaNegocio = GenerarListado(listaDatos);

                return listaNegocio;

            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }
    }
}
