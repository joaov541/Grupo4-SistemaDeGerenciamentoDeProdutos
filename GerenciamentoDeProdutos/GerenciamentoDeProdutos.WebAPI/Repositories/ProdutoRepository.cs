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

    public void Atualizar(Guid id, Produto produto)
    {
        var produtoBuscado = _context.Produtos.Find(id)!;

        if (produtoBuscado != null)
        {
            produtoBuscado.Descricao = String.IsNullOrWhiteSpace(produto.Descricao) ?
                produto.Descricao : produto.Descricao;
        }
    }

<<<<<<< HEAD
    public Produto BuscarPorId(Guid id)
=======
    public  Produto BuscarPorId(Guid id)
>>>>>>> 433f8b5865e360538284fce05b79ead68463f63f
    {
        return _context.Produtos.Find(id)!;
    }

    public void Cadastrar(Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var produtoBuscado = _context.Produtos.Find(id);

        if (produtoBuscado != null)
        {
            _context.Produtos.Remove(produtoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Produto> Listar()
    {
        return _context.Produtos.OrderBy(Produto => Produto.Nome).ToList();
    }
}
