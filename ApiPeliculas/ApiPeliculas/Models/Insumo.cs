using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models
{
    public class Insumo
    {
        [Key] 
        public int Id { get; set; }
        public string NoSerie { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }

        public int  PrecioUnitario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("categoriaId")]
        public Categoria Categoria { get; set; }

    }
}
