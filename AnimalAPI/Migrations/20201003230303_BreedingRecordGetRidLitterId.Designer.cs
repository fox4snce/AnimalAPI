﻿// <auto-generated />
using System;
using AnimalAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201003230303_BreedingRecordGetRidLitterId")]
    partial class BreedingRecordGetRidLitterId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalAPI.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("longblob");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BirthLitterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("BreederId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAcquisition")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BirthLitterId");

                    b.HasIndex("BreederId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("BreedingRecords");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecordCharacteristic", b =>
                {
                    b.Property<int>("BreedingRecordId")
                        .HasColumnType("int");

                    b.Property<int>("CharacteristicId")
                        .HasColumnType("int");

                    b.HasKey("BreedingRecordId", "CharacteristicId");

                    b.HasIndex("CharacteristicId");

                    b.ToTable("BreedingRecordCharacteristics");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecordNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("BreedingRecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Medical")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreedingRecordId");

                    b.HasIndex("UserId");

                    b.ToTable("BreedingRecordNotes");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Characteristic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Feature")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("CellPhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Country")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.ContactNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Medical")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("ContactNotes");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Litter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BreederId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAcquisition")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreederId");

                    b.HasIndex("UserId");

                    b.ToTable("Litters");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.ParentRecord", b =>
                {
                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("LitterId")
                        .HasColumnType("int");

                    b.HasKey("ParentId", "LitterId");

                    b.HasIndex("LitterId");

                    b.ToTable("ParentRecords");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.SiblingRecord", b =>
                {
                    b.Property<int>("SiblingId")
                        .HasColumnType("int");

                    b.Property<int>("LitterId")
                        .HasColumnType("int");

                    b.HasKey("SiblingId", "LitterId");

                    b.HasIndex("LitterId");

                    b.ToTable("SiblingRecords");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecord", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Litter", "BirthLitter")
                        .WithMany()
                        .HasForeignKey("BirthLitterId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Breeder")
                        .WithMany()
                        .HasForeignKey("BreederId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecordCharacteristic", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", "BreedingRecord")
                        .WithMany("BreedingRecordCharacteristics")
                        .HasForeignKey("BreedingRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Breeding.Characteristic", "Characteristic")
                        .WithMany("BreedingRecordCharacteristics")
                        .HasForeignKey("CharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecordNote", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", null)
                        .WithMany("Notes")
                        .HasForeignKey("BreedingRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Characteristic", b =>
                {
                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Contact", b =>
                {
                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.ContactNote", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Contact")
                        .WithMany("Notes")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Litter", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Breeder")
                        .WithMany()
                        .HasForeignKey("BreederId");

                    b.HasOne("AnimalAPI.Models.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.ParentRecord", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Litter", "Litter")
                        .WithMany("Parents")
                        .HasForeignKey("LitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.SiblingRecord", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Litter", "Litter")
                        .WithMany("Siblings")
                        .HasForeignKey("LitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", "Sibling")
                        .WithMany()
                        .HasForeignKey("SiblingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
