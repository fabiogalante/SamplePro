using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SamplePro.Models;

namespace SamplePro.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20170901230852_AppV2")]
    partial class AppV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SamplePro.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<DateTime>("CreatedDate");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SamplePro.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoriesId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("PostImage");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SamplePro.Models.Post", b =>
                {
                    b.HasOne("SamplePro.Models.Category", "Categories")
                        .WithMany("Posts")
                        .HasForeignKey("CategoriesId");
                });
        }
    }
}
