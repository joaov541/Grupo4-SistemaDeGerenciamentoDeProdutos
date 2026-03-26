using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Interfaces;

public interface IFornecedorRepository
{
    void Cadastrar(Fornecedor fornecedor);
    List<Fornecedor> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id);
    List<Fornecedor> BuscarPorId(Guid id);
}
