using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Regon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestorationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasVirtualAccounts = table.Column<bool>(type: "bit", nullable: true),
                    StatusVat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Krs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestorationBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDenialBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationLegalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovalBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDenialDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Representative",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representative_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_CompanyId",
                table: "BankAccount",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Representative_CompanyId",
                table: "Representative",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Representative");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
