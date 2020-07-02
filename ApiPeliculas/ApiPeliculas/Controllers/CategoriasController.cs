using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPeliculas.Models;
using ApiPeliculas.Models.Dtos;
using ApiPeliculas.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiPeliculas.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriaRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var listaCategorias = _ctRepo.GetCategorias();

            var listaCategoriasDto = new List<CategoriaDTO>();
            foreach (var lista in listaCategorias)
            {
                listaCategoriasDto.Add(_mapper.Map<CategoriaDTO>(lista));
            }

            return Ok(listaCategoriasDto);
        }

        [HttpGet("{categoriaId:int}", Name = "GetCategoria")]
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _ctRepo.GetCategoria(categoriaId);
            if (itemCategoria == null) return NotFound();
            var itemCategoriaDTO = _mapper.Map<CategoriaDTO>(itemCategoria);
            return Ok(itemCategoriaDTO);
        }

        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExisteCategoria(categoriaDTO.Nombre))
            {
                ModelState.AddModelError("", "La categoria ya existe");
                return StatusCode(404, ModelState);
            }

            var categoria = _mapper.Map<CategoriaDTO>(categoriaDTO);

            if (!_ctRepo.CrearCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro {categoria.Nombre}");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetCategoria", new { categoriaId = categoria.Id }, categoria);
        }

        [HttpPatch("{categoriaId:int}", Name = "ActualizarCategoria")]
        public IActionResult ActualizarCategoria(int categoriaId, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null || categoriaId != categoriaDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var categoria = _mapper.Map<CategoriaDTO>(categoriaDTO);
            if (!_ctRepo.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro {categoria.Nombre}");
                return StatusCode(404, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{categoriaId:int}", Name = "BorrarCategoria")]
        public IActionResult BorrarCategoria(int categoriaId)
        {

            //var categoria = _mapper.Map<CategoriaDTO>(categoriaDTO);

            if (!_ctRepo.ExisteCategoria(categoriaId))
            {
                return NotFound();
            }

            var categoria = _ctRepo.GetCategoria(categoriaId);

            if (!_ctRepo.BorrarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal, borrando el registro {categoria.Nombre}");
                return StatusCode(404, ModelState);
            }
            return NoContent();
        }
    }
}
