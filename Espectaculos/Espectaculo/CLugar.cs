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
    public class CLugar : ISerializable
    {
        private static CLugar instanciaLugar;
        private List<Lugar> lugares = new List<Lugar>();

        #region properties
        public static CLugar InstanciaLugar
        {
            get
            {
                //Me fijo si no existe una instanciaEspectaculo, si no existe lo creo (unica)
                if (instanciaLugar == null)
                {
                    instanciaLugar = new CLugar();
                }
                return instanciaLugar;
            }
        }

        private CLugar() { }
        #endregion

        #region metodos
        public List<Lugar> LugaresExistentes()
        {
            List<Lugar> listaAux = new List<Lugar>();

            foreach (Lugar l in lugares)
            {
                listaAux.Add(l);
            }
            return listaAux;
        }

        public bool AltaLugar(string pNombre, string pDir, int pTel, int pCapMax)
        {
            bool retorno = false;
            //Verifico que sean valores validos
            if (!string.IsNullOrEmpty(pNombre) && !string.IsNullOrEmpty(pDir) && Herramientas.ochoCaracteres(pTel.ToString()) && pCapMax > 0)
            {
                //Verifico que no exista otro lugar con el mismo nombre y direccion
                if (!ExisteLugar(pNombre, pDir))
                {
                    Lugar lugarAux = new Lugar(pNombre, pDir, pTel, pCapMax);
                    lugares.Add(lugarAux);
                }
            }
            return retorno;
        }
        #endregion

        #region validaciones
        public bool ExisteLugar(string pNombre, string pDir)
        {
            bool resultado = false;

            foreach (Lugar l in lugares)
            {
                if (l != null)
                {
                    if (l.Nombre.Equals(pNombre))
                    {
                        if (l.Direccion.Equals(pDir))
                        {
                            resultado = true;
                        }
                    }
                }
            }
            return resultado;
        }

        public Lugar BuscarLugar(string pNombre)
        {
            Lugar lugarAux = new Lugar();

            foreach (Lugar l in lugares)
            {
                if (l.Nombre.Equals(pNombre))
                {
                    lugarAux = l;
                }
            }
            return lugarAux;
        }
        #endregion

        #region serializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Lugares", this.lugares, typeof(List<Lugar>));
        }

        public CLugar(SerializationInfo info, StreamingContext context)
        {
            this.lugares = (List<Lugar>)info.GetValue("Lugares", typeof(List<Lugar>));
            CLugar.instanciaLugar = this;
        }
        #endregion
    }
}
