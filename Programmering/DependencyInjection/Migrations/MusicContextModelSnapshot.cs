﻿// <auto-generated />
using System;
using MusicStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MusicStore.Migrations
{
    [DbContext(typeof(MusicContext))]
    partial class MusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DependencyInjection.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlbumArtUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("DependencyInjection.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("DependencyInjection.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("DependencyInjection.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("DependencyInjection.Models.Album", b =>
                {
                    b.HasOne("DependencyInjection.Models.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId");

                    b.HasOne("DependencyInjection.Models.Genre", "Genre")
                        .WithMany("Albums")
                        .HasForeignKey("GenreId");

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("DependencyInjection.Models.Song", b =>
                {
                    b.HasOne("DependencyInjection.Models.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("DependencyInjection.Models.Album", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("DependencyInjection.Models.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("DependencyInjection.Models.Genre", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}
