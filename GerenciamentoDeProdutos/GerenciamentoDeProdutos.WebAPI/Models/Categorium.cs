using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.Models;

public partial class Categorium
{
    [Key]
    public Guid IdCategoria { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? Descricao { get; set; }

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
