// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StateTaxDbContext))]
    [Migration("20210615194110_Add_JurisdictionFIPSCode_Column")]
    partial class Add_JurisdictionFIPSCode_Column
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("Domain.Entities.CountyTaxRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CountyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FoodDrugInterstateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FoodDrugIntrastateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GeneralInterstateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GeneralIntrastateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JurisdictionFIPSCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("CountyTaxRates");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Domain.Entities.StateTaxRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FoodDrugInterstateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FoodDrugIntrastateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GeneralInterstateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GeneralIntrastateRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("StateTaxRates");
                });

            modelBuilder.Entity("Domain.Entities.CountyTaxRate", b =>
                {
                    b.HasOne("Domain.Entities.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyId");

                    b.Navigation("County");
                });

            modelBuilder.Entity("Domain.Entities.StateTaxRate", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
