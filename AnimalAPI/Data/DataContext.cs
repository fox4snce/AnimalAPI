using AnimalAPI.Models;
using AnimalAPI.Models.Auth;
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

        public DbSet<User> Users { get; set; }
        public DbSet<BreedingRecord> BreedingRecords { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Litter> Litters { get; set; }
        public DbSet<ParentRecord> ParentRecords { get; set; }
        public DbSet<SiblingRecord> SiblingRecords { get; set; }
        //public DbSet<BreedingRecordNote> BreedingRecordNotes { get; set; }
        //public DbSet<ContactNote> ContactNotes { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<BreedingRecordCharacteristic> BreedingRecordCharacteristics { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentRecord>()
                .HasKey(pr => new { pr.ParentId, pr.LitterId });

            modelBuilder.Entity<SiblingRecord>()
                .HasKey(sr => new { sr.SiblingId, sr.LitterId });

            

            modelBuilder.Entity<BreedingRecordCharacteristic>()
                .HasKey(brc => new { brc.BreedingRecordId, brc.CharacteristicId });

            

            
                
        }
    }
}
