using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyAspCoreProject.Models;

namespace MyAspCoreProject.Migrations
{
    [DbContext(typeof(SerialContext))]
    partial class SerialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyAspCoreProject.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EpisodeNumber");

                    b.Property<int>("SerialId");

                    b.HasKey("EpisodeId")
                        .HasName("PK_Episodes");

                    b.HasIndex("SerialId")
                        .HasName("IX_Episodes_SerialId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("MyAspCoreProject.Models.Serial", b =>
                {
                    b.Property<int>("SerialId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("SerialName");

                    b.Property<DateTime>("SerialTime");

                    b.HasKey("SerialId")
                        .HasName("PK_Serials");

                    b.ToTable("Serials");
                });

            modelBuilder.Entity("MyAspCoreProject.Models.Episode", b =>
                {
                    b.HasOne("MyAspCoreProject.Models.Serial", "Serial")
                        .WithMany("Episode")
                        .HasForeignKey("SerialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
