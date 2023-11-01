using Datos;
using dominio;
using dominioo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNogico
    {

        public void AgregarFavorito(Usuario usuario, string Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@IdUser, @IdArticulo)");
                datos.setearParametros("@IdUser", usuario.Id);
                datos.setearParametros("IdArticulo", Id);
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

        public List<Articulos> ListarFavorito(Usuario usuario)
        {
            List<Articulos> articulos = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select * from ARTICULOS inner join FAVORITOS on ARTICULOS.Id = FAVORITOS.IdArticulo where FAVORITOS.IdUser = @IdUser");
                datos.setearParametros("@IdUser", usuario.Id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("codigo"))))
                        aux.CodigoArticulo = (string)datos.Lector["codigo"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("nombre"))))
                        aux.Nombre = (string)datos.Lector["nombre"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("Descripcion"))))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];



                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("imagenUrl"))))
                        aux.ImagenUrl = (string)datos.Lector["imagenUrl"];

                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("precio"))))
                        aux.Precio = (decimal)datos.Lector["precio"];

                    articulos.Add(aux);
                }

                return articulos;

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

        public void EliminarFavorito(string id, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdUser = @IdUser and IdArticulo = @IdArticulo");
                datos.setearParametros("@IdUser", usuario.Id);
                datos.setearParametros("@IdArticulo", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }



    }
}
