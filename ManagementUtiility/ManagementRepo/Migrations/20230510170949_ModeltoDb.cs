using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementRepo.Migrations
{
    public partial class ModeltoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedParts_PublicReport_PublicReportId",
                table: "PrescribedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicReport_AspNetUsers_PublicId",
                table: "PublicReport");


            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicReport",
                table: "PublicReport");

            migrationBuilder.DropIndex(
                name: "IX_PublicReport_PublicId",
                table: "PublicReport");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "PublicReport");

            migrationBuilder.RenameTable(
                name: "PublicReport",
                newName: "PublicReports");

            migrationBuilder.RenameIndex(
                name: "IX_PublicReport_UserId",
                table: "PublicReports",
                newName: "IX_PublicReports_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PublicReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicReports",
                table: "PublicReports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TestPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestPrices_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestPrices_Labs_LabId",
                        column: x => x.LabId,
                        principalTable: "Labs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestPrices_BillId",
                table: "TestPrices",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_TestPrices_LabId",
                table: "TestPrices",
                column: "LabId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedParts_PublicReports_PublicReportId",
                table: "PrescribedParts",
                column: "PublicReportId",
                principalTable: "PublicReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicReports_AspNetUsers_UserId",
                table: "PublicReports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedParts_PublicReports_PublicReportId",
                table: "PrescribedParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicReports_AspNetUsers_UserId",
                table: "PublicReports");

            migrationBuilder.DropTable(
                name: "TestPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicReports",
                table: "PublicReports");

            migrationBuilder.RenameTable(
                name: "PublicReports",
                newName: "PublicReport");

            migrationBuilder.RenameIndex(
                name: "IX_PublicReports_UserId",
                table: "PublicReport",
                newName: "IX_PublicReport_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PublicReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "PublicReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicReport",
                table: "PublicReport",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PublicReport_PublicId",
                table: "PublicReport",
                column: "PublicId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedParts_PublicReport_PublicReportId",
                table: "PrescribedParts",
                column: "PublicReportId",
                principalTable: "PublicReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicReport_AspNetUsers_PublicId",
                table: "PublicReport",
                column: "PublicId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicReport_AspNetUsers_UserId",
                table: "PublicReport",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
