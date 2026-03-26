using GerenciamentoDeProdutos.WebAPI.Models;

namespace GerenciamentoDeProdutos.WebAPI.Interfaces;

public interface ICategoriaRepository
{
    void Cadastrar(Categoria categoria);
    List<Categoria> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id);
    List<Categoria> BuscarPorId(Guid id);
}
