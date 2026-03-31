using GerenciamentoDeProdutos.WebAPI.DTO;
using GerenciamentoDeProdutos.WebAPI.Interfaces;
using GerenciamentoDeProdutos.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeProdutos.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    /// <summary>
    /// Endpoint para listar todos os produtos cadastrados no sistema
    /// </summary>
    /// <returns>Status code 200 e lista de categorias</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_produtoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint para buscar um produto específico através do seu ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status code 200 e categoria buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_produtoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint para cadastrar um novo produto no sistema.
    /// </summary>
    /// <param name="produto"></param>
    /// <returns>Status code 201 e categoria cadastrada</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] ProdutoDTO produto)
    {
        if (String.IsNullOrWhiteSpace(produto.Nome))
            return BadRequest("É obrigatório que o produto tenha um nome");

        Produto novoProduto = new Produto();

        if (produto.Imagem != null && produto.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(produto.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using (var cont = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await produto.Imagem.CopyToAsync(cont);
            }

            novoProduto.Imagem = nomeArquivo;
        }

        novoProduto.Nome = produto.Nome;
        novoProduto.Descricao = produto.Descricao;
        novoProduto.Preco = produto.Preco;
        novoProduto.QuantidadeEstoque = produto.QuantidadeEstoque;
        novoProduto.IdCategoria = produto.IdCategoria;
        novoProduto.IdFornecedor = produto.IdFornecedor;

        try
        {
            _produtoRepository.Cadastrar(novoProduto);

            return StatusCode(201, novoProduto);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }

    }

    /// <summary>
    /// Endpoint para atualizar os dados de um produto já cadastrado no sistema.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="produtoAtualizado"></param>
    /// <returns>Status code 201 e categoria atualizada</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromForm] ProdutoDTO produtoAtualizado)
    {
        var produtoBuscado = _produtoRepository.BuscarPorId(id);
        if (produtoBuscado == null)
            return NotFound("Contato não encontrado");


        //Atualiza dados básicos
        produtoBuscado.Nome = produtoAtualizado.Nome;
        produtoBuscado.Descricao = produtoAtualizado.Descricao;
        produtoBuscado.Preco = produtoAtualizado.Preco;
        produtoBuscado.QuantidadeEstoque = produtoBuscado.QuantidadeEstoque;

        if (produtoAtualizado.Imagem != null && produtoAtualizado.Imagem.Length > 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);
            if (!String.IsNullOrEmpty(produtoBuscado.Imagem))
            {
                var caminhoAntigo = Path.Combine(caminhoPasta, produtoBuscado.Imagem);
                if (System.IO.File.Exists(caminhoAntigo))
                {
                    System.IO.File.Delete(caminhoAntigo);
                }
            }

            var extensao = Path.GetExtension(produtoAtualizado.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            }
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await produtoAtualizado.Imagem.CopyToAsync(stream);
            }
            produtoBuscado.Imagem = nomeArquivo;
        }
        try
        {
            _produtoRepository.Atualizar(id, produtoBuscado);
            return Ok(produtoBuscado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint para deletar um produto cadastrado no sistema, através do seu ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _produtoRepository.Deletar(id);

            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}
