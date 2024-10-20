﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test_fluent_api;

#nullable disable

namespace test_fluent_api.Migrations
{
    [DbContext(typeof(LoginContext))]
    partial class LoginContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test_fluent_api.Models.Credential", b =>
                {
                    b.Property<long>("IdCredentials")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCredentials"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("IdCredentials");

                    b.ToTable("Credential", null, t =>
                        {
                            t.HasCheckConstraint("CK_Email_IsValid", "Email LIKE '%@%'");
                        });
                });

            modelBuilder.Entity("test_fluent_api.Models.Person", b =>
                {
                    b.Property<long>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdPerson"));

                    b.Property<DateTime>("BirthdayPerson")
                        .HasColumnType("date");

                    b.Property<long>("Document")
                        .HasMaxLength(10)
                        .HasColumnType("bigint");

                    b.Property<long>("IdCredencial")
                        .HasColumnType("bigint");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("LastNamePerson")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NamePerson")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecondNamePerson")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdPerson");

                    b.HasIndex("IdCredencial");

                    b.HasIndex("IdRol");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("test_fluent_api.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("NameRol")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("test_fluent_api.Models.Person", b =>
                {
                    b.HasOne("test_fluent_api.Models.Credential", "Credentials")
                        .WithMany("Credentials")
                        .HasForeignKey("IdCredencial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test_fluent_api.Models.Rol", "Rols")
                        .WithMany("Persons")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credentials");

                    b.Navigation("Rols");
                });

            modelBuilder.Entity("test_fluent_api.Models.Credential", b =>
                {
                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("test_fluent_api.Models.Rol", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
