using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BabyStoreCore.Models;

namespace BabyStoreCore.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20160628131859_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BabyStoreCore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BabyStoreCore.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BabyStoreCore.Models.Product", b =>
                {
                    b.HasOne("BabyStoreCore.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });
        }
    }
}
