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
    public partial class Cartelera : System.Web.UI.Page
    {
        public static Espectaculo especSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            DateTime fDesdeDefecto = new DateTime(2016, 06, 01);
            CalendarDesde.SelectedDate = fDesdeDefecto;
            DateTime fHastaDefecto = new DateTime(2018, 01, 01);
            CalendarHasta.SelectedDate = fHastaDefecto;
        }

        protected void btFiltrar_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde = CalendarDesde.SelectedDate;
            DateTime fechaHasta = CalendarHasta.SelectedDate;
            string tipoEspec = rbTipoEspec.SelectedValue;
            string precioDesde = tbPrecioDesde.Text;
            string precioHasta = tbPrecioHasta.Text;
            lblMensajeFiltrado.Text = "";

            //Validacion de datos
            if (fechaDesde != null && fechaHasta != null)
            {
                //Validacion del precio
                //Si vienen vacios los precios le seteo 0
                if (string.IsNullOrEmpty(precioDesde))
                {
                    precioDesde = "0";
                }

                if (string.IsNullOrEmpty(precioHasta))
                {
                    precioHasta = "0";
                }

                if (Herramientas.esNumero(precioDesde))
                {
                    decimal precioD = 0;
                    decimal.TryParse(precioDesde, out precioD);

                    if (precioD >= 0)
                    {
                        if (Herramientas.esNumero(precioHasta))
                        {
                            decimal precioH = 0;
                            decimal.TryParse(precioHasta, out precioH);

                            if (precioH >= 0)
                            {

                                List<Espectaculo> listaFiltrada = Controladora.Fachada.EspectaculosFiltrados(fechaDesde, fechaHasta, tipoEspec, precioD, precioH);
                                if (listaFiltrada.Count > 0)
                                {
                                   
                                    GridViewEspect.Visible = true;
                                    GridViewEspect.DataSource = listaFiltrada;
                                    GridViewEspect.DataBind();
                                }
                                else
                                {
                                    lblMensajeFiltrado.Text = "No se encontraron espectaculos segun los datos ingresados";
                                }

                            }
                            else
                            {
                                lblPrecioHasta.Text = "Ingrese un valor mayor o igual a 0 para el precio hasta";
                            }
                        }
                        else
                        {
                            lblPrecioDesde.Text = "Ingrese un valor valido";
                        }
                    }
                    else
                    {
                        lblPrecioDesde.Text = "Ingrese un valor mayor o igual a 0 para el precio desde";
                    }
                }
                else
                {
                    lblPrecioDesde.Text = "Ingrese un valor valido";
                }
            }
        }



        protected void GridViewEspect_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                int indiceFila = Convert.ToInt32(e.CommandArgument);

                GridViewRow lafila = this.GridViewEspect.Rows[indiceFila];
                TableCell laCelda = lafila.Cells[0];

                string idEspectaculo = laCelda.Text.ToString();
                int idEsp = 0;
                int.TryParse(idEspectaculo, out idEsp);

                especSeleccionado = Fachada.BuscarEspectaculoPorID(idEsp);

                if (especSeleccionado != null)
                {
                    if (especSeleccionado.Fecha > DateTime.Today)
                    {
                        List<Espectaculo> listaAux = new List<Espectaculo>();
                        listaAux.Add(especSeleccionado);

                        GridViewDetalles.Visible = true;
                        GridViewDetalles.DataSource = listaAux;
                        GridViewDetalles.DataBind();

                        btReservar.Visible = true;
                    }else
                    {
                        lblMensajeFiltrado.Text = "El espectaculo seleccionado ya fue realizado";
                    }
                }
            }


        }

        
        protected void btReservar_Click(object sender, EventArgs e)
        {
            //Espectaculo especSel = (Espectaculo)Session["especSeleccionado"];
            //especSel = especSeleccionado;
            Session["especSeleccionado"] = especSeleccionado;
            Response.Redirect("AltaReserva.aspx");
        }

        protected void btCargaPantalla_Click(object sender, EventArgs e)
        {
            rbTipoEspec.SelectedValue = "Estandar";
            tbPrecioDesde.Text = "0";
            tbPrecioHasta.Text = "1000";
        }
    }

}

