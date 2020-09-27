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
    [Migration("20200925224932_FixThePoorParentsAndLitters")]
    partial class FixThePoorParentsAndLitters
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<int?>("BreederId")
                        .HasColumnType("int");

                    b.Property<int?>("CoatTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfAcquisition")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LitterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<bool>("Public")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VarietyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("BreederId");

                    b.HasIndex("CoatTypeId");

                    b.HasIndex("ColorId");

                    b.HasIndex("LitterId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UserId");

                    b.HasIndex("VarietyId");

                    b.ToTable("BreedingRecords");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.CoatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CoatTypes");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Colors");
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

            modelBuilder.Entity("AnimalAPI.Models.Breeding.MedicalNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("BreedingRecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VeterinarianId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreedingRecordId");

                    b.HasIndex("UserId");

                    b.HasIndex("VeterinarianId");

                    b.ToTable("MedicalNotes");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("BreedingRecordId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Edited")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreedingRecordId");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
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

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AllSpecies");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Variety", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Varieties");
                });

            modelBuilder.Entity("AnimalAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Fights")
                        .HasColumnType("int");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("AnimalAPI.Models.CharacterSkill", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("AnimalAPI.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("AnimalAPI.Models.User", b =>
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

            modelBuilder.Entity("AnimalAPI.Models.Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId")
                        .IsUnique();

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Breed", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.BreedingRecord", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Breed", "Breed")
                        .WithMany()
                        .HasForeignKey("BreedId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Breeder")
                        .WithMany()
                        .HasForeignKey("BreederId");

                    b.HasOne("AnimalAPI.Models.Breeding.CoatType", "CoatType")
                        .WithMany()
                        .HasForeignKey("CoatTypeId");

                    b.HasOne("AnimalAPI.Models.Breeding.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId");

                    b.HasOne("AnimalAPI.Models.Breeding.Litter", "Litter")
                        .WithMany()
                        .HasForeignKey("LitterId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("AnimalAPI.Models.Breeding.Species", "Species")
                        .WithMany()
                        .HasForeignKey("SpeciesId");

                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("AnimalAPI.Models.Breeding.Variety", "Variety")
                        .WithMany()
                        .HasForeignKey("VarietyId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.CoatType", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Contact", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Litter", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Breeder")
                        .WithMany()
                        .HasForeignKey("BreederId");

                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.MedicalNote", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", null)
                        .WithMany("MedicalNotes")
                        .HasForeignKey("BreedingRecordId");

                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", "Veterinarian")
                        .WithMany()
                        .HasForeignKey("VeterinarianId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Note", b =>
                {
                    b.HasOne("AnimalAPI.Models.Breeding.BreedingRecord", null)
                        .WithMany("Notes")
                        .HasForeignKey("BreedingRecordId");

                    b.HasOne("AnimalAPI.Models.Breeding.Contact", null)
                        .WithMany("Notes")
                        .HasForeignKey("ContactId");

                    b.HasOne("AnimalAPI.Models.User", "User")
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

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Species", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Breeding.Variety", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.Character", b =>
                {
                    b.HasOne("AnimalAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AnimalAPI.Models.CharacterSkill", b =>
                {
                    b.HasOne("AnimalAPI.Models.Character", "Character")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalAPI.Models.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalAPI.Models.Weapon", b =>
                {
                    b.HasOne("AnimalAPI.Models.Character", "Character")
                        .WithOne("Weapon")
                        .HasForeignKey("AnimalAPI.Models.Weapon", "CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
