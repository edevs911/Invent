using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<CategoriaDTO> GetCategorias();
        CategoriaDTO GetCategoria(int CategoriaId);
        bool ExisteCategoria(string nombre);
        bool ExisteCategoria(int id);
        bool CrearCategoria(CategoriaDTO categoria);
        bool ActualizarCategoria(CategoriaDTO categoria);
        bool BorrarCategoria(CategoriaDTO categoria);
        bool Guardar();
        
    }
}
