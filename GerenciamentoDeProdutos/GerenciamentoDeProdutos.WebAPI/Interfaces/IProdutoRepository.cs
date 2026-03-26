using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Interfaces;

public interface IProdutoRepository
{
    void Cadastrar(Produto produto);
    List<Produto> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, Produto produto);
    Produto BuscarPorId(Guid id);
}
