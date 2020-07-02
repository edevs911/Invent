using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using ApiPeliculas.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ApiPeliculas.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _bd;
        public CategoriaRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCategoria(CategoriaDTO categoria)
        {
            _bd.Categoria.Update(categoria);
            return Guardar();
        }

        public bool BorrarCategoria(CategoriaDTO categoria)
        {
            _bd.Categoria.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(CategoriaDTO categoria)
        {
            _bd.Categoria.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(string nombre)
        {
            bool valor = _bd.Categoria.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteCategoria(int id)
        {
            return _bd.Categoria.Any(c => c.Id == id);
        }

        //Obtiene una unica categoria
        public CategoriaDTO GetCategoria(int CategoriaId)
        {
            return _bd.Categoria.FirstOrDefault(c => c.Id == CategoriaId);
        }
        //Obtiene todas las categoria
        public ICollection<CategoriaDTO> GetCategorias()
        {
            //Ordenadas de manera ascedente
            return _bd.Categoria.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
