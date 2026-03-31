using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly LojaContext _context;

    public FornecedorRepository(LojaContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, Fornecedor fornecedor)
    {
        var FornecedorBuscado = _context.Fornecedors.Find(id);
        if (FornecedorBuscado != null)
            {
            FornecedorBuscado.Nome = fornecedor.Nome;
            FornecedorBuscado.Cnpj = fornecedor.Cnpj;
            FornecedorBuscado.Contato = fornecedor.Contato;
            FornecedorBuscado.Email = fornecedor.Email;
            }
    }

    public Fornecedor BuscarPorId(Guid id)
    {
        return _context.Fornecedors.Find(id)!;
    }

    public void Cadastrar(Fornecedor fornecedor)
    {
        _context.Fornecedors.Add(fornecedor);
        _context.SaveChanges();
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
