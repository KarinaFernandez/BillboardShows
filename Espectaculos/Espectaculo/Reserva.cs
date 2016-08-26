using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class Reserva : ISerializable
    {
        #region variables
        private int idReserva;
        private static int ultId;
        private Espectaculo espectaculo;
        private DateTime fecha;
        private int cantidad;
        private decimal total;
        private bool paga;
        private Usuario usuario;
        #endregion

        #region properties
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public bool Paga
        {
            get
            {
                return paga;
            }

            set
            {
                paga = value;
            }
        }


        public Espectaculo Espectaculo
        {
            get
            {
                return espectaculo;
            }

            set
            {
                espectaculo = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public int IdReserva
        {
            get
            {
                return idReserva;
            }

            set
            {
                idReserva = value;
            }
        }

        #region properties gridview
        public string UsuarioNombre
        {
            get
            {
                return usuario.Nombre;
            }
        }
        public string UsuarioEmail
        {
            get
            {
                return usuario.Email;
            }
        }
        public int UsuarioTel
        {
            get
            {
                return usuario.Tel;
            }
        }
        public string EspectaculoNombre
        {
            get
            {
                return espectaculo.Nombre;
            }
        }
        #endregion
        #endregion

        #region constructores
        public Reserva() { }


        //Reserva paga
        public Reserva(Espectaculo pEspec, Usuario pUsuario, int pCant, decimal pTotal, bool pPaga)
        {
            this.IdReserva = ultId + 1;
            ultId = this.IdReserva;

            this.espectaculo = pEspec;
            this.usuario = pUsuario;
            this.fecha = DateTime.Now;
            this.cantidad = pCant;
            this.total = pTotal;
            this.paga = pPaga;
        }

        public Reserva(Espectaculo pEspec, Usuario pUsuario, int pCant, decimal pTotal)
        {
            this.IdReserva = ultId + 1;
            ultId = this.IdReserva;

            this.espectaculo = pEspec;
            this.usuario = pUsuario;
            this.fecha = DateTime.Now;
            this.cantidad = pCant;
            this.total = pTotal;
        }
        #endregion

        #region serializacion
        //LO LLAMA EL SERIALIZADOR AL SERIALIZAR EL OBJETO
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.idReserva, typeof(int));
            info.AddValue("ultId", Reserva.ultId, typeof(int));

            info.AddValue("espectaculo", this.espectaculo, typeof(Espectaculo));
            info.AddValue("fecha", this.fecha, typeof(DateTime));
            info.AddValue("cantidad", this.cantidad, typeof(int));
            info.AddValue("total", this.total, typeof(decimal));
            info.AddValue("paga", this.paga, typeof(bool));
            info.AddValue("usuario", this.usuario, typeof(Usuario));
        }

        //LO LLAMA EL SERIALIZADOR AL DESERIALIZAR EL OBJETO
        public Reserva(SerializationInfo info, StreamingContext context)
        {
            this.idReserva = (int)info.GetValue("id", typeof(int));
            Reserva.ultId = (int)info.GetValue("ultId", typeof(int));

            this.espectaculo = (Espectaculo)info.GetValue("espectaculo", typeof(Espectaculo));
            this.fecha = (DateTime)info.GetValue("fecha", typeof(DateTime));
            this.cantidad = (int)info.GetValue("cantidad", typeof(int));
            this.total = (decimal)info.GetValue("total", typeof(decimal));
            this.paga = (bool)info.GetValue("paga", typeof(bool));
            this.usuario = (Usuario)info.GetValue("usuario", typeof(Usuario));

        }
        #endregion
    }
}

