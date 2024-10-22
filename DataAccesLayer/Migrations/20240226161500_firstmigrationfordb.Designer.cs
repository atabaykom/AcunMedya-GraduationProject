﻿// <auto-generated />
using System;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240226161500_firstmigrationfordb")]
    partial class firstmigrationfordb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("ISACTIVE")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SURNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Content", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CATEGORYID")
                        .HasColumnType("int");

                    b.Property<string>("CITY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CONTENOWNERID")
                        .HasColumnType("int");

                    b.Property<string>("CONTENTFROM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CONTENTTYPE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("COUNTRY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CREATEDDATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("DESCRIPTION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISACTIVE")
                        .HasColumnType("bit");

                    b.Property<int>("NUMBEROFROOMS")
                        .HasColumnType("int");

                    b.Property<int>("PRICE")
                        .HasColumnType("int");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TOWN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CATEGORYID");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentAnswer", b =>
                {
                    b.Property<int>("ANSWERID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ANSWERID"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CONTENTID")
                        .HasColumnType("int");

                    b.Property<string>("DESCRIPTION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("USERID")
                        .HasColumnType("int");

                    b.HasKey("ANSWERID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CONTENTID");

                    b.ToTable("ContentAnswers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentCategory", b =>
                {
                    b.Property<int>("CATEGORYID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CATEGORYID"));

                    b.Property<string>("CATNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISACTIVE")
                        .HasColumnType("bit");

                    b.HasKey("CATEGORYID");

                    b.ToTable("ContentCategories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentInteraction", b =>
                {
                    b.Property<int>("INTERACTIONID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("INTERACTIONID"));

                    b.Property<int>("CONTENTID")
                        .HasColumnType("int");

                    b.Property<int>("FAVORITECOUNT")
                        .HasColumnType("int");

                    b.Property<int>("VIEWCOUNT")
                        .HasColumnType("int");

                    b.HasKey("INTERACTIONID");

                    b.HasIndex("CONTENTID");

                    b.ToTable("ContentInteractions");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentQuestion", b =>
                {
                    b.Property<int>("QUESTIONID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QUESTIONID"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CONTENTID")
                        .HasColumnType("int");

                    b.Property<string>("DESCRIPTION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("USERID")
                        .HasColumnType("int");

                    b.HasKey("QUESTIONID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CONTENTID");

                    b.ToTable("ContentQuestions");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentTagMap", b =>
                {
                    b.Property<int>("MAPID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MAPID"));

                    b.Property<int>("CONTENTID")
                        .HasColumnType("int");

                    b.Property<int>("TAGID")
                        .HasColumnType("int");

                    b.HasKey("MAPID");

                    b.HasIndex("CONTENTID");

                    b.HasIndex("TAGID");

                    b.ToTable("ContentTagMaps");
                });

            modelBuilder.Entity("EntityLayer.Concrete.FırmDoc", b =>
                {
                    b.Property<int>("IMGID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IMGID"));

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("CONTENTID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<byte[]>("IMGDATA")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IMGID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CONTENTID");

                    b.ToTable("FirmDocs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message", b =>
                {
                    b.Property<int>("MESSAGEID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MESSAGEID"));

                    b.Property<string>("CONTENT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("RECEIVERMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RECEIVERNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SENDERMAIL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SENDERNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("MESSAGEID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Notification", b =>
                {
                    b.Property<int>("EMAILQUEUEID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EMAILQUEUEID"));

                    b.Property<string>("BODY")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ISDELIVERED")
                        .HasColumnType("bit");

                    b.Property<int>("LASTRERYDATE")
                        .HasColumnType("int");

                    b.Property<int>("RETRYCOUNT")
                        .HasColumnType("int");

                    b.Property<int>("STATUS")
                        .HasColumnType("int");

                    b.Property<string>("SUBJECT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TOADRESS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EMAILQUEUEID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Tag", b =>
                {
                    b.Property<int>("TAGID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TAGID"));

                    b.Property<bool>("ISACTIVE")
                        .HasColumnType("bit");

                    b.Property<string>("TAGNAME")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TAGID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Content", b =>
                {
                    b.HasOne("EntityLayer.Concrete.ContentCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CATEGORYID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentAnswer", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Content", "Content")
                        .WithMany()
                        .HasForeignKey("CONTENTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentInteraction", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Content", "Content")
                        .WithMany()
                        .HasForeignKey("CONTENTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentQuestion", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Content", "Content")
                        .WithMany()
                        .HasForeignKey("CONTENTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContentTagMap", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Content", "Content")
                        .WithMany()
                        .HasForeignKey("CONTENTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TAGID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("EntityLayer.Concrete.FırmDoc", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Content", "Content")
                        .WithMany()
                        .HasForeignKey("CONTENTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
