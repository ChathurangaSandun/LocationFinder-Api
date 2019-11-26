using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LocationFinder.Api.DataModels
{
    public partial class PaperGeneration_TESTContext : DbContext
    {
        public PaperGeneration_TESTContext()
        {
        }

        public PaperGeneration_TESTContext(DbContextOptions<PaperGeneration_TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonalLocations> PersonalLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:papergenerationtest.database.windows.net,1433;Initial Catalog=PaperGeneration_TEST;Persist Security Info=False;User ID=pamba;Password=Ringer#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<PersonalLocations>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ImageUrl).HasMaxLength(4000);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("Mobile_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
