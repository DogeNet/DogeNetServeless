using System;
using DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DogeNetCore.DataAccess.lib.implementations.EntityFramework.UserRepository.Migrations
{
    [DbContext(typeof(UserContext))]
    public class UsersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
