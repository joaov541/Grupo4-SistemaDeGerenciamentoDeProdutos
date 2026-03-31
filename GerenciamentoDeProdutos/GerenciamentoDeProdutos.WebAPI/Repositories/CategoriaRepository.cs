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

    /// <summary>
    /// Endpoint para atualizar uma categoria existente. 
    /// </summary>
    /// <param name="id">Id da catecoria atualizada</param>
    public void Atualizar(Guid id)
    {
        var CategoriaBuscada = _context.Categoria.Find(id);

        if (CategoriaBuscada != null)
        {
            CategoriaBuscada.Nome = CategoriaBuscada.Nome;
            CategoriaBuscada.Descricao = CategoriaBuscada.Descricao;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Endpoint para buscar uma categoria por id.
    /// </summary>
    /// <param name="id">Id da categoria buscada</param>
    /// <returns>Return status code 200 e categoria buscada</returns>
    public Categoria BuscarPorId(Guid id)
    {
        return _context.Categoria.Find(id)!;
    }

    /// <summary>
    /// Endpoint para cadastrar uma nova categoria.
    /// </summary>
    /// <param name="categoria">Categoria cadastrada</param>
    public void Cadastrar(Categoria categoria)
    {
        _context.Categoria.Add(categoria);
        _context.SaveChanges();
    }


    /// <summary>
    /// Endpoint para deletar uma categoria existente.
    /// </summary>
    /// <param name="id">Id da categoria deletada</param>
    public void Deletar(Guid id)
    {
        var categoriaBuscada = _context.Categoria.Find(id);

        if (categoriaBuscada != null)
        {
            _context.Categoria.Remove(categoriaBuscada);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Endpoint para listar todas as categorias cadastradas, ordenando por nome.
    /// </summary>
    /// <returns>Status code 200 e lista de categorias</returns>
    public List<Categoria> Listar()
    {
        return _context.Categoria.OrderBy(tipoUsuario => tipoUsuario.Nome).ToList();
    }
}
