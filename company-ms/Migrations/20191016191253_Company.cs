using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MsCompany.Core.Migrations
{
    public partial class Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessName = table.Column<string>(nullable: true),
                    FictitiousName = table.Column<string>(nullable: true),
                    CnpjCpf = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MEI = table.Column<string>(nullable: true),
                    SerieNfce = table.Column<string>(nullable: true),
                    TokenNfce = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddress",
                columns: table => new
                {
                    CompanyAddressId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Observation = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    CompanyType = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddress", x => x.CompanyAddressId);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyParams",
                columns: table => new
                {
                    CompanyParamsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    NameIntegration = table.Column<string>(nullable: true),
                    Type = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyParams", x => x.CompanyParamsId);
                    table.ForeignKey(
                        name: "FK_CompanyParams_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CnpjCpf",
                table: "Company",
                column: "CnpjCpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyId",
                table: "CompanyAddress",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyParams_CompanyId",
                table: "CompanyParams",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAddress");

            migrationBuilder.DropTable(
                name: "CompanyParams");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
