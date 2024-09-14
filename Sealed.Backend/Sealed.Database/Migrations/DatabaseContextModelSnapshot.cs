﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sealed.Database;

#nullable disable

namespace Sealed.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sealed.Database.Models.Key", b =>
                {
                    b.Property<long>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("keyid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("KeyId"));

                    b.Property<int>("KeyTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("keytypeid");

                    b.HasKey("KeyId")
                        .HasName("key_pkey");

                    b.HasIndex("KeyTypeId");

                    b.ToTable("key", (string)null);
                });

            modelBuilder.Entity("Sealed.Database.Models.KeyPair", b =>
                {
                    b.Property<long>("PrivateKeyId")
                        .HasColumnType("bigint")
                        .HasColumnName("privatekeyid");

                    b.Property<long>("PublicKeyId")
                        .HasColumnType("bigint")
                        .HasColumnName("publickeyid");

                    b.HasIndex("PrivateKeyId");

                    b.HasIndex("PublicKeyId");

                    b.ToTable("keypair", (string)null);
                });

            modelBuilder.Entity("Sealed.Database.Models.KeyType", b =>
                {
                    b.Property<int>("KeyTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("keytypeid");

                    b.Property<string>("KeyTypeName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("keytypename");

                    b.HasKey("KeyTypeId")
                        .HasName("keytype_pkey");

                    b.ToTable("keytype", (string)null);

                    b.HasData(
                        new
                        {
                            KeyTypeId = 1,
                            KeyTypeName = "Private"
                        },
                        new
                        {
                            KeyTypeId = 2,
                            KeyTypeName = "Public"
                        });
                });

            modelBuilder.Entity("Sealed.Database.Models.UserEntry", b =>
                {
                    b.Property<long>("PublicKeyId")
                        .HasColumnType("bigint")
                        .HasColumnName("publickeyid");

                    b.Property<long>("UserEntryId")
                        .HasColumnType("bigint")
                        .HasColumnName("userentryid");

                    b.HasIndex("PublicKeyId");

                    b.ToTable("userentry", (string)null);
                });

            modelBuilder.Entity("Sealed.Database.Models.Key", b =>
                {
                    b.HasOne("Sealed.Database.Models.KeyType", "KeyType")
                        .WithMany("Keys")
                        .HasForeignKey("KeyTypeId")
                        .IsRequired()
                        .HasConstraintName("key_keytypeid_fkey");

                    b.Navigation("KeyType");
                });

            modelBuilder.Entity("Sealed.Database.Models.KeyPair", b =>
                {
                    b.HasOne("Sealed.Database.Models.Key", "PrivateKey")
                        .WithMany()
                        .HasForeignKey("PrivateKeyId")
                        .IsRequired()
                        .HasConstraintName("keypair_privatekeyid_fkey");

                    b.HasOne("Sealed.Database.Models.Key", "PublicKey")
                        .WithMany()
                        .HasForeignKey("PublicKeyId")
                        .IsRequired()
                        .HasConstraintName("keypair_publickeyid_fkey");

                    b.Navigation("PrivateKey");

                    b.Navigation("PublicKey");
                });

            modelBuilder.Entity("Sealed.Database.Models.UserEntry", b =>
                {
                    b.HasOne("Sealed.Database.Models.Key", "PublicKey")
                        .WithMany()
                        .HasForeignKey("PublicKeyId")
                        .IsRequired()
                        .HasConstraintName("userentry_publickeyid_fkey");

                    b.Navigation("PublicKey");
                });

            modelBuilder.Entity("Sealed.Database.Models.KeyType", b =>
                {
                    b.Navigation("Keys");
                });
#pragma warning restore 612, 618
        }
    }
}
