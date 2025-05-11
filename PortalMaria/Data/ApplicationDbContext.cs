using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PortalMaria.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Alunos { get; set; }

    public virtual DbSet<HorarioAluno> HorarioAlunos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-REMNSM0;Database=PortalMaria;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aluno__3214EC072EFFE5BB");

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Responsavel).HasMaxLength(100);
            entity.Property(e => e.Telefone).HasMaxLength(20);
        });

        modelBuilder.Entity<HorarioAluno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Horario___3214EC07B5362C1E");

            entity.ToTable("HorarioAluno");

            entity.Property(e => e.CriadoEm)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Materias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NivelEscolar)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NomeAluno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacoes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAlunoNavigation).WithMany(p => p.HorarioAlunos)
                .HasForeignKey(d => d.IdAluno)
                .HasConstraintName("FK_IdAluno");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
