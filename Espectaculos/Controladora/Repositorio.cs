using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Controladora
{
    [Serializable]
    public class Repositorio
    {
        private CEspectaculo cEspectaculo;
        private CLugar cLugar;
        private CUsuario cUsuario;
        private string rutaArchivoBinario;

        public Repositorio() { }

        public Repositorio(string pRuta)
        {
            this.rutaArchivoBinario = pRuta;
            this.cEspectaculo = CEspectaculo.InstanciaEspectaculo;
            this.cLugar = CLugar.InstanciaLugar;
            this.cUsuario = CUsuario.InstanciaUsuario;
        }

        public void Serializar()
        {
            
            FileStream fs = new FileStream(this.rutaArchivoBinario, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Deserializar()
        {
            FileStream fs = new FileStream(rutaArchivoBinario, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            Repositorio rep = bf.Deserialize(fs) as Repositorio;
            fs.Close();            
        }
    
    }
}