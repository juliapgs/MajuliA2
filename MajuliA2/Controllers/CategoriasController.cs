using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Categoria;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public CategoriasController(MajuliA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de Categorias cadastradas
        /// </summary>
        /// <returns></returns>
        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        /// <summary>
        /// Retorna Categorias pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        /// <summary>
        /// Edita uma Categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns></returns>
        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaRequest request)
        {
            if (!CategoriaExists(id))
            {
                return NotFound();
            }

            Categoria categoria = await _context.Categoria.FindAsync(id);
            categoria.Nome = request.Nome;
            categoria.Descricao = request.Descricao;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Cadastra uma Categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns></returns>
        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(CategoriaRequest request)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = request.Nome;
            categoria.Descricao = request.Descricao;

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        /// <summary>
        /// Deleta uma Categoria já cadastrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
