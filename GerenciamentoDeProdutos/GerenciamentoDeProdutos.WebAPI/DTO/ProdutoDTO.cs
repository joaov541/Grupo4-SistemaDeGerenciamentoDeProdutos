namespace GerenciamentoDeProdutos.WebAPI.DTO;

public class ProdutoDTO
{
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public IFormFile? Imagem { get; set; }
    public Guid IdCategoria { get; set; }
    public Guid IdFornecedor { get; set; }
}
