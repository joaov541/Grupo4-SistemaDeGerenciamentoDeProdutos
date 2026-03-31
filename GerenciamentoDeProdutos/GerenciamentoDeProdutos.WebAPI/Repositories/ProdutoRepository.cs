using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly LojaContext _context;

    public ProdutoRepository(LojaContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Endpoint da API que atualiza o produto por id
    /// </summary>
    /// <param name="id">id do produto atualizado</param>
    /// <param name="produto">produto atualizado</param>
    public void Atualizar(Guid id, Produto produto)
    {
        var produtoBuscado = _context.Produtos.Find(id)!;

        if (produtoBuscado != null)
        {
            produtoBuscado.Descricao = String.IsNullOrWhiteSpace(produto.Descricao) ?
                produto.Descricao : produto.Descricao;
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Endpoint da API que nusca o produto por id
    /// </summary>
    /// <param name="id">id do produto buscado</param>
    /// <returns>Statuscode 200 e produto buscado</returns>
    public Produto BuscarPorId(Guid id)
    {
        return _context.Produtos.Find(id)!;
        
    }



    /// <summary>
    /// Endpoint para cadastrar um novo produto. 
    /// </summary>
    /// <param name="produto">Produto Cadastrado</param>
    public void Cadastrar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    /// <summary>
    /// Endpoint da API que deleta um produto por id
    /// </summary>
    /// <param name="id">id do produto deletado</param>
    public void Deletar(Guid id)
    {
        var produtoBuscado = _context.Produtos.Find(id);

        if (produtoBuscado != null)
        {
            _context.Produtos.Remove(produtoBuscado);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Endpoint da API que lista todos os produtos cadastrados
    /// </summary>
    /// <returns>Statuscode 200 e lista de produtos</returns>
    public List<Produto> Listar()
    {
        return _context.Produtos.OrderBy(Produto => Produto.Nome).ToList();
    }

  
}
