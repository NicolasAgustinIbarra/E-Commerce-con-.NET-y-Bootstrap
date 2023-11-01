using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Negocio;
using Datos;
using dominio;
using System.Web.UI.WebControls;
using dominioo;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class ListadoDeProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Usuario)Session["usuario"]).TipoUsuario == true))
            {
                Session.Add("error", "No tienes permisos");
                Response.Redirect("error.aspx", false);
            }

            ArticulosNegocio negocio = new ArticulosNegocio();
            Session.Add("Lista", negocio.listarConSp());
            dgvListaArticulos.DataSource = Session["Lista"];
            dgvListaArticulos.DataBind();

        }

        protected void dgvListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioArticulo.aspx");
        }

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaArticulos.PageIndex = e.NewPageIndex;
            dgvListaArticulos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["Lista"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Articulos> listaFiltrada = lista.FindAll(x =>
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Categoria.Descripcion.ToUpper().Contains(filtro) ||
                x.Marca.Descripcion.ToUpper().Contains(filtro));
                

            dgvListaArticulos.DataSource = listaFiltrada;
            dgvListaArticulos.DataBind();

        }
    }
}