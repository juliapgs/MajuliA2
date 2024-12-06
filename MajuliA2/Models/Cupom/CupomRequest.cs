namespace MajuliA2.Models.Cupom
{
    public class CupomRequest
    {
        public string Codigo { get; set; } // Código do cupom (ex: "DESCONTO10")
        public decimal ValorDesconto { get; set; } // Valor do desconto em percentual (ex: 10 para 10%)
        public DateTime DataValidade { get; set; } // Data de validade do cupom
    }
}
