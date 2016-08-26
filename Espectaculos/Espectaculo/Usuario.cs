using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Usuario
    {
        #region variables
        private string ci;
        private string nombre;
        private string email;
        private string direccion;
        private int tel;
        private string contraseña;
        private bool admin;
        private List<Reserva> reservas;
        #endregion

        #region properties
        public string Ci
        {
            get
            {
                return ci;
            }

            set
            {
                ci = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public int Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }

        public bool Admin
        {
            get
            {
                return admin;
            }

            set
            {
                admin = value;
            }
        }

        public List<Reserva> Reservas
        {
            get
            {
                return reservas;
            }

            set
            {
                reservas = value;
            }
        }

        #region properties GridView

        #endregion

        #endregion

        #region constructor
        public Usuario() { }

        public Usuario(string pCi, string pNombre, string pEmail, string pDir, int pTel, string pCont, bool pAdmin)
        {
            this.ci = pCi;
            this.nombre = pNombre;
            this.email = pEmail;
            this.direccion = pDir;
            this.tel = pTel;
            this.contraseña = pCont;
            this.admin = pAdmin;
            this.reservas = new List<Reserva>();
        }
        #endregion

        #region metodos
        public List<Reserva> ReservasPendientes()
        {
            List<Reserva> reservasPend = new List<Reserva>();
            foreach (Reserva r in reservas)
            {
                //Si aun no fue paga
                if (!r.Paga)
                {
                    reservasPend.Add(r);
                }
            }
            return reservasPend;
        }

        public bool PagarReserva(Reserva pReserva)
        {
            bool pagoOk = false;
            pReserva.Paga = true;
            pagoOk = true;
            return pagoOk;
        }
        #endregion

    }
}
