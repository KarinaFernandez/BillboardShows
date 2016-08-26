using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controladora;
using Dominio;
using Utilidades;

namespace Vistas
{
    public partial class ReservasPendientes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuAux = (Usuario)Session["usuario"];

            if (usuAux == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!usuAux.Admin)
            {
                Response.Redirect("Login.aspx");
            }

        }
         

        protected void btReservasPend_Click(object sender, EventArgs e)
        {
            List<Reserva> reservasPendientes = Fachada.ReservasPendientesTodos();
            if (reservasPendientes.Count > 0)
            {
                GridViewReservasPend.Visible = true;
                GridViewReservasPend.DataSource = reservasPendientes;
                GridViewReservasPend.DataBind();
            }
            else
            {
                lblMensajeReservas.Text = "No se encuentran reservas pendientes de pago.";
            }
        }

        protected void GridViewReservasPend_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Pagar")
            {
                int indiceFila = Convert.ToInt32(e.CommandArgument);
                GridViewRow lafila = this.GridViewReservasPend.Rows[indiceFila];
                TableCell laCelda = lafila.Cells[0];

                string idReserva = laCelda.Text.ToString();
                int idRes = 0;
                int.TryParse(idReserva, out idRes);

                Reserva reservaSelec = Controladora.Fachada.BuscarReserva(idRes);

                if (reservaSelec != null)
                {
                    bool paga = Controladora.Fachada.PagarReserva(reservaSelec);                    
                    GridViewReservasPend.DataBind();
                }
            }
        }

        protected void btRankingCli_Click(object sender, EventArgs e)
        {
            lblMensajeReservas.Text = "";
           List <Usuario> ranking= Controladora.Fachada.TotalCompras();
            if (ranking.Count > 0)
            {
                

            }
            else
            {
                lblMensajeReservas.Text = "No se encuentran reservas pendientes de pago.";
            }
        }
    }
}
