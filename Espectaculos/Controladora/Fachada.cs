using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Controladora
{
    public class Fachada
    {

        #region Espectaculo
        public static string AltaEstandar(string pNombre, string pTipo, DateTime pFecha, int pDuracion, TimeSpan pHora, Lugar pLugar,
           decimal pPrecio, string pCategoria, string pDescripcion, bool pImpreso)
        {
            return CEspectaculo.InstanciaEspectaculo.AltaEstandar(pNombre, pTipo, pFecha, pDuracion, pHora, pLugar, pPrecio, pCategoria, pDescripcion, pImpreso);
        }

        public static string AltaVip(string pNombre, string pTipo, DateTime pFecha, int pDuracion, TimeSpan pHora, Lugar pLugar,
            decimal pPrecio, string pCategoria, string pDescripcion, decimal pRecargo)
        {
            return CEspectaculo.InstanciaEspectaculo.AltaVip(pNombre, pTipo, pFecha, pDuracion, pHora, pLugar, pPrecio, pCategoria, pDescripcion, pRecargo);
        }

        public static List<Espectaculo> EspectaculosFiltrados(DateTime pFechaDesde, DateTime pFechaHasta, string pTipoEspec, decimal pPrecioDesde, decimal pPrecioHasta)
        {
            return CEspectaculo.InstanciaEspectaculo.EspectaculosFiltrados(pFechaDesde, pFechaHasta, pTipoEspec, pPrecioDesde, pPrecioHasta);
        }

        public static Espectaculo BuscarEspectaculo(string pNombre)
        {
            return CEspectaculo.InstanciaEspectaculo.BuscarEspectaculo(pNombre);
        }

        public static Espectaculo BuscarEspectaculoPorID(int pId)
        {
            return CEspectaculo.InstanciaEspectaculo.BuscarEspectaculoPorID(pId);
        }

        public static bool CantidadDisponible(Espectaculo pEspectaculo, int pCant)
        {
            return CEspectaculo.InstanciaEspectaculo.CantidadDisponible(pEspectaculo, pCant);
        }

        public static List<Espectaculo> EspectaculosLlenos()
        {
            return CEspectaculo.InstanciaEspectaculo.EspectaculosLlenos();
        }

        public static decimal TotalAPagar(Espectaculo pEspec, int pCant)
        {
            return CEspectaculo.InstanciaEspectaculo.TotalAPagar(pEspec, pCant);
        }

        #endregion

        #region Reserva
        public static bool AltaReserva(Espectaculo pEspectaculo, Usuario pUsuario, int pCant)
        {
            bool retorno = false;

            //Calculo lo que tiene que pagar segun la cantidad de entradas seleccionadas y espectaculo
            decimal pTotal = CEspectaculo.InstanciaEspectaculo.TotalAPagar(pEspectaculo, pCant);

            //Doy de alta la reserva 
            retorno = CUsuario.InstanciaUsuario.AltaReserva(pEspectaculo, pUsuario, pCant, pTotal);
            //Bajo la cantidad de entradas disponibles para el espectaculo
            if (retorno)
            {
                CEspectaculo.InstanciaEspectaculo.BajaEntradas(pEspectaculo, pCant);
            }

            return retorno;
        }

        public static Reserva BuscarReserva(int idRes)
        {
            return CUsuario.InstanciaUsuario.BuscarReserva(idRes);

        }
        public static List<Reserva> ReservasPendientesTodos()
        {
            return CUsuario.InstanciaUsuario.ReservasPendientesTodos();
        }

        public static bool PagarReserva(Reserva pReserva)
        {
            return CUsuario.InstanciaUsuario.PagarReserva(pReserva);
        }

        public static List<Usuario> TotalCompras()
        {
            return CUsuario.InstanciaUsuario.TotalCompras(DateTime.Now.Year);
        }
        #endregion

        #region Usuario
        public static bool AltaUsuario(string pCi, string pNombre, string pEmail, string pDir, int pTel, string pCont, bool pAdmin)
        {
            return CUsuario.InstanciaUsuario.AltaUsuario(pCi, pNombre, pEmail, pDir, pTel, pCont, pAdmin);
        }

        public static Usuario BuscarUsuario(string pCi)
        {
            return CUsuario.InstanciaUsuario.BuscarUsuario(pCi);
        }

        public static bool ContraseñaValida(string pCi, string pContraseña)
        {
            return CUsuario.InstanciaUsuario.ContraseñaValida(pCi, pContraseña);
        }

        public static bool esAdmin(string pCi)
        {
            return CUsuario.InstanciaUsuario.esAdmin(pCi);
        }
        #endregion

        #region Lugares
        public static bool AltaLugar(string pNombre, string pDir, int pTel, int pCapMax)
        {
            return CLugar.InstanciaLugar.AltaLugar(pNombre, pDir, pTel, pCapMax);
        }

        public static List<Lugar> LugaresExistentes()
        {
            return CLugar.InstanciaLugar.LugaresExistentes();
        }

        public static Lugar BuscarLugar(string pNombre)
        {
            return CLugar.InstanciaLugar.BuscarLugar(pNombre);
        }
        #endregion
    }
}