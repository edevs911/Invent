using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Repository.IRepository
{
    public interface IInsumoRepository
    {
        ICollection<Insumo> GetInsumos();
        ICollection<Insumo> GetPelicasenCategoria(int CatId);
        Insumo GetInsumo(int InsumoId);
        bool ExisteInsumo(string nombre);
        IEnumerable<Insumo> BuscarInsumo(string nombre);
        bool ExisteInsumo(int id);
        
        bool CrearInsumo(Insumo insumo);
        bool ActualizarInsumo(Insumo insumo);
        bool BorrarInsumo(Insumo insumo);
        bool Guardar();
        
    }
}
