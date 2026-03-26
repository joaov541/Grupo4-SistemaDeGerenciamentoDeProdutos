using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly LojaContext _context;

    public FornecedorRepository(LojaContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Fornecedor> BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Fornecedor fornecedor)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Fornecedor> Listar()
    {
        throw new NotImplementedException();
    }
}
