namespace MajuliA2.Entities
{
    public class Cupom
    {
        public int Id { get; set; }
        public string Codigo { get; set; } // Código do cupom (ex: "DESCONTO10")
        public decimal ValorDesconto { get; set; } // Valor do desconto em percentual (ex: 10 para 10%)
        public DateTime DataValidade { get; set; } // Data de validade do cupom
    }
}
