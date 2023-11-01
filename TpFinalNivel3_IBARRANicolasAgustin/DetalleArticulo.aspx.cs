using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArt = new ArticulosNegocio();
            Articulos nuevo = (negocioArt.listar(Request.QueryString["Id"].ToString())[0]);

            Session.Add("articuloDetalle", nuevo);
            lblNombreDetalle.Text = (string)nuevo.Nombre;
            lblDescripcionDetalle.Text = nuevo.Descripcion;
            lblPrecio.Text = "$" + (string)nuevo.Precio.ToString();
            lblCategoriaDetalle.Text = nuevo.Categoria.Descripcion.ToString();
            lblMarcaDetalle.Text = nuevo.Marca.Descripcion.ToString();
            lblCodigoDetalle.Text = nuevo.CodigoArticulo.ToString();
            imgVerDetalle.ImageUrl = nuevo.ImagenUrl == null ? "https ://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1qWAIpqePEAH-UPypnABjdT_eNu7hlLi54Q&usqp=CAU" : nuevo.ImagenUrl;


        }
    }
}