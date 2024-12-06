using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Material;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public MaterialsController(MajuliA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de Materiais cadastrados
        /// </summary>
        /// <returns></returns>
        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMaterial()
        {
            return await _context.Material.ToListAsync();
        }

        /// <summary>
        /// Retorna Materiais pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return material;
        }

        /// <summary>
        /// Edita Material cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialRequest request)
        {
            if (!MaterialExists(id))
            {
                return NotFound();
            }

            Material material = await _context.Material.FindAsync(id);
            material.Nome = request.Nome;
            material.Tipo = request.Tipo;   
            material.Quantidade = request.Quantidade;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Cadastra um novo material
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(MaterialRequest request)
        {
            Material material = new Material();
            material.Nome = request.Nome; 
            material.Tipo = request.Tipo;
            material.Quantidade = request.Quantidade;

            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        /// <summary>
        /// Deleta um Material cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaterialExists(int id)
        {
            return _context.Material.Any(e => e.Id == id);
        }
    }
}
