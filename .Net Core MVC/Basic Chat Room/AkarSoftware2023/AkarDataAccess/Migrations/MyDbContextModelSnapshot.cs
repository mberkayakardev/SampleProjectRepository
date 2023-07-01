﻿// <auto-generated />
using System;
using AkarDataAccess.Concrete.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AkarDataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AkarEntities.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GecerliFlg")
                        .HasColumnType("bit");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublicOrPrivate")
                        .HasColumnType("bit");

                    b.Property<int>("MaxUserCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("AkarEntities.Entities.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GecerliFlg")
                        .HasColumnType("bit");

                    b.Property<int?>("GruoupId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OneTimeUsableToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GruoupId");

                    b.HasIndex("PersonId");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("AkarEntities.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GecerliFlg")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(3389),
                            CreateUser = "BERKAY AKAR",
                            GecerliFlg = true,
                            ModDate = new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(5182),
                            ModUser = "BERKAY AKAR",
                            Password = "mberkayakar",
                            UserName = "mberkayakar",
                            UserPhoto = "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(6184),
                            CreateUser = "BERKAY AKAR",
                            GecerliFlg = true,
                            ModDate = new DateTime(2023, 4, 23, 1, 28, 31, 116, DateTimeKind.Local).AddTicks(6187),
                            ModUser = "BERKAY AKAR",
                            Password = "atelyon",
                            UserName = "atelyon",
                            UserPhoto = "https://media.licdn.com/dms/image/C4D03AQH0lx3tESYC7w/profile-displayphoto-shrink_800_800/0/1607277130794?e=2147483647&v=beta&t=mWbd1TIxwSp7B_vA_RkHuJi2tvdrMqAj9EvAyIntub0"
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("MembersListId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "MembersListId");

                    b.HasIndex("MembersListId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("AkarEntities.Entities.Token", b =>
                {
                    b.HasOne("AkarEntities.Entities.Group", "Gruoup")
                        .WithMany()
                        .HasForeignKey("GruoupId");

                    b.HasOne("AkarEntities.Entities.User", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Gruoup");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("AkarEntities.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AkarEntities.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("MembersListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
