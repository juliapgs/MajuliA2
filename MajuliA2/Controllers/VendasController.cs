using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Venda;
using Microsoft.AspNetCore.Authorization;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public VendasController(MajuliA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de Vendas  
        /// </summary>
        /// <returns></returns>
        // GET: api/Vendas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            return await _context.Venda.ToListAsync();
        }

        /// <summary>
        /// Retorna Vendas pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Vendas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        /// <summary>
        /// Edita Venda cadastrada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/Vendas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutVenda(int id, VendaRequest request)
        {
            if (!VendaExists(id))
            {
                return NotFound();
            }

            Venda venda = await _context.Venda.FindAsync(id);
            venda.Cupom = await _context.Cupom.FindAsync(request.CupomId);
            venda.ValorTotal = request.ValorTotal;
            venda.FormaDePagamento = request.FormaDePagamento;
            venda.Endereco = request.Endereco;
            venda.Contato = request.Contato;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Cadastro de uma Venda 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST: api/Vendas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Venda>> PostVenda(VendaRequest request)
        {
            Venda venda = new Venda();
            venda.Cupom = await _context.Cupom.FindAsync(request.CupomId);
            venda.ValorTotal = request.ValorTotal;
            venda.FormaDePagamento = request.FormaDePagamento;
            venda.Endereco = request.Endereco;
            venda.Contato = request.Contato;

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.Id }, venda);
        }

        /// <summary>
        /// Deleta venda cadastrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Vendas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            _context.Venda.Remove(venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }
    }
}
