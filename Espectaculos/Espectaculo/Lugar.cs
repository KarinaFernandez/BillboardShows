using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Serializable]
    public class Lugar
    {
        #region variables
        private string nombre;
        private string direccion;
        private int tel;
        private int capMax;
        #endregion

        #region properties
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

        public int CapMax
        {
            get
            {
                return capMax;
            }

            set
            {
                capMax = value;
            }
        }
        #endregion

        #region constructor
        public Lugar() { }

        public Lugar(string pNombre, string pDireccion, int pTel, int pCapMax)
        {
            this.nombre = pNombre;
            this.direccion = pDireccion;
            this.tel = pTel;
            this.capMax = pCapMax;
        }
        #endregion
    }
}
