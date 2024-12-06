using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Produto;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoesController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public ProdutoesController(MajuliA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de Produtos
        /// </summary>
        /// <returns></returns>
        // GET: api/Produtoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produto.ToListAsync();
        }

        /// <summary>
        ///  Retorna Produtos cadastrados pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Produtoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        /// <summary>
        /// Edita Produto cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/Produtoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, ProdutoRequest request)
        {
            if (!ProdutoExists(id))
            {
                return NotFound();
            }

            Produto produto = await _context.Produto.FindAsync(id);
            produto.Categoria = await _context.Categoria.FindAsync(request.CategoriaId);
            produto.Nome = request.Nome;
            produto.Tamanho = request.Tamanho;
            produto.Cor = request.Cor;
            produto.Valor = request.Valor;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        ///// <summary>
        ///// Cadastra Produto
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //// POST: api/Produtoes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Produto>> PostProduto(ProdutoRequest request)
        //{
        //    Produto produto = new Produto();
        //    produto.Categoria = await _context.Categoria.FindAsync(request.CategoriaId);
        //    produto.Nome = request.Nome;
        //    produto.Tamanho = request.Tamanho;
        //    produto.Cor = request.Cor;
        //    produto.Valor = request.Valor;

        //    _context.Produto.Add(produto);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        //}

        /// <summary>
        /// Deleta um Produto cadastrado 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Produtoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
