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

    public void Atualizar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Produto> BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Produto produto)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Produto> Listar()
    {
        throw new NotImplementedException();
    }
}
