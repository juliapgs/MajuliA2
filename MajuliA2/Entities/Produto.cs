using System.ComponentModel.DataAnnotations;

namespace MajuliA2.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Tamanho { get; set; }
        public string Cor { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Valor { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } // Relacionamento com Categoria

    }
}
