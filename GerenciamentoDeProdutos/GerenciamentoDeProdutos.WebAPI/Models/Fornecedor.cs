using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.Models;

[Table("Fornecedor")]
public partial class Fornecedor
{
    [Key]
    public Guid IdFornecedor { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("CNPJ")]
    [StringLength(150)]
    [Unicode(false)]
    public string Cnpj { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Contato { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [InverseProperty("IdFornecedorNavigation")]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
