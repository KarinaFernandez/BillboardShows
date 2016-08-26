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
    public partial class AltaEspectaculo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                dropDownLugar.DataSource = Controladora.Controladora.LugaresExistentes();

                dropDownLugar.DataTextField = "Nombre";
                dropDownLugar.DataValueField = "Nombre";

                dropDownLugar.DataBind();
            }
        }


        protected void btAltaEspect_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            DateTime fecha = Calendar.SelectedDate;
            string hora = tbHora.Text;
            string minutos = tbMinutos.Text;
            string duracion = tbDuracion.Text;
            string lugar = dropDownLugar.SelectedValue;
            string precio = tbPrecio.Text;
            string categoria = tbCategoria.Text;
            string descrip = tbDescripcion.Text;
            bool impreso = cbImpreso.Checked;
            string tipoEspec = rbTipoEspect.SelectedValue;
            string recargo = tbRecargo.Text;

            //Valido el nombre
            if (!string.IsNullOrEmpty(nombre))
            {
                //La fecha de la funcion tiene que ser luego del dia de hoy
                if (fecha > DateTime.Today)
                {
                    //Valido la hora y minutos ingresados
                    if (Herramientas.esNumero(hora) && Herramientas.esNumero(minutos))
                    {
                        int horaValida;
                        int.TryParse(hora, out horaValida);

                        int minValido;
                        int.TryParse(minutos, out minValido);

                        //Valido la hora y minutos
                        if ((horaValida >= 00 && horaValida <= 23) && (minValido >= 00 && minValido <= 59))
                        {
                            string tiempo = horaValida.ToString() + minValido.ToString();
                            if (Herramientas.esHora(tiempo))
                            {
                                TimeSpan horaEsp;
                                TimeSpan.TryParse(tiempo, out horaEsp);

                                //Valido duracion
                                if (Herramientas.esNumero(duracion))
                                {
                                    int duracionEsp;
                                    int.TryParse(duracion, out duracionEsp);

                                    //Valido que haya algun lugar seleccionado
                                    if (lugar != null)
                                    {
                                        //Verifico que exista el lugar
                                        if (Controladora.Controladora.BuscarLugar(lugar) != null)
                                        {
                                            Lugar pLugar = Controladora.Controladora.BuscarLugar(lugar);

                                            //Valido el precio
                                            if (Herramientas.esNumero(precio))
                                            {
                                                decimal precioEsp;
                                                decimal.TryParse(precio, out precioEsp);

                                                //Valido ingrese una categoria que no sea nula
                                                if (!string.IsNullOrEmpty(categoria))
                                                {

                                                    //Valido la descripcion que no sea nula
                                                    if (!string.IsNullOrEmpty(descrip))
                                                    {
                                                        //Mensaje que devuelve la fachada
                                                        string mensaje = "";

                                                        //Valido si es Estandar o VIP
                                                        if (tipoEspec == "Estandar")
                                                        {
                                                            mensaje = Controladora.Controladora.AltaEstandar(nombre, tipoEspec, fecha, duracionEsp, horaEsp, pLugar, precioEsp, categoria, descrip, impreso);
                                                            lblMensajeAlta.Text = mensaje;

                                                        }
                                                        if (tipoEspec == "VIP")
                                                        {
                                                            //Seteo visibles los campos de recargo
                                                            lblRecarog.Visible = true;
                                                            tbRecargo.Visible = true;
                                                            //Oculto el checkbox impreso
                                                            cbImpreso.Visible = false;

                                                            //Valido el recargo
                                                            if (!string.IsNullOrEmpty(recargo))
                                                            {
                                                                if (Herramientas.esNumero(recargo))
                                                                {
                                                                    decimal recargoEsp;
                                                                    decimal.TryParse(recargo, out recargoEsp);

                                                                    mensaje = Controladora.Controladora.AltaVip(nombre, tipoEspec, fecha, duracionEsp, horaEsp, pLugar, precioEsp, categoria, descrip, recargoEsp);
                                                                    lblMensajeAlta.Text = mensaje;
                                                                }
                                                                else
                                                                {
                                                                    lblRecarog.Text = "Ingrese un numero para el recargo";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblRecarog.Text = "Debe ingresar un valor mayor o igual a 0";
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lblDescrip.Text = "Ingrese una descripcion";
                                                    }
                                                }
                                                else
                                                {
                                                    lblCategoria.Text = "Ingrese una categoria";
                                                }
                                            }
                                            else
                                            {
                                                lblPrecio.Text = "Ingrese un precio valido";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblLugar.Text = "Debe seleccionar un lugar";
                                    }
                                }
                                else
                                {
                                    lblDuracion.Text = "Duracion invalida";
                                }
                            }
                            else
                            {
                                lblHora.Text = "Hora invalida";
                            }
                        }
                    }
                }
                else
                {
                    lblFecha.Text = "La fecha debe de ser mayor al dia actual";
                }
            }
            else
            {
                lblNombre.Text = "Ingrese el nombre del espectaculo";
            }
        }


        protected void btEspecLlenos_Click(object sender, EventArgs e)
        {
            List<Espectaculo> espectaculosLlenos = Controladora.Controladora.EspectaculosLlenos();
            if (espectaculosLlenos.Count > 0)
            {
                GridViewEspecLlenos.Visible = true;
                GridViewEspecLlenos.DataSource = espectaculosLlenos;
                GridViewEspecLlenos.DataBind();
            }
            else
            {
                lblMensajeEspecLlenos.Text = "No se encuentran espectaculos con capacidad colmada.";
            }
        }

        protected void btCargarEstandar_Click(object sender, EventArgs e)
        {
            tbNombre.Text = "Noche de la nostalgia";
            Calendar.SelectedDate = new DateTime(2016, 08, 24);
            tbHora.Text = "00";
            tbMinutos.Text = "00";
            tbDuracion.Text = "480";
            dropDownLugar.SelectedValue = "La Trastienda";
            tbPrecio.Text = "750";
            tbCategoria.Text = "Concierto";
            tbDescripcion.Text = "Fiesta de la nostalgia";
            cbImpreso.Checked = true;
            rbTipoEspect.SelectedValue = "Estandar";

        }

        protected void btCargarVIP_Click(object sender, EventArgs e)
        {
            tbNombre.Text = "Nada es lo que parece 2";
            Calendar.SelectedDate = new DateTime(2016, 08, 29);
            tbHora.Text = "18";
            tbMinutos.Text = "00";
            tbDuracion.Text = "70";
            dropDownLugar.SelectedValue = "Movie Center";
            tbPrecio.Text = "250";
            tbCategoria.Text = "Cine";
            tbDescripcion.Text = "Los cuatro jinetes vuelven a la luz pública.";
            rbTipoEspect.SelectedValue = "VIP";
            tbRecargo.Text = "50";
        }
    }
}