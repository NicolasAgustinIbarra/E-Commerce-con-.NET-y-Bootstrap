using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dominio;
using System.Threading.Tasks;
using dominioo;
using Datos;
using System.Diagnostics.Eventing.Reader;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void Actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
			try
			{
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlimagenPerfil = @imagen where Id = @Id");
                datos.setearParametros("@imagen", usuario.urlimagenPerfil);
                datos.setearParametros("@Id", usuario.Id);
				datos.setearParametros("@nombre", usuario.Nombre);
				datos.setearParametros("@apellido", usuario.Apellido);

                datos.ejecutarAccion();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
			
			
        }

        public bool Loguear(Usuario usuario)
        {
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select Id,nombre, apellido, urlimagenPerfil, admin from USERS Where email = @Email AND pass = @Pass");
				datos.setearParametros("@Email", usuario.Email);
				datos.setearParametros("@Pass", usuario.Pass);

				datos.ejecutarLectura();
				while (datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
					usuario.TipoUsuario = (bool)datos.Lector["admin"];
					if (!(datos.Lector["Nombre"] is DBNull))
						usuario.Nombre = (string)datos.Lector["Nombre"];
					if (!(datos.Lector["Apellido"] is DBNull))
						usuario.Apellido = (string)datos.Lector["Apellido"];
					if (!(datos.Lector["urlimagenPerfil"] is DBNull))
						usuario.urlimagenPerfil = (string)datos.Lector["urlimagenPerfil"];

					return true;
				}
				return false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
		
		public int RegistrarUsuario(Usuario nuevo)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
                datos.setearProcedure("RegistrarUsuario");
                datos.setearParametros("email", nuevo.Email);
                datos.setearParametros("pass", nuevo.Pass);


                return datos.ejecutarScalar();
            }
			catch (Exception ex)
			{

				throw ex;
			}
			finally { datos.cerrarConexion();}
			
		}
    }
}
