using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.Models;

[Table("Produto")]
public partial class Produto
{
    [Key]
    public Guid IdProduto { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Descricao { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Preco { get; set; }

    public int QuantidadeEstoque { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    public Guid IdCategoria { get; set; }

    public Guid IdFornecedor { get; set; }

    [ForeignKey("IdCategoria")]
    [InverseProperty("Produtos")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [ForeignKey("IdFornecedor")]
    [InverseProperty("Produtos")]
    public virtual Fornecedor IdFornecedorNavigation { get; set; } = null!;
}
