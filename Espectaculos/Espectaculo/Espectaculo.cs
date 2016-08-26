using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace Dominio
{
    [Serializable]
    public abstract class Espectaculo : ISerializable
    {
        #region variables
        private string nombre;
        private string tipo;
        private DateTime fecha;
        private int duracion;
        private TimeSpan hora;
        private Lugar lugar;
        private decimal precio;
        private string categoria;
        private string descripcion;
        private int entradasVendidas;
        private bool lleno;

        private int idEspec;
        private static int ultId;
        #endregion

        #region properties
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

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

        public int Duracion
        {
            get
            {
                return duracion;
            }

            set
            {
                duracion = value;
            }
        }

        public TimeSpan Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        internal Lugar Lugar
        {
            get
            {
                return lugar;
            }

            set
            {
                lugar = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public int EntradasVendidas
        {
            get
            {
                return entradasVendidas;
            }
            set
            {
                entradasVendidas = value;
            }
        }

        public bool Lleno
        {
            get
            {
                return lleno;
            }

            set
            {
                lleno = value;
            }
        }

        public int IdEspec
        {
            get
            {
                return this.idEspec;
            }
            set
            {
                this.idEspec = value;
            }
        }

        public static int UltId
        {
            get
            {
                return Espectaculo.ultId;
            }
            set
            {
                Espectaculo.ultId = value;
            }
        }


        #region properties gridview
        public string NombreLugar
        {
            get
            {
                return this.lugar.Nombre;
            }
        }

        public string DireccionLugar
        {
            get
            {
                return this.Lugar.Direccion;
            }
        }

        public string TelLugar
        {
            get
            {
                return this.Lugar.Tel.ToString();
            }
        }

        public string CapacidadLugar
        {
            get
            {
                return this.Lugar.CapMax.ToString();
            }
        }
        #endregion
        #endregion

        #region Contructor
        public Espectaculo() { }

        public Espectaculo(string pNombre, string pTipo, DateTime pFecha, int pDuracion,
            TimeSpan pHora, Lugar pLugar, decimal pPrecio, string pCategoria, string pDescripcion)
        {
            this.nombre = pNombre;
            this.tipo = pTipo;
            this.fecha = pFecha;
            this.duracion = pDuracion;
            this.hora = pHora;
            this.lugar = pLugar;
            this.precio = pPrecio;
            this.categoria = pCategoria;
            this.descripcion = pDescripcion;
            this.entradasVendidas = 0;
            this.lleno = false;

            this.idEspec = ultId + 1;
            ultId = this.idEspec;
        }
        #endregion

        public abstract decimal CalcularPrecio();

        #region serializacion
        //LO LLAMA EL SERIALIZADOR AL SERIALIZAR EL OBJETO
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.idEspec, typeof(int));
            info.AddValue("ultId", Espectaculo.ultId, typeof(int));

            info.AddValue("nombre", this.nombre, typeof(string));
            info.AddValue("tipo", this.tipo, typeof(string));
            info.AddValue("fecha", this.fecha, typeof(DateTime));
            info.AddValue("duracion", this.duracion, typeof(int));
            info.AddValue("hora", this.hora, typeof(TimeSpan));
            info.AddValue("lugar", this.lugar, typeof(Lugar));
            info.AddValue("precio", this.precio, typeof(decimal));
            info.AddValue("categoria", this.categoria, typeof(string));
            info.AddValue("descripcion", this.descripcion, typeof(string));
            info.AddValue("entradasVendidas", this.entradasVendidas, typeof(int));
            info.AddValue("lleno", this.lleno, typeof(bool));

        }

        //LO LLAMA EL SERIALIZADOR AL DESERIALIZAR EL OBJETO
        public Espectaculo(SerializationInfo info, StreamingContext context)
        {
            this.idEspec = (int)info.GetValue("id", typeof(int));
            Espectaculo.ultId = (int)info.GetValue("ultId", typeof(int));

            this.nombre = (string)info.GetValue("nombre", typeof(string));
            this.tipo = (string)info.GetValue("tipo", typeof(string));
            this.fecha = (DateTime)info.GetValue("fecha", typeof(DateTime));
            this.duracion = (int)info.GetValue("duracion", typeof(int));
            this.hora = (TimeSpan)info.GetValue("hora", typeof(TimeSpan));
            this.lugar = (Lugar)info.GetValue("lugar", typeof(Lugar));
            this.precio = (decimal)info.GetValue("precio", typeof(decimal));
            this.categoria = (string)info.GetValue("categoria", typeof(string));
            this.descripcion = (string)info.GetValue("descripcion", typeof(string));
            this.entradasVendidas = (int)info.GetValue("entradasVendidas", typeof(int));
            this.lleno = (bool)info.GetValue("lleno", typeof(bool));

        }
        #endregion
    } 
}
