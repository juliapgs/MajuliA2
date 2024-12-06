using System.ComponentModel.DataAnnotations;

namespace MajuliA2.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contato")]
        public required string Contato { get; set; }
        public required string Email { get; set; }
        public required string Endereco { get; set; }
    }
}
