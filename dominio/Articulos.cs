using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulos
    {
        public int Id { get; set; } 
        [DisplayName("Código")]
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }

        public override string ToString()
        {
            string verDetalle = "Codigo de Artículo: " + CodigoArticulo.ToString() + Environment.NewLine + "Descripción: " + Descripcion.ToString();
            return verDetalle;
        }
    }
}
