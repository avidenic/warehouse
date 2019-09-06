using Microsoft.EntityFrameworkCore.Migrations;

namespace NiceLabel.Demo.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: true),
                    Quantity = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name0", "FA669F95DC83CCD9400FC939A68666720033D5859860F76EDCD892E95AFB9CC7", 0L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name1", "19513FDC9DA4FB72A4A05EB66917548D3C90FF94D5419E1F2363EEA89DFEE1DD", 1L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name2", "1BE0222750AAF3889AB95B5D593BA12E4FF1046474702D6B4779F4B527305B23", 2L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name3", "2538F153F36161C45C3C90AFAA3F9CCC5B0FA5554C7C582EFE67193ABB2D5202", 3L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name4", "DB514F5B3285ACAA1AD28290F5FEFC38F2761A1F297B1D24F8129DD64638825D", 4L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name5", "8180D5783FEA9F86479E748F6D2D1196C4A8E143643119398C16367D2C3D50F2", 5L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name6", "75F9793A7639FAA0B83A2707D60CB21C42FE9F50992FC692390A26AC2A21B29E", 6L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name7", "5BFDFAAF7E1B1244192A1EDE1EA70F09F5642190821C0005669A9AFBCA2DEE2E", 7L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name8", "2CED6E7160A9E2CB4BE29C200852BFC4FE29D7531FF3FFC51FC1407399D8D8B8", 8L });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Password", "Quantity" },
                values: new object[] { "Name9", "B949A64FD5484E69191EFB60D83F7F79195EEB2911C3EB5850AF160841211F18", 9L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
