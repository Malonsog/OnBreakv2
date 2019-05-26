using OnBreak.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class Contrato
    {
        string _modalidadServicio;

        public string Numero { get; set; }
        public string Creacion { get; set; }
        public string Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string FechaHoraInicio { get; set; }
        public string FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public float ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }


        public string ModalidadServicio { get { return _modalidadServicio; } }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Creacion = string.Empty;
            Termino = string.Empty;
            RutCliente = string.Empty;
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            FechaHoraInicio = string.Empty;
            FechaHoraTermino = string.Empty;
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado = false;
            ValorTotalContrato = 0f;
            Observaciones = string.Empty;
        }

        public bool Create()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();
            Datos.Contrato contrato = new Datos.Contrato();
            try
            {
                CommonBC.Syncronize(this, contrato);
                bbdd.Contrato.Add(contrato);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                bbdd.Contrato.Remove(contrato);
                return false;
            }
        }

        public bool Read()
        {
            Datos.OnBreakEntities bbdd = new Datos.OnBreakEntities();

            try
            {
                Datos.Contrato contrato = bbdd.Contrato.First(b => b.IdModalidad == IdModalidad);
                CommonBC.Syncronize(contrato, this);

                /* Carga descripción del Tipo */
                LeerModalidadServicio();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void LeerModalidadServicio()
        {
            ModalidadServicio modalidad = new ModalidadServicio() { IdModalidad = IdModalidad };

            if (modalidad.Read())
            {
                _modalidadServicio = modalidad.Nombre;
            }
            else
            {
                _modalidadServicio = string.Empty;
            }
        }
    }
}
