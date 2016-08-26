using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Dominio;
using Controladora;
using System.IO;
using System.Runtime;

namespace Vistas
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            if (!File.Exists(HttpRuntime.AppDomainAppPath + @"Datos\datos.bin"))
            {
                this.CargaDatosPrueba();
            }
            else
            {
                Repositorio r = new Repositorio(HttpRuntime.AppDomainAppPath + @"Datos\datos.bin");

                try
                {
                    r.Deserializar();
                }
                catch
                {
                    throw;
                }
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Repositorio r = new Repositorio(HttpRuntime.AppDomainAppPath + @"Datos\datos.bin");
            r.Serializar();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            string ruta = HttpRuntime.AppDomainAppPath + @"Errores\log.txt";
            StreamWriter sw = new StreamWriter(ruta, true);

            sw.WriteLine("=====================");
            sw.WriteLine(DateTime.Now.ToShortDateString() + "|" +
                DateTime.Now.ToShortTimeString() + " - " +
                ex.InnerException.Message);

            sw.Close();
            Response.Redirect("Errores.aspx?error=" + ex.InnerException.Message);
        }

        private void CargaDatosPrueba()
        {
            #region Alta Espectaculo
            //Espectaculos Estandar
            Lugar lugar1 = new Lugar("Teatro Solis", "Reconquista 256", 19503323, 1100);
            DateTime fechaEspec1 = new DateTime(2016, 08, 19);
            TimeSpan horaEspec1 = new TimeSpan(20, 00, 00);
            Fachada.AltaEstandar("Temporada Ópera: Don Pasquale", "Estandar", fechaEspec1, 120, horaEspec1, lugar1, 1500, "Teatro", "Joya del belcanto italiano desnuda con mucho humor.", false);

            DateTime fechaEspec2 = new DateTime(2016, 08, 19);
            TimeSpan horaEspec2 = new TimeSpan(22, 30, 00);
            Fachada.AltaEstandar("Queyi - Canción azul que viaja", "Estandar", fechaEspec2, 60, horaEspec2, lugar1, 600, "Concierto", "Un concierto íntimo para disfrutar del arte y la dulce voz de una gran artista.", true);

            Lugar lugar2 = new Lugar("Auditorio del Sodre", "Sarandí 450", 29007084, 1885);
            DateTime fechaEspec4 = new DateTime(2016, 08, 25);
            TimeSpan horaEspec4 = new TimeSpan(22, 30, 00);
            Fachada.AltaEstandar("Queyi - Canción azul que viaja", "Estandar", fechaEspec4, 60, horaEspec4, lugar2, 600, "Concierto", "Un concierto íntimo para disfrutar del arte y la dulce voz de una gran artista.", true);

            Lugar lugar6 = new Lugar("Movie Center", "Punta Carretas Shopping", 29003900, 5000);
            DateTime fechaEspec5 = new DateTime(2016, 08, 31);
            TimeSpan horaEspec5 = new TimeSpan(21, 30, 00);
            Fachada.AltaEstandar("El hilo rojo", "Estandar", fechaEspec4, 45, horaEspec4, lugar6, 290, "Cine", "Una leyenda china cuenta que un hilo rojo invisible conecta a aquellos que están destinados a encontrarse.", false);

            //Espectaculos VIP
            DateTime fechaEspec3 = new DateTime(2016, 09, 02);
            TimeSpan horaEspec3 = new TimeSpan(21, 00, 00);
            Fachada.AltaVip("Así se baila el tango", "VIP", fechaEspec3, 60, horaEspec3, lugar2, 350, "Teatro", "Todo lo que usted quería saber sobre el baile del tango y no se atrevía a preguntar", 10);
            #endregion

            #region Alta Lugar
            Fachada.AltaLugar("Teatro Solis", "Reconquista 256", 19503323, 1100);
            Fachada.AltaLugar("Auditorio del Sodre", "Sarandí 450", 29007084, 1885);
            Fachada.AltaLugar("La Trastienda", "Fernández Crespo 1763", 24026929, 780);
            Fachada.AltaLugar("Teatro El Galpón", "Av. 18 de Julio 1618", 24083366, 800);
            Fachada.AltaLugar("Teatro Metro", "San José 1211", 29022017, 1000);
            Fachada.AltaLugar("Movie Center", "Punta Carretas Shopping", 29003900, 5000);
            #endregion

            #region Alta Usuario
            //Administradores
            Fachada.AltaUsuario("12345678", "Pedro Varela", "pedro@email.com", "18 de Julio 123", 24002277, "pedrovarela", true);
            Fachada.AltaUsuario("23004551", "Juana de America", "juana@email.com", "Colonia 432", 24032547, "juanadeamerica", true);
            Fachada.AltaUsuario("35005892", "Pablo Gonzalez", "pablo@email.com", "Cuareim", 24022512, "pablogonzalez", true);
            Fachada.AltaUsuario("09454551", "Pepe Mujica", "pepe@email.com", "Vazquez 968", 22002547, "pepemujica", true);
            Fachada.AltaUsuario("42305797", "Peter Griffin", "peter@email.com", "Melo 432", 24092547, "petergriffin", true);

            //Clientes
            Fachada.AltaUsuario("45504551", "Maria Fernandez", "maria@email.com", "Mercedes 562", 24012872, "mariafernandez", false);
            Fachada.AltaUsuario("39000821", "Juan Perez", "juan@email.com", "Ledesma 890", 24089072, "juanperez", false);
            Fachada.AltaUsuario("12548677", "Pedro Favalez", "pedro@email.com", "Scoseria 162", 27122821, "pedrofavalez", false);
            Fachada.AltaUsuario("31995202", "Shora Segui", "shora@email.com", "Gaviotas 869", 22582872, "shorasegui", false);
            Fachada.AltaUsuario("44315489", "Iñaki Berterreche", "iñaki@email.com", "Gutierrez 512", 24022577, "inakiberterreche", false);
        #endregion
            
    }
    }
}