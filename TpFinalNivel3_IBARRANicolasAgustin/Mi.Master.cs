using dominioo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (Session["usuario"] != null)
                lblNombreUsuario.Text = usuario.Email;


            if (!(Session["usuario"] == null))
            {
                imgAvatar.ImageUrl = "~/Images/" + usuario.urlimagenPerfil;

            }
            else
            {
                imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1qWAIpqePEAH-UPypnABjdT_eNu7hlLi54Q&usqp=CAU";
               
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btncerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx", false);
        }
    }
}