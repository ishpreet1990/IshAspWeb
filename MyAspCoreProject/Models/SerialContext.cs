using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyAspCoreProject.Models
{
    public partial class SerialContext : DbContext
    {
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Serial> Serials { get; set; }

        //  public SerialContext(DbContextOptions<SerialContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=CURSISTE02\SQLEXPRESS;Database=Serial;Trusted_Connection=True;");
        }
        public SerialContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>(entity =>
            {
                entity.HasKey(e => e.EpisodeId)
                    .HasName("PK_Episodes");

                entity.HasIndex(e => e.SerialId)
                    .HasName("IX_Episodes_SerialId");

                entity.HasOne(d => d.Serial)
                    .WithMany(p => p.Episode)
                    .HasForeignKey(d => d.SerialId);
            });

            modelBuilder.Entity<Serial>(entity =>
            {
                entity.HasKey(e => e.SerialId)
                    .HasName("PK_Serials");
            });
        }
    }
}