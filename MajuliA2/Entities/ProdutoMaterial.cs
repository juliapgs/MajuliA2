namespace MajuliA2.Entities
{
    public class ProdutoMaterial
    {
        public int ProdutoId { get; set; }
        public required Produto Produto { get; set; }

        public int MaterialId { get; set; }
        public required Material Material { get; set; }
    }
}
