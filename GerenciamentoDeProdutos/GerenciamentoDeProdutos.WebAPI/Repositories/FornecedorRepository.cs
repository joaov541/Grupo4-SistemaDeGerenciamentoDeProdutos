using GerenciamentoDeProdutos.WebAPI.BdContextLoja;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.Repositories;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly LojaContext _context;

    public FornecedorRepository(LojaContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Endpoint da API que Atualiza o fornecedor por id
    /// </summary>
    /// <param name="id">Id do fornecedor atualizado</param>
    /// <param name="fornecedor">fornecedor atualizado</param>
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


    /// <summary>
    /// Endpoint da API que Busca o fornecedor por Id
    /// </summary>
    /// <param name="id">Id do fornecedor buscado</param>
    /// <returns>Status code 200 e fornecedor buscado</returns>
    public Fornecedor BuscarPorId(Guid id)
    {
        return _context.Fornecedors.Find(id)!;
    }


    /// <summary>
    /// Endpoint da API que cadastra um novo fornecedor
    /// </summary>
    /// <param name="fornecedor">fornecedor cadastrado</param>
    public void Cadastrar(Fornecedor fornecedor)
    {
        _context.Fornecedors.Add(fornecedor);
        _context.SaveChanges();
    }

    /// <summary>
    /// Endpoint da API que deleta um fornecedor por id
    /// </summary>
    /// <param name="id">Id do fornecedor deletado</param>
    public void Deletar(Guid id)
    {
        var ContatoBuscado = _context.Fornecedors.Find(id);

        if (ContatoBuscado != null)
        {
            _context.Fornecedors.Remove(ContatoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Endpoint da API que lista os fornecedores
    /// </summary>
    /// <returns>Statuscode 200 e lista de fornecedores</returns>
    public List<Fornecedor> Listar()
    {
        return _context.Fornecedors.OrderBy(Fornecedor => Fornecedor.Nome).ToList();
    }
}
