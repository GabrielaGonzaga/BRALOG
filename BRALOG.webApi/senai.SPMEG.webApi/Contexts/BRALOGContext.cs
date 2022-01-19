using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BRALOG.webApi.Domains;

#nullable disable

namespace BRALOG.webApi.Contexts
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
        public virtual DbSet<TiposPagamento> TiposPagamentos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-TP10LGF\\SQLEXPRESS;Initial Catalog=BRALOG;User ID=sa;Password=Senha@132");
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-K9TOBF2M\\SQLEXPRESS; initial catalog=BRALOG;  user Id=sa; pwd=Semprepea10;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D594664244ECC2BE");

                entity.Property(e => e.Cidade)
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

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Clientes__IdEsta__4316F928");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Clientes__IdUsua__4222D4EF");
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.HasKey(e => e.IdEntrega)
                    .HasName("PK__Entregas__6CA5A988A734F1DC");

                entity.Property(e => e.IdEntrega).HasColumnName("idEntrega");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.ValorTotal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Entregas__IdClie__48CFD27E");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Entregas__IdEsta__49C3F6B7");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Entregas__IdProd__46E78A0C");

                entity.HasOne(d => d.IdTipoPagNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdTipoPag)
                    .HasConstraintName("FK__Entregas__IdTipo__47DBAE45");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Entregas__IdUsua__45F365D3");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estados__FBB0EDC1398126DD");

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produtos__5EEDF7C328FA8AF2");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Produtos__IdUsua__3F466844");
            });

            modelBuilder.Entity<TiposPagamento>(entity =>
            {
                entity.HasKey(e => e.IdTipoPag)
                    .HasName("PK__TiposPag__FE68B05D951431EA");

                entity.ToTable("TiposPagamento");

                entity.Property(e => e.IdTipoPag).HasColumnName("idTipoPag");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsu)
                    .HasName("PK__TiposUsu__2371A107F13AA28B");

                entity.ToTable("TiposUsuario");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF9753E16DEB");

                entity.Property(e => e.Email)
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

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsu)
                    .HasConstraintName("FK__Usuarios__IdTipo__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
