using dominio;
using dominioo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class MisFavoritos : System.Web.UI.Page
    {
        public List<Articulos> ListaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesion para ingresar");
                Response.Redirect("error.aspx", false);
            }




            FavoritoNogico negocio = new FavoritoNogico();

            Usuario usuario = (Usuario)Session["usuario"];

            ListaFavoritos = negocio.ListarFavorito(usuario);
            if (!IsPostBack)
            {
                repFavorito.DataSource = ListaFavoritos;
                repFavorito.DataBind();

            }



        }


        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            string valor = ((Button)sender).CommandArgument;
            FavoritoNogico nogico = new FavoritoNogico();
            nogico.EliminarFavorito(valor, usuario);


            FavoritoNogico negocio = new FavoritoNogico();



            ListaFavoritos = negocio.ListarFavorito(usuario);
            repFavorito.DataSource = ListaFavoritos;
            repFavorito.DataBind();


        }
    }
}