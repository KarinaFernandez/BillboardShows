using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Utilidades;

namespace Dominio
{
    [Serializable]
    public class CEspectaculo : ISerializable
    {
        private static CEspectaculo instanciaEspectaculo;
        private List<Espectaculo> espectaculos = new List<Espectaculo>();


        #region properties
        private CEspectaculo() { }
        public static CEspectaculo InstanciaEspectaculo
        {
            get
            {
                //Me fijo si no existe una instanciaEspectaculo, si no existe lo creo (unica)
                if (instanciaEspectaculo == null)
                {
                    instanciaEspectaculo = new CEspectaculo();
                }
                return instanciaEspectaculo;
            }
        }
        #endregion

        #region metodos
        
        public string AltaEstandar(string pNombre, string pTipo, DateTime pFecha, int pDuracion, TimeSpan pHora, Lugar pLugar,
             decimal pPrecio, string pCategoria, string pDescripcion, bool pImpreso)
        {
            string mensaje = "";

            //Valido todos los campos
            if (!string.IsNullOrEmpty(pNombre) && !string.IsNullOrEmpty(pTipo) && pFecha != null && pDuracion > 5 && pHora != null && pLugar != null &&
                pPrecio >= 0 && !string.IsNullOrEmpty(pCategoria) && !string.IsNullOrEmpty(pDescripcion))
            {
                //Valido que tipo de espectaculo ingresado
                if (instanciaEspectaculo.TipoEspectaculoValido(pTipo))
                {
                    //Si no existe otro Espectaculo con el mismo nombre
                    if (!instanciaEspectaculo.ExisteEspectaculo(pNombre))
                    {
                        //Validar que no haya otro espectaculo en ese horario. Si esta disponible para ese lugar, dia y hora
                        if (instanciaEspectaculo.DiaYHoraDisponible(pLugar, pFecha, pDuracion, pHora))
                        {
                            Estandar estandar = new Estandar(pNombre, pTipo, pFecha, pDuracion, pHora, pLugar, pPrecio, pCategoria, pDescripcion, pImpreso);
                            instanciaEspectaculo.espectaculos.Add(estandar);
                            mensaje = "Alta exitosa!";
                        }
                        else
                        {
                            mensaje = "El lugar no se encuentra disponible a ese dia y hora";
                        }
                    }
                    else
                    {
                        mensaje = "Ya existe otro espectaculo con ese nombre";
                    }
                }
                else
                {
                    mensaje = "Tipo de espectaculo invalido";
                }

            }
            else
            {
                mensaje = "Datos invalidos";
            }
            return mensaje;
        }


        public string AltaVip(string pNombre, string pTipo, DateTime pFecha, int pDuracion, TimeSpan pHora, Lugar pLugar, decimal pPrecio,
            string pCategoria, string pDescripcion, decimal pRecargo)
        {
            string mensaje = "";

            //Valido todos los campos
            if (!string.IsNullOrEmpty(pNombre) && !string.IsNullOrEmpty(pTipo) && pFecha != null && pDuracion > 5 && pHora != null && pLugar != null &&
                pPrecio >= 0 && !string.IsNullOrEmpty(pCategoria) && !string.IsNullOrEmpty(pDescripcion) && pRecargo >= 0)
            {
                //Valido que el tipo de espectaculo sea valido
                if (instanciaEspectaculo.TipoEspectaculoValido(pTipo))
                {
                    //Si no existe otro Espectaculo con el mismo nombre
                    if (!instanciaEspectaculo.ExisteEspectaculo(pNombre))
                    {
                        //Validar que no haya otro espectaculo en ese horario
                        if (instanciaEspectaculo.DiaYHoraDisponible(pLugar, pFecha, pDuracion, pHora))
                        {
                            VIP vip = new VIP(pNombre, pTipo, pFecha, pDuracion, pHora, pLugar, pPrecio, pCategoria, pDescripcion, pRecargo);
                            instanciaEspectaculo.espectaculos.Add(vip);
                            mensaje = "Alta exitosa!";
                        }
                        else
                        {
                            mensaje = "El lugar no se encuentra disponible a ese dia y hora";
                        }
                    }
                    else
                    {
                        mensaje = "Ya existe otro espectaculo con ese nombre";
                    }
                }
                else
                {
                    mensaje = "Tipo de espectaculo invalido";
                }
            }
            else
            {
                mensaje = "Datos invalidos";
            }
            return mensaje;
        }
        #endregion

        #region validaciones
        public bool ExisteEspectaculo(string pNombre)
        {
            bool resultado = false;

            foreach (Espectaculo e in espectaculos)
            {
                if (e.Nombre.Equals(pNombre))
                {
                    resultado = true;
                }
            }
            return resultado;
        }


        public Espectaculo BuscarEspectaculo(string pNombre)
        {
            Espectaculo espect = null;

            foreach (Espectaculo e in instanciaEspectaculo.espectaculos)
            {
                if (e.Nombre.Equals(pNombre))
                {
                    espect = e;
                }
            }
            return espect;
        }

        public Espectaculo BuscarEspectaculoPorID(int pId)
        {
            Espectaculo espect = null;

            foreach (Espectaculo e in instanciaEspectaculo.espectaculos)
            {
                if (e.IdEspec == pId)
                {
                    espect = e;
                }
            }
            return espect;
        }


        public bool DiaYHoraDisponible(Lugar pLugar, DateTime pFecha, int pDuracion, TimeSpan pHora)
        {
            bool resultado = true;
            //Verifico si para ese dia existe algun espectaculo en ese lugar
            foreach (Espectaculo e in espectaculos)
            {
                if (e != null)
                {
                    //Si en el mismo lugar existe un espectaculo ese mismo dia
                    if (e.Lugar.Equals(pLugar))
                    {
                        if (DateTime.Compare(e.Fecha, pFecha) == 0)
                        {
                            //Hora final del espectaculo existente 
                            TimeSpan horaFinalizacion = e.Hora.Add(TimeSpan.FromMinutes(pDuracion));
                            //Si el espectaculo a insertar empieza antes de que finalice el espectaculo que ya existe, el lugar no se encuentra disponible
                            if (pHora < horaFinalizacion)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return resultado;
        }


        public int EntradasDisponibles(Espectaculo pEspec)
        {
            int cantidad = 0;
            if (pEspec != null)
            {
                cantidad = pEspec.Lugar.CapMax - pEspec.EntradasVendidas;
            }
            return cantidad;
        }

        public bool CantidadDisponible(Espectaculo pEspectaculo, int pCant)
        {
            bool disponible = false;

            if (EntradasDisponibles(pEspectaculo) >= pCant)
            {
                disponible = true;

            }
            return disponible;
        }


        public void BajaEntradas(Espectaculo pEspectaculo, int pCant)
        {
            int cantVendidasActual = pEspectaculo.EntradasVendidas + pCant;
            pEspectaculo.EntradasVendidas = cantVendidasActual;
            if (cantVendidasActual == pEspectaculo.Lugar.CapMax)
            {
                pEspectaculo.Lleno = true;
            }
        }

        public bool TipoEspectaculoValido(string pTipo)
        {
            bool ok = false;
            if (!string.IsNullOrEmpty(pTipo))
            {
                if (pTipo.Equals("Estandar") || pTipo.Equals("VIP"))
                {
                    ok = true;
                }
            }
            return ok;
        }



        public List<Espectaculo> EspectaculosFiltrados(DateTime pFechaDesde, DateTime pFechaHasta, string pTipoEspec, decimal pPrecioDesde, decimal pPrecioHasta)
        {
            List<Espectaculo> listaAux = new List<Espectaculo>();

            if (pFechaDesde != null && pFechaHasta != null)
            {
                foreach (Espectaculo e in espectaculos)
                {
                    //Rango de fecha incluye los limites
                    if (e.Fecha >= pFechaDesde && e.Fecha <= pFechaHasta)
                    {

                        //Si el rango es de 0 a 0, le seteo desde 0 hasta el maximo, ya que quiero todos los espectaculos con todos los precios
                        if (pPrecioDesde == 0 && pPrecioHasta == 0)
                        {
                            pPrecioHasta = int.MaxValue;
                        }
                        //Rango de precio incluye los limites
                        if (e.Precio >= pPrecioDesde && e.Precio <= pPrecioHasta)
                        {
                            if (e.Tipo.Equals(pTipoEspec))
                            {
                                listaAux.Add(e);
                            }
                            else if (string.IsNullOrEmpty(pTipoEspec))
                            {
                                listaAux.Add(e);
                            }
                        }

                    }
                }
            }

            return listaAux;
        }

        public decimal TotalAPagar(Espectaculo pEspec, int pCant)
        {
            decimal total = 0;

            decimal cant = (decimal)pCant;

            total = pEspec.CalcularPrecio() * cant;

            return total;
        }

        public List<Espectaculo> EspectaculosLlenos()
        {
            List<Espectaculo> listaEspecLlenos = new List<Espectaculo>();
            foreach (Espectaculo e in espectaculos)
            {
                if (e.Lleno)
                {
                    listaEspecLlenos.Add(e);
                }
            }
            return listaEspecLlenos;
        }
        #endregion

        #region serializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Espectaculos", this.espectaculos, typeof(List<Espectaculo>));
        }

        public CEspectaculo(SerializationInfo info, StreamingContext context)
        {
            this.espectaculos = (List<Espectaculo>)info.GetValue("Espectaculos", typeof(List<Espectaculo>));
            CEspectaculo.instanciaEspectaculo = this;
        }
        #endregion
    }
}
