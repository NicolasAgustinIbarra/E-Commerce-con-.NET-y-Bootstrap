using dominio;
using Negocio;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioo;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Usuario)Session["usuario"]).TipoUsuario == true))
            {
                Session.Add("error", "No tienes permisos");
                Response.Redirect("error.aspx", false);
            }
           
                MarcaNegocio negocioMarca = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ArticulosNegocio negocio = new ArticulosNegocio();
                txtId.Enabled = false;
                confirmaEliminacion = false;

                try
                {


                    if (!IsPostBack)
                    {

                        List<Marca> ListaMarcas = negocioMarca.listar();
                        List<Categoria> listaCategoria = categoriaNegocio.listar();


                        ddlCategoria.DataSource = listaCategoria;
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataBind();

                        ddlMarca.DataSource = ListaMarcas;
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataBind();

                        if (Request.QueryString["Id"] != null & !IsPostBack)
                        {
                            ArticulosNegocio negocioArt = new ArticulosNegocio();
                            Articulos nuevo = (negocioArt.listar(Request.QueryString["Id"].ToString())[0]);

                            Session.Add("articuloseleccionado", nuevo);


                            txtId.Text = nuevo.Id.ToString();
                            txtNombre.Text = nuevo.Nombre.ToString();
                            txtDescripcion.Text = nuevo.Descripcion.ToString();
                            txtPrecio.Text = nuevo.Precio.ToString();
                            txtUrlImagen.Text = nuevo.ImagenUrl.ToString();
                            txtCodigoArticulo.Text = nuevo.CodigoArticulo.ToString();

                            ddlCategoria.SelectedValue = nuevo.Categoria.Id.ToString();
                            ddlMarca.SelectedValue = nuevo.Marca.Id.ToString();

                            txtUrlImagen_TextChanged(sender, e);


                        }



                    }
                }
                catch (Exception ex)
                {

                    Session.Add("error", ex);
                    Response.Redirect("error.aspx");
                }
            
            

        }

        protected void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            // Disparar la validación del CustomValidator cuando cambia el texto
            cvPrecio.Validate();
        }

        protected void cvPrecio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Validar si el valor ingresado es un número
            if (decimal.TryParse(txtPrecio.Text, out _))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }


        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            var imagen = txtUrlImagen;
            articuloImagen.ImageUrl = imagen.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

           
            try
            {
                AccesoDatos datos = new AccesoDatos();
                Articulos nuevo = new Articulos();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.CodigoArticulo = txtCodigoArticulo.Text;
                nuevo.ImagenUrl = txtUrlImagen.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    datos.Modificar(nuevo);
                }
                else
                {
                    datos.Agregar(nuevo);
                }

                Response.Redirect("ListadoDeProductos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfimaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                AccesoDatos negocio = new AccesoDatos();
                negocio.eliminar(int.Parse(txtId.Text));
                Response.Redirect("ListadoDeProductos.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }
    }
}