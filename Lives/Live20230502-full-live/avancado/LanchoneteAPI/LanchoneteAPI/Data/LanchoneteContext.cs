using System;
using System.Collections.Generic;
using LanchoneteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteAPI.Data;

public partial class LanchoneteContext : DbContext
{
    public LanchoneteContext()
    {
    }

    public LanchoneteContext(DbContextOptions<LanchoneteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<MesasPedido> MesasPedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=lanchonete; User ID=charles;Password=015580; MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cnpj)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CNPJ");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.DataUltimoAcesso)
                .HasColumnType("datetime")
                .HasColumnName("dataUltimoAcesso");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("perfil");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senha");
            entity.Property(e => e.Situacao).HasColumnName("situacao");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("fk_funcionarios_empresas");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("datetime")
                .HasColumnName("data");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Situacao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("situacao");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Mesa)
                .HasForeignKey<Mesa>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mesas_funcionarios");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("fk_mesas_empresas");
        });

        modelBuilder.Entity<MesasPedido>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdMesa).HasColumnName("idMesa");
            entity.Property(e => e.IdProduto).HasColumnName("idProduto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.IdMesaNavigation).WithMany(p => p.MesasPedidos)
                .HasForeignKey(d => d.IdMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mesa_mesapedidos");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.MesasPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mesapedidos_produtos");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstoqueAtual).HasColumnName("estoqueAtual");
            entity.Property(e => e.EstoqueMinimo).HasColumnName("estoqueMinimo");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.PrecoCusto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precoCusto");
            entity.Property(e => e.PrecoVenda)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precoVenda");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("fk_empresas_produtos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
