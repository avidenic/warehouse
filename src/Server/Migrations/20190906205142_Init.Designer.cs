﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceLabel.Demo.Server;

namespace NiceLabel.Demo.Server.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20190906205142_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview9.19423.6");

            modelBuilder.Entity("NiceLabel.Demo.Server.Models.Customer", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500);

                    b.Property<string>("Password")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<long>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Name = "Name0",
                            Password = "FA669F95DC83CCD9400FC939A68666720033D5859860F76EDCD892E95AFB9CC7",
                            Quantity = 0L
                        },
                        new
                        {
                            Name = "Name1",
                            Password = "19513FDC9DA4FB72A4A05EB66917548D3C90FF94D5419E1F2363EEA89DFEE1DD",
                            Quantity = 1L
                        },
                        new
                        {
                            Name = "Name2",
                            Password = "1BE0222750AAF3889AB95B5D593BA12E4FF1046474702D6B4779F4B527305B23",
                            Quantity = 2L
                        },
                        new
                        {
                            Name = "Name3",
                            Password = "2538F153F36161C45C3C90AFAA3F9CCC5B0FA5554C7C582EFE67193ABB2D5202",
                            Quantity = 3L
                        },
                        new
                        {
                            Name = "Name4",
                            Password = "DB514F5B3285ACAA1AD28290F5FEFC38F2761A1F297B1D24F8129DD64638825D",
                            Quantity = 4L
                        },
                        new
                        {
                            Name = "Name5",
                            Password = "8180D5783FEA9F86479E748F6D2D1196C4A8E143643119398C16367D2C3D50F2",
                            Quantity = 5L
                        },
                        new
                        {
                            Name = "Name6",
                            Password = "75F9793A7639FAA0B83A2707D60CB21C42FE9F50992FC692390A26AC2A21B29E",
                            Quantity = 6L
                        },
                        new
                        {
                            Name = "Name7",
                            Password = "5BFDFAAF7E1B1244192A1EDE1EA70F09F5642190821C0005669A9AFBCA2DEE2E",
                            Quantity = 7L
                        },
                        new
                        {
                            Name = "Name8",
                            Password = "2CED6E7160A9E2CB4BE29C200852BFC4FE29D7531FF3FFC51FC1407399D8D8B8",
                            Quantity = 8L
                        },
                        new
                        {
                            Name = "Name9",
                            Password = "B949A64FD5484E69191EFB60D83F7F79195EEB2911C3EB5850AF160841211F18",
                            Quantity = 9L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
