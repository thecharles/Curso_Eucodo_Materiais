using System;
using System.Collections.Generic;
using AspnetWebApiDoisContextos.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetWebApiDoisContextos.Data;

public partial class Contexto3 : DbContext
{
    public Contexto3()
    {
    }

    public Contexto3(DbContextOptions<Contexto3> options)
        : base(options)
    {
    }

    public virtual DbSet<Carteira> Carteiras { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Transaco> Transacoes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=portifoliocripto; User ID=charles;Password=015580; MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carteira>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DataInclusao).HasColumnType("datetime");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carteiras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario_carteira");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.Mensagem)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaco>(entity =>
        {
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.DataInclusao).HasColumnType("datetime");
            entity.Property(e => e.Moeda)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantidade).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ValorAportado).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.ValorCorretora).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValorMoeda).HasColumnType("decimal(18, 10)");

            entity.HasOne(d => d.Carteira).WithMany(p => p.Transacos)
                .HasForeignKey(d => d.CarteiraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_carteira_transacoes");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.DataEmailValidado).HasColumnType("datetime");
            entity.Property(e => e.DataInclusao).HasColumnType("datetime");
            entity.Property(e => e.DataUltimoLogin).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PrimeiroNome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UltimoNome)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
