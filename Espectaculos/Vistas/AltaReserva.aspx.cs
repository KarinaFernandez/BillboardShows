using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Utilidades;
using Dominio;

namespace Vistas
{
    public partial class AltaReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuAux = (Usuario)Session["usuario"];

            if (usuAux == null)
            {
                Response.Redirect("Login.aspx");

            }

            //Obtengo el espectaculo seleccionado desde Cartelera
            Espectaculo especSel = (Espectaculo)Session["especSeleccionado"];
            if (especSel == null)
            {
                Response.Redirect("Cartelera.aspx");
            }
            else
            {
                tbEspectaculo.Text = especSel.Nombre;
            }

        }

        protected void btReserva_Click(object sender, EventArgs e)
        {

            Espectaculo especSel = (Espectaculo)Session["especSeleccionado"];

            Usuario usuAux = (Usuario)Session["usuario"];

            string cantidad = tbCantEntradas.Text;


            //Si los datos no son nulos
            if (especSel != null && usuAux != null && !string.IsNullOrEmpty(cantidad))
            {
                if (Herramientas.esNumero(cantidad))
                {
                    //Verifico que la cantidad sea mayor a 0
                    int cant = int.Parse(cantidad);
                    if (cant > 0)
                    {
                        
                        //Si hay lugares disponibles
                        if (Controladora.Fachada.CantidadDisponible(especSel, cant))
                        {
                            lblCantEntradas.Text = "";
                            lblMensaje.Text = "";
                            //Si se da de alta correctamente
                            if (Controladora.Fachada.AltaReserva(especSel, usuAux, cant))
                            {
                                lblMensaje.Text = "Reserva exitosa";

                            }
                            //Si no se pudo dar de alta 
                            else
                            {
                                lblMensaje.Text = "";
                                lblMensaje.Text = "La reserva no se pudo realizar verifique los datos";
                            }
                        }
                        //Si no hay tantos lugares disponibles como los ingresados
                        else
                        {
                            lblMensaje.Text = "";
                            lblCantEntradas.Text = "No se encuentra disponible esa cantidad";
                        }
                    }
                    else
                    {
                        
                        lblCantEntradas.Text = "Ingreso cantidad 0";
                    }

                }
                
            }
        }
    }
}