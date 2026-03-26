using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly LojaContext _context;

    public CategoriaRepository(LojaContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> Listar()
    {
        throw new NotImplementedException();
    }
}
