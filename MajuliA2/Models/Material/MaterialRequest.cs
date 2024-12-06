using System.ComponentModel.DataAnnotations;

namespace MajuliA2.Models.Material
{
    public class MaterialRequest
    {
        [Required(ErrorMessage = "O nome do material é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo do material é obrigatório.")]
        public string Tipo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
    }
}
