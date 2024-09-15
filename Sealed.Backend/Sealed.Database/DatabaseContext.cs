using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sealed.Domain.Models;

namespace Sealed.Database;

public partial class DatabaseContext : DbContext
{
    private string _connectionString = string.Empty;

    public DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
        : base(options)
    {
        string connectionString = configuration["SealedConnectionString"];

        if (connectionString == null)
        {
            throw new Exception("Connection string not set in configuration");
        }

        _connectionString = connectionString;
    }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<KeyPair> KeyPairs { get; set; }

    public virtual DbSet<KeyType> KeyTypes { get; set; }

    public virtual DbSet<UserEntry> UserEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.KeyId).HasName("key_pkey");

            entity.ToTable("key");

            entity.Property(e => e.KeyId).HasColumnName("keyid");
            entity.Property(e => e.KeyTypeId).HasColumnName("keytypeid");
            entity.Property(e => e.Code).HasColumnName("code");

            entity.HasOne(d => d.KeyType).WithMany(p => p.Keys)
                .HasForeignKey(d => d.KeyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_keytypeid_fkey");
        });

        modelBuilder.Entity<KeyPair>(entity =>
        {
            entity.HasKey(e => e.KeyPairId).HasName("keypair_pkey");

            entity.ToTable("keypair");

            entity.Property(e => e.KeyPairId).HasColumnName("keypairid");
            entity.Property(e => e.PrivateKeyId).HasColumnName("privatekeyid");
            entity.Property(e => e.PublicKeyId).HasColumnName("publickeyid");

            entity.HasOne(d => d.PrivateKey).WithMany()
                .HasForeignKey(d => d.PrivateKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("keypair_privatekeyid_fkey");

            entity.HasOne(d => d.PublicKey).WithMany()
                .HasForeignKey(d => d.PublicKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("keypair_publickeyid_fkey");
        });

        modelBuilder.Entity<KeyType>(entity =>
        {
            entity.HasKey(e => e.KeyTypeId).HasName("keytype_pkey");

            entity.ToTable("keytype");

            entity.Property(e => e.KeyTypeId)
                .ValueGeneratedNever()
                .HasColumnName("keytypeid");
            entity.Property(e => e.KeyTypeName)
                .HasMaxLength(20)
                .HasColumnName("keytypename");
        });

        modelBuilder.Entity<KeyType>().HasData(
            new KeyType { KeyTypeId = 1, KeyTypeName = "Private" },
            new KeyType { KeyTypeId = 2, KeyTypeName = "Public" }
        );

        modelBuilder.Entity<UserEntry>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userentry");

            entity.Property(e => e.PublicKeyId).HasColumnName("publickeyid");
            entity.Property(e => e.UserEntryId).HasColumnName("userentryid");

            entity.HasOne(d => d.PublicKey).WithMany()
                .HasForeignKey(d => d.PublicKeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userentry_publickeyid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
