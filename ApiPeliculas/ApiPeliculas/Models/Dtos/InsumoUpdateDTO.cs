using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Models.Dtos
{
    public class InsumoUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de serie es obligatorio")]
        public string NoSerie { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public int PrecioUnitario { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
