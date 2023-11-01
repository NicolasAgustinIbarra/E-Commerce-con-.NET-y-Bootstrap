using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using dominio;
using Negocio;
using System.Web.UI.WebControls;
using dominioo;

namespace TpFinalNivel3_IBARRANicolasAgustin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;    

                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx",false);
                }
            }
            catch (Exception)
            {

                Session.Add("error", "usuario o contraseña incorrectos");
                Response.Redirect("error.aspx",false);
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario nuevo = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            // Obtén los valores de los campos de entrada
            nuevo.Email = txtEmailRegister.Text;
            nuevo.Pass = txtPassRegister.Text;

            // Verifica si los campos no están vacíos
            if (!string.IsNullOrEmpty(nuevo.Email) && !string.IsNullOrEmpty(nuevo.Pass))
            {
                int id = negocio.RegistrarUsuario(nuevo);

                if (negocio.Loguear(nuevo))
                {
                    Session.Add("usuario", nuevo);
                    Response.Redirect("MiPerfil.aspx", false);
                }
            }
            else
            {

                Session.Add("error", "Debes ingresar valores validos");
                Response.Redirect("error.aspx", false);
            }
        }

    }
}