namespace MajuliA2.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaDePagamento { get; set; }
        public string Endereco { get; set; }
        public string Contato { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>(); // Inicializa a lista

        // Relacionamento com Cupom
        public int? CupomId { get; set; } // Cupom opcional
        public Cupom Cupom { get; set; }

        // Método para calcular o valor final com desconto
        public decimal CalcularValorFinal()
        {
            if (Cupom != null && Cupom.ValorDesconto > 0)
            {
                return ValorTotal - (ValorTotal * (Cupom.ValorDesconto / 100));
            }
            return ValorTotal;
        }
    }
}
