using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<CategoriaDTO> Categoria { get; set; }
        public DbSet<Insumo> Insumo { get; set; }
    }
}
