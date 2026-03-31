using GerenciamentoDeProdutos.WebAPI.DTO;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
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
            return Ok(novoFornecedor);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
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
