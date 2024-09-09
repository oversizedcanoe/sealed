using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sealed.Database;

public partial class SealedContext : DbContext
{
    private string _connectionString = string.Empty;

    public SealedContext(DbContextOptions<SealedContext> options, IConfiguration configuration)
        : base(options)
    {
        string connectionString = configuration["SealedConnectionString"];

        if (connectionString == null)
        {
            throw new Exception("Connection string not set in configuration");
        }

        _connectionString = connectionString;
    }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Codepair> Codepairs { get; set; }

    public virtual DbSet<Codetype> Codetypes { get; set; }

    public virtual DbSet<Userentry> Userentries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.Codeid).HasName("code_pkey");

            entity.ToTable("code");

            entity.Property(e => e.Codeid).HasColumnName("codeid");
            entity.Property(e => e.Code1).HasColumnName("code");
            entity.Property(e => e.Codetypeid).HasColumnName("codetypeid");

            entity.HasOne(d => d.Codetype).WithMany(p => p.Codes)
                .HasForeignKey(d => d.Codetypeid)
                .HasConstraintName("code_codetypeid_fkey");
        });

        modelBuilder.Entity<Codepair>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("codepair");

            entity.Property(e => e.Privatecodeid)
                .ValueGeneratedOnAdd()
                .HasColumnName("privatecodeid");
            entity.Property(e => e.Publiccodeid)
                .ValueGeneratedOnAdd()
                .HasColumnName("publiccodeid");

            entity.HasOne(d => d.Privatecode).WithMany()
                .HasForeignKey(d => d.Privatecodeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("codepair_privatecodeid_fkey");

            entity.HasOne(d => d.Publiccode).WithMany()
                .HasForeignKey(d => d.Publiccodeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("codepair_publiccodeid_fkey");
        });

        modelBuilder.Entity<Codetype>(entity =>
        {
            entity.HasKey(e => e.Codetypeid).HasName("codetype_pkey");

            entity.ToTable("codetype");

            entity.Property(e => e.Codetypeid)
                .ValueGeneratedNever()
                .HasColumnName("codetypeid");
            entity.Property(e => e.Codetypename)
                .HasMaxLength(20)
                .HasColumnName("codetypename");
        });

        modelBuilder.Entity<Userentry>(entity =>
        {
            entity.HasKey(e => e.Userentryid).HasName("userentry_pkey");

            entity.ToTable("userentry");

            entity.Property(e => e.Userentryid).HasColumnName("userentryid");
            entity.Property(e => e.Publiccodeid)
                .ValueGeneratedOnAdd()
                .HasColumnName("publiccodeid");

            entity.HasOne(d => d.Publiccode).WithMany(p => p.Userentries)
                .HasForeignKey(d => d.Publiccodeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userentry_publiccodeid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
