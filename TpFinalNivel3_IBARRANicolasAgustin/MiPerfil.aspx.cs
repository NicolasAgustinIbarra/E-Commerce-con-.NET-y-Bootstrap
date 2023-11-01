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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes iniciar sesion para ingresar");
                Response.Redirect("error.aspx", false);
            }

            Usuario usuario = ((Usuario)Session["usuario"]);

            if (!IsPostBack)
            {
                
                txtEmail.Text = usuario.Email;
                txtEmail.Enabled = false;
                txtApellido2.Text = usuario.Apellido;
                txtNombre2.Text = usuario.Nombre;

                
            }


            if (string.IsNullOrEmpty(((Usuario)Session["usuario"]).urlimagenPerfil))
            {
                imgNuevoPerfil.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1qWAIpqePEAH-UPypnABjdT_eNu7hlLi54Q&usqp=CAU";
            }
            else
            {
                imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.urlimagenPerfil;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./Images/");
                Usuario usuario = ((Usuario)Session["usuario"]);
                txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");

                usuario.urlimagenPerfil = "Perfil-" + usuario.Id + ".jpg";
                imgNuevoPerfil.ImageUrl = "~/Images/" + usuario.urlimagenPerfil;

                usuario.Nombre = txtNombre2.Text;
                usuario.Apellido = txtApellido2.Text;

                negocio.Actualizar(usuario);



                Image Avatar = (Image)Master.FindControl("imgAvatar");
                Avatar.ImageUrl = "~/Images/" + usuario.urlimagenPerfil;



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}