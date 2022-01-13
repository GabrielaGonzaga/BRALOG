using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.BRALOG.webApi.Domains;

#nullable disable

namespace senai.BRALOG.webApi.Contexts
{
    public partial class BRALOGContext : DbContext
    {
        public BRALOGContext()
        {
        }

        public BRALOGContext(DbContextOptions<BRALOGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-K9TOBF2M\\SQLEXPRESS; initial catalog=BRALOG;  user Id=sa; pwd=Semprepea10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__885457EE41DBEAA9");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega)
                    .HasName("PK__Entregas__6CA5A988C36F70B7");

                entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.IdTipoPag).HasColumnName("idTipoPag");

                entity.Property(e => e.IdUsuário).HasColumnName("idUsuário");

                entity.Property(e => e.ValorTotal)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Entregas__idClie__4E88ABD4");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Entregas__idEsta__5070F446");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Entregas__idProd__4CA06362");

                entity.HasOne(d => d.IdTipoPagNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdTipoPag)
                    .HasConstraintName("FK__Entregas__idTipo__4F7CD00D");

                entity.HasOne(d => d.IdUsuárioNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuário)
                    .HasConstraintName("FK__Entregas__idUsuá__4D94879B");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__62EA894AD2E37D49");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produtos__5EEDF7C3A539952C");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPagamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoPag)
                    .HasName("PK__TipoPaga__FE68B05DE516CC59");

                entity.ToTable("TipoPagamento");

                entity.Property(e => e.IdTipoPag).HasColumnName("idTipoPag");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsu)
                    .HasName("PK__TipoUsua__FFD17CFBF49A215C");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsu).HasColumnName("idTipoUsu");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A60F9F295A");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsu).HasColumnName("idTipoUsu");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsu)
                    .HasConstraintName("FK__Usuarios__idTipo__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
