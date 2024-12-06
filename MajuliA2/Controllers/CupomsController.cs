using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Data;
using MajuliA2.Entities;
using MajuliA2.Models.Cupom;
using Microsoft.AspNetCore.Authorization;

namespace MajuliA2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomsController : ControllerBase
    {
        private readonly MajuliA2Context _context;

        public CupomsController(MajuliA2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna lista de Cupons cadastrados
        /// </summary>
        /// <returns></returns>
        // GET: api/Cupoms
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Cupom>>> GetCupom()
        {
            return await _context.Cupom.ToListAsync();
        }

        /// <summary>
        /// Retorna Cupons pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Cupoms/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Cupom>> GetCupom(int id)
        {
            var cupom = await _context.Cupom.FindAsync(id);

            if (cupom == null)
            {
                return NotFound();
            }

            return cupom;
        }

        /// <summary>
        /// Edita um Cupom já cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/Cupoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupom(int id, CupomRequest request)
        {
            if (!CupomExists(id))
            {
                return NotFound();
            }

            Cupom cupom = await _context.Cupom.FindAsync(id);
            cupom.Codigo = request.Codigo;
            cupom.ValorDesconto = request.ValorDesconto;
            cupom.DataValidade = request.DataValidade;

            return NoContent();
        }

        /// <summary>
        /// Cadastra Cupom
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST: api/Cupoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cupom>> PostCupom(CupomRequest request)
        {

            Cupom cupom = new Cupom();
            cupom.Codigo = request.Codigo;
            cupom.ValorDesconto = request.ValorDesconto;
            cupom.DataValidade = request.DataValidade;

            _context.Cupom.Add(cupom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCupom", new { id = cupom.Id }, cupom);
        }

        /// <summary>
        /// Deleta cupom cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Cupoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupom(int id)
        {
            var cupom = await _context.Cupom.FindAsync(id);
            if (cupom == null)
            {
                return NotFound();
            }

            _context.Cupom.Remove(cupom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupomExists(int id)
        {
            return _context.Cupom.Any(e => e.Id == id);
        }
    }
}
