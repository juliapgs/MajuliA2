using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Fornecedor;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorsController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public FornecedorsController(MajuliA2Context context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Retorna lista dos Fornecedores cadastrados 
        /// </summary>
        /// <returns></returns>
        // GET: api/Fornecedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
        {
            return await _context.Fornecedor.ToListAsync();
        }

        /// <summary>
        /// Retorna Fornecedores pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Fornecedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        /// <summary>
        /// Edita Fornecedor já cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/Fornecedors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, FornecedorRequest request)
        {
            if (!FornecedorExists(id))
            {
                return NotFound();
            }

            Fornecedor fornecedor = await _context.Fornecedor.FindAsync(id);
            fornecedor.Nome = request.Nome;
            fornecedor.Contato = request.Contato;
            fornecedor.Email = request.Email;
            fornecedor.Endereco = request.Endereco;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        ///// <summary>
        ///// Cadastra Fornecedor
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //// POST: api/Fornecedors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Fornecedor>> PostFornecedor(FornecedorRequest request)
        //{
        //    Fornecedor fornecedor = new Fornecedor();
        //    fornecedor.Nome = request.Nome;
        //    fornecedor.Contato = request.Contato;
        //    fornecedor.Email = request.Email;
        //    fornecedor.Endereco = request.Endereco;

        //    _context.Fornecedor.Add(fornecedor);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        //}

        /// <summary>
        /// Deleta um Fornecedor cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Fornecedors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}
