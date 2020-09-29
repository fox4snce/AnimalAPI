using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Character> Characters { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        // Breeding records models
        public DbSet<BreedingRecord> BreedingRecords { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<CoatType> CoatTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Litter> Litters { get; set; }
        public DbSet<Species> AllSpecies { get; set; }
        public DbSet<Variety> Varieties { get; set; }
        public DbSet<ParentRecord> ParentRecords { get; set; }
        public DbSet<SiblingRecord> SiblingRecords { get; set; }

        public DbSet<BreedingRecordNote> BreedingRecordNotes { get; set; }
        public DbSet<ContactNote> ContactNotes { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cs => new { cs.CharacterId, cs.SkillId });

           

            modelBuilder.Entity<ParentRecord>()
                .HasKey(pr => new { pr.ParentId, pr.LitterId });

            modelBuilder.Entity<SiblingRecord>()
                .HasKey(sr => new { sr.SiblingId, sr.LitterId });



        }
    }
}
