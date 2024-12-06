using System.ComponentModel.DataAnnotations;

namespace MajuliA2.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contato")]
        public string Contato { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
