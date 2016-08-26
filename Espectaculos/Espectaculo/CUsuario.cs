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
    public class CUsuario : ISerializable
    {
        private static CUsuario instanciaUsuario;
        private List<Usuario> usuarios = new List<Usuario>();

        #region properties
        public static CUsuario InstanciaUsuario
        {
            get
            {
                //Me fijo si no existe una instanciaEspectaculo, si no existe lo creo (unica)
                if (instanciaUsuario == null)
                {
                    instanciaUsuario = new CUsuario();
                }
                return instanciaUsuario;
            }
        }

        private CUsuario() { }
        #endregion

        #region Usuario
        #region metodos Usuario
        public bool AltaUsuario(string pCi, string pNombre, string pEmail, string pDir, int pTel, string pCont, bool pAdmin)
        {
            bool resultado = false;

            if (pCi != "" && pNombre != "" && pEmail != "" && pDir != "" && pTel != 0 && pCont != "")
            {
                if (BuscarUsuario(pCi) == null)
                {

                    if (Herramientas.esNumero(pTel.ToString()) && Herramientas.ochoCaracteres(pTel.ToString()) && Herramientas.ochoCaracteres(pCont))
                    {
                        Usuario usuarioAux = new Usuario(pCi, pNombre, pEmail, pDir, pTel, pCont, pAdmin);
                        usuarios.Add(usuarioAux);
                    }
                }
            }

            return resultado;
        }

        public bool esAdmin(string pCi)
        {
            bool esAdmin = false;
            Usuario usuarioAux = BuscarUsuario(pCi);
            if (usuarioAux.Admin)
            {
                esAdmin = true;
            }
            return esAdmin;
        }

        public List<Usuario> TotalCompras(int pAño)
        {
            List<Usuario> listaAux = new List<Usuario>();

            decimal total = 0;
            decimal maximo = 0;
            foreach (Usuario u in usuarios)
            {
                foreach (Reserva r in u.Reservas)
                {
                    //Si la reserva fue realizada este año
                    if (r.Paga && r.Fecha.Year == pAño)
                    {
                        total = total + r.Total;
                    }
                }
                if (total >= maximo)
                {
                    listaAux = new List<Usuario>();
                }
                if (total > maximo)
                {
                    listaAux.Add(u);
                }

            }
            return listaAux;
        }


        #endregion

        #region validaciones Usuario
        public Usuario BuscarUsuario(string pCi)
        {
            Usuario usuario = null;

            foreach (Usuario u in usuarios)
            {
                if (u.Ci.Equals(pCi))
                {
                    usuario = u;
                }
            }
            return usuario;
        }

        public bool ContraseñaValida(string pCi, string pContraseña)
        {
            bool resultado = false;

            if (!(string.IsNullOrEmpty(pCi) && string.IsNullOrEmpty(pContraseña)))
            {
                foreach (Usuario u in usuarios)
                {
                    if (u.Ci.Equals(pCi))
                    {
                        if (u.Contraseña.Equals(pContraseña))
                        {
                            resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }
        #endregion
        #endregion

        #region reserva 
        //public void CargaDatosReserva()
        //{
        //    //Reserva espectaculo Estandar
        //    Lugar lugar1 = new Dominio.Lugar("Teatro Solis", "Reconquista 256", 19503323, 1100);
        //    DateTime fechaEspec1 = new DateTime(2016, 08, 19);
        //    TimeSpan horaEspec1 = new TimeSpan(20, 00, 00);
        //    Estandar espec1 = new Estandar("Temporada Ópera: Don Pasquale", "Estandar", fechaEspec1, 120, horaEspec1, lugar1, 1500, "Opera", "Joya del belcanto italiano desnuda con mucho humor.", false);
        //    Usuario usuario1 = new Usuario("45504551", "Maria Fernandez", "maria@email.com", "Mercedes 562", 24012872, "mariafernandez", false);
        //    instanciaUsuario.AltaReserva(espec1, usuario1, 2, 3000);

        //    Lugar lugar2 = new Dominio.Lugar("Auditorio del Sodre", "Sarandí 450", 29007084, 1885);
        //    DateTime fechaEspec4 = new DateTime(2016, 08, 19);
        //    TimeSpan horaEspec4 = new TimeSpan(22, 30, 00);
        //    Estandar espec2 = new Estandar("Queyi - Canción azul que viaja", "Estandar", fechaEspec4, 60, horaEspec4, lugar2, 600, "Musical", "Un concierto íntimo para disfrutar del arte y la dulce voz de una gran artista.", true);
        //    Usuario usuario2 = new Usuario("39000821", "Juan Perez", "juan@email.com", "Ledesma 890", 24089072, "juanperez", false);
        //    instanciaUsuario.AltaReserva(espec2, usuario2, 5, 1300);

        //    //Reserva espectaculo VIP
        //    DateTime fechaEspec3 = new DateTime(2016, 09, 02);
        //    TimeSpan horaEspec3 = new TimeSpan(21, 00, 00);
        //    VIP espec3 = new VIP("Así se baila el tango", "VIP", fechaEspec3, 60, horaEspec3, lugar2, 350, "Danza", "Todo lo que usted quería saber sobre el baile del tango y no se atrevía a preguntar", 10);
        //    Usuario usuario3 = new Usuario("12548677", "Pedro Favalez", "pedro@email.com", "Scoseria 162", 27122821, "pedrofavalez", false);
        //    instanciaUsuario.AltaReserva(espec3, usuario3, 3, 1155);


        //}


        public bool AltaReserva(Espectaculo pEspectaculo, Usuario pUsuario, int pCant, decimal pTotal)
        {
            bool resultado = false;

            if (pEspectaculo != null && pCant > 0 && pTotal >= 0)
            {
                Reserva reserva = new Reserva(pEspectaculo, pUsuario, pCant, pTotal);
                //Doy de alta la reserva para el usuario

                pUsuario.Reservas.Add(reserva);
                resultado = true;
            }
            return resultado;
        }


        public List<Reserva> ReservasPendientesTodos()
        {
            List<Reserva> listAux = new List<Reserva>();

            foreach (Usuario u in usuarios)
            {
                foreach (Reserva r in u.Reservas)
                {
                    if (!r.Paga)
                        listAux.Add(r);
                }
            }
            return listAux;
        }

        public List<Reserva> ReservasPendientesPorUsuario(string pCi)
        {
            //Busco en la lista de usuarios por ci 
            Usuario u = BuscarUsuario(pCi);
            return u.ReservasPendientes();
        }

        public List<Reserva> ReservasPagasTodos()
        {
            List<Reserva> listAux = new List<Reserva>();

            foreach (Usuario u in usuarios)
            {
                foreach (Reserva r in u.Reservas)
                {
                    if (r.Paga)
                        listAux.Add(r);
                }
            }
            return listAux;
        }

        public Reserva BuscarReserva(int pId)
        {
            Reserva reservaAux = new Reserva();
            foreach (Usuario u in usuarios)
            {
                foreach (Reserva r in u.Reservas)
                {
                    if (r.IdReserva == pId)
                    {
                        reservaAux = r;
                    }
                }
            }
            return reservaAux;
        }

        public bool PagarReserva(Reserva pReserva)
        {
            bool pagoOk = false;

            if (pReserva != null)
            {
                pReserva.Paga = true;
                pagoOk = true;

            }
            return pagoOk;
        }
        #endregion
        
        #region serializable
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Usuarios", this.usuarios, typeof(List<Usuario>));
        }

        public CUsuario(SerializationInfo info, StreamingContext context)
        {
            this.usuarios = (List<Usuario>)info.GetValue("Usuarios", typeof(List<Usuario>));
            CUsuario.instanciaUsuario = this;
        }
        #endregion

    }
}
