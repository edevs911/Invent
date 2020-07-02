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
    [Route("api/Insumos")]
    [ApiController]
    public class InsumosController : Controller
    {
        private readonly IInsumoRepository _insRepo;
        private readonly IMapper _mapper;
        public InsumosController(IInsumoRepository insRepo, IMapper mapper)
        {
            _insRepo = insRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetInsumos()
        {
            var listaInsumos = _insRepo.GetInsumos();

            var listaInsumosDto = new List<InsumoDTO>();
            foreach (var lista in listaInsumos)
            {
                listaInsumosDto.Add(_mapper.Map<InsumoDTO>(lista));
            }

            return Ok(listaInsumosDto);
        }

        [HttpGet("{insumoId:int}", Name = "GetInsumo")]
        public IActionResult GetInsumo(int insumoId)
        {
            var itemInsumo = _insRepo.GetInsumo(insumoId);
            if (itemInsumo == null) return NotFound();
            var itemInsumoDTO = _mapper.Map<InsumoDTO>(itemInsumo);
            return Ok(itemInsumoDTO);
        }

        [HttpPost]
        public IActionResult CrearInsumo([FromBody] InsumoDTO insumoDTO)
        {
            if (insumoDTO == null)
            {
                return BadRequest(ModelState);
            }

            if (_insRepo.ExisteInsumo(insumoDTO.Nombre))
            {
                ModelState.AddModelError("", "El insumo ya existe");
                return StatusCode(404, ModelState);
            }

            var insumo = _mapper.Map<Insumo>(insumoDTO);

            if (!_insRepo.CrearInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro {insumo.Nombre}");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetInsumo", new { insumoID = insumo.Id }, insumo);
        }

        [HttpPatch("{insumoId:int}", Name = "ActualizarInsumo")]
        public IActionResult ActualizarInsumo(int insumoId, [FromBody] InsumoDTO insumoDTO)
        {
            if (insumoDTO == null || insumoId != insumoDTO.Id)
            {
                return BadRequest(ModelState);
            }

            var insumo = _mapper.Map<Insumo>(insumoDTO);
            if (!_insRepo.ActualizarInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salio mal, guardando el registro {insumo.Nombre}");
                return StatusCode(404, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{insumoId:int}", Name = "BorrarInsumo")]
        public IActionResult BorrarInsumo(int insumoId)
        {

            //var categoria = _mapper.Map<InsumoDTO>(insumoDTO);

            if (!_insRepo.ExisteInsumo(insumoId))
            {
                return NotFound();
            }

            var insumo = _insRepo.GetInsumo(insumoId);

            if (!_insRepo.BorrarInsumo(insumo))
            {
                ModelState.AddModelError("", $"Algo salio mal, borrando el registro {insumo.Nombre}");
                return StatusCode(404, ModelState);
            }
            return NoContent();
        }
    }
}
