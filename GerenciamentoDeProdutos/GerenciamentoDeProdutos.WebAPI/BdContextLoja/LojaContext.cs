using System;
using System.Collections.Generic;
using GerenciamentoDeProdutos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeProdutos.WebAPI.BdContextLoja;

public partial class LojaContext : DbContext
{
    public LojaContext()
    {
    }

    public LojaContext(DbContextOptions<LojaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Loja;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10A80C03F5");

            entity.Property(e => e.IdCategoria).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("PK__Forneced__22E24EC6111DAE29");

            entity.Property(e => e.IdFornecedor).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C2349EE71E4");

            entity.Property(e => e.IdProduto).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Produtos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produto__IdCateg__6383C8BA");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Produtos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Produto__IdForne__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
