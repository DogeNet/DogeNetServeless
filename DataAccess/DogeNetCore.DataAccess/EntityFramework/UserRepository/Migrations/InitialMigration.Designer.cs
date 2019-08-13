using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Entities;

namespace DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20161007150914_InitialMigration")]
    public partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DogeCore.Entities.Users.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Username")
                    .IsRequired()
                    .HasAnnotation("MaxLength", 24);

                b.Property<int>("Score")
                    .IsRequired();

                b.HasKey("Id");
                b.HasAlternateKey("Username");

                b.ToTable("Users");
            });

        }
    }
}
