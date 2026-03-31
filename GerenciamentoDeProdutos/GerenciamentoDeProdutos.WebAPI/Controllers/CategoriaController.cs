using GerenciamentoDeProdutos.WebAPI.DTO;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeProdutos.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    /// <summary>
    /// Endpoint para listar todas as categorias cadastradas.
    /// </summary>
    /// <returns>Status code 200 e lista de categorias</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_categoriaRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint para buscar uma categoria por id.
    /// </summary>
    /// <param name="id">Id da categoria buscada</param>
    /// <returns>Status code 200 e categoria buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_categoriaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint para cadastrar uma nova categoria.
    /// </summary>
    /// <param name="categoria">Categoria Cadastrada</param>
    /// <returns>Status code 201 e categoria cadastrada</returns>
    [HttpPost]
    public IActionResult Cadastrar(CategoriaDTO categoria)
    {
        try
        {
            var noaCategoria = new Categoria
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };

            _categoriaRepository.Cadastrar(noaCategoria);
            return StatusCode(201, noaCategoria);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint para atualizar uma categoria existente, buscando por id.
    /// </summary>
    /// <param name="id">id da categoria atualizada</param>
    /// <param name="categoria">categoria atualizada</param>
    /// <returns>Status code 201 e categoria atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, CategoriaDTO categoria)
    {
        try
        {
            var categoriaAtualizada = new Categoria
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao
            };
            _categoriaRepository.Atualizar(id);
            return StatusCode(201, categoriaAtualizada);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint para deletar uma categoria existente, buscando por id. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _categoriaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
