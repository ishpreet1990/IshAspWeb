using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MyAspCoreProject.Models;

namespace MyAspCoreProject.Migrations
{
    [DbContext(typeof(SerialContext))]
    [Migration("20170413115336_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyAspCoreProject.Models.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SerailId");

                    b.Property<int?>("SerialId");

                    b.Property<string>("Title");

                    b.HasKey("EpisodeId");

                    b.HasIndex("SerialId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("MyAspCoreProject.Models.Serial", b =>
                {
                    b.Property<int>("SerialId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SerialName");

                    b.HasKey("SerialId");

                    b.ToTable("Serials");
                });

            modelBuilder.Entity("MyAspCoreProject.Models.Episode", b =>
                {
                    b.HasOne("MyAspCoreProject.Models.Serial", "Serial")
                        .WithMany("Episodes")
                        .HasForeignKey("SerialId");
                });
        }
    }
}
