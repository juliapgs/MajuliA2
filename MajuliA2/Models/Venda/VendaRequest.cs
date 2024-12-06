using MajuliA2.Entities;

namespace MajuliA2.Models.Venda
{
    public class VendaRequest
    {
        public decimal ValorTotal { get; set; }
        public string FormaDePagamento { get; set; }
        public string Endereco { get; set; }
        public string Contato { get; set; }

        // Relacionamento com Cupom
        public int? CupomId { get; set; } // Cupom opcional

    }
}
