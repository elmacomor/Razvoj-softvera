﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobitelShop.Data;

#nullable disable

namespace MobitelShop.Migrations
{
    [DbContext(typeof(MojDbContext))]
    [Migration("20230310192857_cijena")]
    partial class cijena
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MobitelShop.Models.Drzava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("MobitelShop.Models.Grad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("MobitelShop.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("MobitelShop.Models.KreditnaKartica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("SC")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("KreditnaKartica");
                });

            modelBuilder.Entity("MobitelShop.Models.Narudzba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DatumNarudzbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("RacunID")
                        .HasColumnType("int");

                    b.Property<int>("ShippingPodaciID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("RacunID");

                    b.HasIndex("ShippingPodaciID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("MobitelShop.Models.NarudzbaProizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("NarudzbaProizvod");
                });

            modelBuilder.Entity("MobitelShop.Models.OmiljeniProizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Aktivan")
                        .HasColumnType("bit");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("OmiljeniProizvod");
                });

            modelBuilder.Entity("MobitelShop.Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Cijena")
                        .HasColumnType("real");

                    b.Property<string>("KratakOpisProizvoda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProizvodTipID")
                        .HasColumnType("int");

                    b.Property<string>("Specifikacije")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ProizvodTipID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("MobitelShop.Models.ProizvodTip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProizvodTip");
                });

            modelBuilder.Entity("MobitelShop.Models.ProizvodVikendAkcija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<int>("VikendAkcijaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProizvodID");

                    b.HasIndex("VikendAkcijaID");

                    b.ToTable("ProizvodVikendAkcija");
                });

            modelBuilder.Entity("MobitelShop.Models.Racun", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IznosRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("KreditnaKarticaID")
                        .HasColumnType("int");

                    b.Property<string>("NacinPlacanja")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("KreditnaKarticaID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("MobitelShop.Models.Servis", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("NazivServisa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("cijena")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.ToTable("Servis");
                });

            modelBuilder.Entity("MobitelShop.Models.ShippingPodaci", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GradID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("ShippingPodaci");
                });

            modelBuilder.Entity("MobitelShop.Models.VikendAkcija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<string>("IznosPopusta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("VikendAkcija");
                });

            modelBuilder.Entity("MobitelShop.Models.Grad", b =>
                {
                    b.HasOne("MobitelShop.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("MobitelShop.Models.KreditnaKartica", b =>
                {
                    b.HasOne("MobitelShop.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("MobitelShop.Models.Narudzba", b =>
                {
                    b.HasOne("MobitelShop.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.Racun", "Racun")
                        .WithMany()
                        .HasForeignKey("RacunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.ShippingPodaci", "ShippingPodaci")
                        .WithMany()
                        .HasForeignKey("ShippingPodaciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Racun");

                    b.Navigation("ShippingPodaci");
                });

            modelBuilder.Entity("MobitelShop.Models.NarudzbaProizvod", b =>
                {
                    b.HasOne("MobitelShop.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("MobitelShop.Models.OmiljeniProizvod", b =>
                {
                    b.HasOne("MobitelShop.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("MobitelShop.Models.Proizvod", b =>
                {
                    b.HasOne("MobitelShop.Models.ProizvodTip", "ProizvodTip")
                        .WithMany()
                        .HasForeignKey("ProizvodTipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProizvodTip");
                });

            modelBuilder.Entity("MobitelShop.Models.ProizvodVikendAkcija", b =>
                {
                    b.HasOne("MobitelShop.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.VikendAkcija", "VikendAkcija")
                        .WithMany()
                        .HasForeignKey("VikendAkcijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("VikendAkcija");
                });

            modelBuilder.Entity("MobitelShop.Models.Racun", b =>
                {
                    b.HasOne("MobitelShop.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.KreditnaKartica", "KreditnaKartica")
                        .WithMany()
                        .HasForeignKey("KreditnaKarticaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KreditnaKartica");

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("MobitelShop.Models.Servis", b =>
                {
                    b.HasOne("MobitelShop.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("MobitelShop.Models.ShippingPodaci", b =>
                {
                    b.HasOne("MobitelShop.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobitelShop.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grad");

                    b.Navigation("Korisnik");
                });
#pragma warning restore 612, 618
        }
    }
}
