﻿// <auto-generated />
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20180331150053_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidade.Fornecedor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14);

                    b.Property<string>("InscricaoMunicipal")
                        .HasMaxLength(50);

                    b.Property<string>("RazaoSocial")
                        .HasMaxLength(100);

                    b.Property<decimal>("ReceitaBruta");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
