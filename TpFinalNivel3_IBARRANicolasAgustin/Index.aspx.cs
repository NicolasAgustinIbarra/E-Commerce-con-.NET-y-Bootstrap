using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Negocio;
using dominio;
using System.Web.UI.WebControls;
using dominioo;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            listaArticulos = negocio.listarConSp();
            Session.Add("Lista", negocio.listarConSp());
            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaArticulos;
                repRepetidor.DataBind();
            
            }

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisFavoritos.aspx");
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                string valor = ((Button)sender).CommandArgument;

                FavoritoNogico negocio = new FavoritoNogico();
                negocio.AgregarFavorito(usuario, valor);

            }

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["Lista"];
            string filtro = txtFiltro.Text.ToUpper();
            List<Articulos> listaFiltrada = lista.FindAll(x =>
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Categoria.Descripcion.ToUpper().Contains(filtro) ||
                x.Marca.Descripcion.ToUpper().Contains(filtro)
            );
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }
    }
}