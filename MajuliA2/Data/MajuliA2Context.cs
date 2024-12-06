using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MajuliA2.Entities;

namespace MajuliA2.Data
{
    public class MajuliA2Context : DbContext
    {
        public MajuliA2Context (DbContextOptions<MajuliA2Context> options)
            : base(options)
        {
        }

        public DbSet<MajuliA2.Entities.Produto> Produto { get; set; } = default!;
        public DbSet<MajuliA2.Entities.Material> Material { get; set; } = default!;
        public DbSet<MajuliA2.Entities.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<MajuliA2.Entities.Categoria> Categoria { get; set; } = default!;
        public DbSet<MajuliA2.Entities.Cupom> Cupom { get; set; } = default!;
        public DbSet<MajuliA2.Entities.Venda> Venda { get; set; } = default!;
    }
}
