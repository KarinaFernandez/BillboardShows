using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dominio
{
    [Serializable]
    public class VIP : Espectaculo, ISerializable
    {
        private decimal recargo;

        #region properties
        public decimal Recargo
        {
            get
            {
                return recargo;
            }

            set
            {
                this.recargo = value;
            }
        }
        #endregion

        #region constructor
        public VIP() { }

        public VIP(string pNombre, string pTipo, DateTime pFecha, int pDuracion,
            TimeSpan pHora, Lugar pLugar, decimal pPrecio, string pCategoria, string pDescripcion, decimal pRecargo)
        : base(pNombre, pTipo, pFecha, pDuracion, pHora, pLugar, pPrecio, pCategoria, pDescripcion)
        {

            this.Nombre = pNombre;
            this.Tipo = pTipo;
            this.Fecha = pFecha;
            this.Duracion = pDuracion;
            this.Hora = pHora;
            this.Lugar = pLugar;
            this.Precio = pPrecio;
            this.Categoria = pCategoria;
            this.Descripcion = pDescripcion;

            this.recargo = pRecargo;
        }
        #endregion

        public override decimal CalcularPrecio()
        {
            decimal costo = 0;
            //al precio base se le adiciona un porcentaje de recargo, que es particular para cada espectáculo
            decimal resultadoPorcentaje = (this.Precio * recargo) / 100;
            costo = this.Precio + resultadoPorcentaje;
            return costo;
        }

        #region serializacion
        //LO LLAMA EL SERIALIZADOR AL SERIALIZAR EL OBJETO
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", this.IdEspec, typeof(int));
            info.AddValue("ultId", Espectaculo.UltId, typeof(int));

            info.AddValue("nombre", this.Nombre, typeof(string));
            info.AddValue("tipo", this.Tipo, typeof(string));
            info.AddValue("fecha", this.Fecha, typeof(DateTime));
            info.AddValue("duracion", this.Duracion, typeof(int));
            info.AddValue("hora", this.Hora, typeof(TimeSpan));
            info.AddValue("lugar", this.Lugar, typeof(Lugar));
            info.AddValue("precio", this.Precio, typeof(decimal));
            info.AddValue("categoria", this.Categoria, typeof(string));
            info.AddValue("descripcion", this.Descripcion, typeof(string));
            info.AddValue("entradasVendidas", this.EntradasVendidas, typeof(int));
            info.AddValue("lleno", this.Lleno, typeof(bool));

            info.AddValue("recargo", this.recargo, typeof(decimal));
        }

        //LO LLAMA EL SERIALIZADOR AL DESERIALIZAR EL OBJETO
        public VIP(SerializationInfo info, StreamingContext context)
        {
            this.IdEspec = (int)info.GetValue("id", typeof(int));
            Espectaculo.UltId = (int)info.GetValue("ultId", typeof(int));

            this.Nombre = (string)info.GetValue("nombre", typeof(string));
            this.Tipo = (string)info.GetValue("tipo", typeof(string));
            this.Fecha = (DateTime)info.GetValue("fecha", typeof(DateTime));
            this.Duracion = (int)info.GetValue("duracion", typeof(int));
            this.Hora = (TimeSpan)info.GetValue("hora", typeof(TimeSpan));
            this.Lugar = (Lugar)info.GetValue("lugar", typeof(Lugar));
            this.Precio = (decimal)info.GetValue("precio", typeof(decimal));
            this.Categoria = (string)info.GetValue("categoria", typeof(string));
            this.Descripcion = (string)info.GetValue("descripcion", typeof(string));
            this.EntradasVendidas = (int)info.GetValue("entradasVendidas", typeof(int));
            this.Lleno = (bool)info.GetValue("lleno", typeof(bool));

            this.recargo = (decimal)info.GetValue("recargo", typeof(decimal));
        }
        #endregion
    }
}
