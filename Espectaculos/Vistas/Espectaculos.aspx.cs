using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Controladora;
using Utilidades;
using Dominio;
using System.IO;

namespace Vistas
{
    public partial class AltaEspectaculo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuAux = (Usuario)Session["usuario"];

            if(usuAux == null )
            {
                Response.Redirect("Login.aspx");
            }
            if (!usuAux.Admin)
            {
                Response.Redirect("Login.aspx");
            }

            //Solo los administradores tienen permisos 
            if (usuAux.Admin)
            {
                if (!IsPostBack)
                {
                    dropDownLugar.DataSource = Controladora.Fachada.LugaresExistentes();
                    dropDownLugar.DataTextField = "Nombre";
                    dropDownLugar.DataValueField = "Nombre";

                    dropDownLugar.DataBind();
                }
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
                                        if (Fachada.BuscarLugar(lugar) != null)
                                        {
                                            Lugar pLugar = Controladora.Fachada.BuscarLugar(lugar);

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
                                                            cbImpreso.Enabled = true;
                                                            tbRecargo.Enabled = false;
                                                            tbRecargo.Text = "";
                                                            lblMensajeEspecLlenos.Text = "";

                                                            mensaje = Fachada.AltaEstandar(nombre, tipoEspec, fecha, duracionEsp, horaEsp, pLugar, precioEsp, categoria, descrip, impreso);
                                                            LimpiarCampos();
                                                            lblMensajeAlta.Text = mensaje;

                                                        }
                                                        if (tipoEspec == "VIP")
                                                        {
                                                            cbImpreso.Enabled = false;
                                                            cbImpreso.Checked = false;
                                                            //Permito ingreso de de recargo
                                                            tbRecargo.Enabled = true;
                                                            lblMensajeEspecLlenos.Text = "";
                                                            
                                                            //Valido el recargo
                                                            if (!string.IsNullOrEmpty(recargo))
                                                            {
                                                                if (Herramientas.esNumero(recargo))
                                                                {
                                                                    decimal recargoEsp;
                                                                    decimal.TryParse(recargo, out recargoEsp);

                                                                    mensaje = Fachada.AltaVip(nombre, tipoEspec, fecha, duracionEsp, horaEsp, pLugar, precioEsp, categoria, descrip, recargoEsp);
                                                                    LimpiarCampos();
                                                                    lblMensajeAlta.Text = mensaje;
                                                                }
                                                                else
                                                                {
                                                                    lblMensajeRecargo.Text = "Ingrese un numero para el recargo";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                lblMensajeRecargo.Text = "Debe ingresar un valor mayor o igual a 0";
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
                            
                        }
                        else
                        {
                            lblHora.Text = "Hora invalida";
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
            List<Espectaculo> espectaculosLlenos = Controladora.Fachada.EspectaculosLlenos();
            if (espectaculosLlenos.Count > 0)
            {
                GridViewEspecLlenos.Visible = true;
                GridViewEspecLlenos.DataSource = espectaculosLlenos;
                GridViewEspecLlenos.DataBind();
                LimpiarCampos();
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
            cbImpreso.Enabled = true;
            tbRecargo.Enabled = false;
            tbRecargo.Text = "0";
            cbImpreso.Checked = true;
            rbTipoEspect.SelectedValue = "Estandar";
            lblMensajeEspecLlenos.Text = "";
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
            cbImpreso.Enabled = false;
            cbImpreso.Checked = false;
            tbRecargo.Enabled = true;
            tbRecargo.Text = "50";
            lblMensajeEspecLlenos.Text = "";
        }

        public void LimpiarCampos()
        {
            tbNombre.Text = "";
            Calendar.SelectedDate = DateTime.Today;
            tbHora.Text = "";
            tbMinutos.Text = "";
            tbDuracion.Text = "";
            dropDownLugar.SelectedValue = "Teatro Solis";
            tbPrecio.Text = "";
            tbCategoria.Text = "";
            tbDescripcion.Text = "";
            cbImpreso.Checked = false;
            rbTipoEspect.SelectedValue = "";
            tbRecargo.Text = "";
            lblCategoria.Text = "";
            lblDescrip.Text = "";
            lblDuracion.Text = "";
            lblFecha.Text = "";
            lblHora.Text = "";
            lblLugar.Text = "";
            lblMensajeAlta.Text = "";
            lblMensajeEspecLlenos.Text = "";
            lblMensajeRecargo.Text = "";
            lblNombre.Text = "";
            lblPrecio.Text = "";
        }
    }
}