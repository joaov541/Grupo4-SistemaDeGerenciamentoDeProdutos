using GerenciamentoDeProdutos.WebAPI.DTO;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
using GerenciamentoDeProdutos.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeProdutos.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase
{
    private readonly IFornecedorRepository _fornecedorRepository;

    public FornecedorController(IFornecedorRepository fornecedorRepository)
    {
        _fornecedorRepository = fornecedorRepository;
    }

<<<<<<< HEAD
   
=======
    /// <summary>
    /// Endpoint da API que faz chamada para o metodo de listar o fornecedor
    /// </summary>
    /// <returns>Status code 200 e a lista o fornecedor</returns>
>>>>>>> 55b450c945370e766fc3b421f8d0eb0a44a87ebd
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_fornecedorRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para um metodo de buscar fornecedor
    /// </summary>
    /// <param name="id">Id do fornecedor buscado</param>
    /// <returns>Status code 200 e  fornecedor buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_fornecedorRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para um metodo de cadastrar fornecedor
    /// </summary>
    /// <param name="fornecedor">Fornecedor a ser cadastrado</param>
    /// <returns>Status code 201 e o fornecedor cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(FornecedorDTO fornecedor)
    {
        try
        {
            var novoFornecedor = new Fornecedor
            {
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj,
                Contato = fornecedor.Contato,
                Email = fornecedor.Email
            };
            _fornecedorRepository.Cadastrar(novoFornecedor);
            return StatusCode(201, novoFornecedor);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para um metodo de atualizar fornecedor
    /// </summary>
    /// <param name="id">Fornecedor com os dados atualizados/param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, FornecedorDTO fornecedor)
    {
        try
        {
            var FornecedorAtualizado = new Fornecedor
            {
               Cnpj = fornecedor.Cnpj!
            };

            _fornecedorRepository.Atualizar(id, FornecedorAtualizado);
            return StatusCode(204, FornecedorAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para um metodo de deletar fornecedor 
    /// </summary>
    /// <param name="id">Id do fornecedor a ser excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _fornecedorRepository.Deletar(id);
            return NoContent(); 
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}
