using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MsCompany.Migrations
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
                    SerieNFCE = table.Column<string>(nullable: true),
                    TokenNFCE = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: false),
                    ZFirstName = table.Column<string>(nullable: true),
                    ZLastName = table.Column<string>(nullable: true),
                    ZEmail = table.Column<string>(nullable: true),
                    ZPhoneNumber = table.Column<string>(nullable: true),
                    ZTaxpayerId = table.Column<string>(nullable: true),
                    ZBirthdate = table.Column<string>(nullable: true),
                    ZId = table.Column<string>(nullable: true),
                    ZStatus = table.Column<string>(nullable: true),
                    ZResource = table.Column<string>(nullable: true),
                    ZType = table.Column<string>(nullable: true),
                    ZAccount_balance = table.Column<int>(nullable: false),
                    ZCurrent_balance = table.Column<int>(nullable: false),
                    ZFiscal_responsibility = table.Column<string>(nullable: true),
                    ZStatement_descriptor = table.Column<string>(nullable: true),
                    ZDescription = table.Column<string>(nullable: true),
                    ZDelinquent = table.Column<bool>(nullable: false),
                    ZDefault_debit = table.Column<string>(nullable: true),
                    ZDefault_credit = table.Column<string>(nullable: true),
                    ZMcc = table.Column<string>(nullable: true),
                    ZEin = table.Column<string>(nullable: true),
                    ZBusiness_opening_date = table.Column<string>(nullable: true),
                    ZMetadata = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
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
                    DateDeleted = table.Column<DateTime>(nullable: false),
                    CompanyId1 = table.Column<int>(nullable: true),
                    CompanyId2 = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyAddress_Company_CompanyId2",
                        column: x => x.CompanyId2,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
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
                    type = table.Column<bool>(nullable: false),
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
                name: "IX_CompanyAddress_CompanyId1",
                table: "CompanyAddress",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddress_CompanyId2",
                table: "CompanyAddress",
                column: "CompanyId2");

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
