using ApiPeliculas.Data;
using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using ApiPeliculas.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace ApiPeliculas.Repository
{
    public class InsumoRepository : IInsumoRepository
    {

        private readonly ApplicationDbContext _bd;
        public InsumoRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarInsumo(Insumo insumo)
        {
            _bd.Insumo.Update(insumo);
            return Guardar();
        }

        public bool BorrarInsumo(Insumo insumo)
        {
            _bd.Insumo.Remove(insumo);
            return Guardar();
        }

        public IEnumerable<Insumo> BuscarInsumo(string nombre)
        {
            IQueryable<Insumo> query = _bd.Insumo;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(e => e.Nombre.Contains(nombre));
            }
            return query.ToList();
        }

        public bool CrearInsumo(Insumo insumo)
        {
            _bd.Insumo.Add(insumo);
            return Guardar();
        }

        public bool ExisteInsumo(string nombre)
        {
            bool valor = _bd.Categoria.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public bool ExisteInsumo(int id)
        {
            return _bd.Insumo.Any(c => c.Id == id);
        }

        public Insumo GetInsumo(int InsumoId)
        {
            return _bd.Insumo.FirstOrDefault(c => c.Id == InsumoId);
        }

        public ICollection<Insumo> GetInsumos()
        {
            return _bd.Insumo.OrderBy(c => c.Nombre).ToList();
        }

        public ICollection<Insumo> GetPelicasenCategoria(int CatId)
        {
            return _bd.Insumo.Include(ca => ca.Categoria).Where(ca => ca.CategoriaId == CatId).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
