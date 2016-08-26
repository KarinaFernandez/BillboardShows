using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Dominio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lbUsuario.Text = "";
            lbConstraseña.Text = "";
            lbMensaje.Text = "";
        }

        protected void btIngresar_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string contraseña = tbContraseña.Text;


            if (!(string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contraseña)))
            {
                Usuario usuarioAux = Controladora.Fachada.BuscarUsuario(usuario);
                if (usuarioAux != null)
                {

                    if (Controladora.Fachada.ContraseñaValida(usuario, contraseña))
                    {
                        base.Session["usuario"] = usuarioAux;

                        lbMensaje.Text = "Bienvenido: " + usuario;
                    }
                    else
                    {
                        lbConstraseña.Text = "La contraseña no es valida";
                    }
                }
                else
                {
                    lbUsuario.Text = "No se encontró la CI ingresada";
                }
            }
            else
            {
                lbUsuario.Text = "Debe ingresar su CI";
                lbConstraseña.Text = "Debe ingresar su contraseña";
            }
        }

        protected void btCargarPantalla_Click(object sender, EventArgs e)
        {
            tbUsuario.Text = "45504551";
            tbContraseña.Text = "mariafernandez";
        }

        protected void btCargarAdmin_Click(object sender, EventArgs e)
        {
            tbUsuario.Text = "12345678";
            tbContraseña.Text = "pedrovarela";
        }
    }
}