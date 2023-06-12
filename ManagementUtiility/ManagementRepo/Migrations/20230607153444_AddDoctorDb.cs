using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementRepo.Migrations
{
    public partial class AddDoctorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Facilities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "CompanyInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

           

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facilities_CompanyInfos_CompanyId",
                table: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Facilities_CompanyId",
                table: "Facilities");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "City",
                table: "CompanyInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CompanyId1",
                table: "Facilities",
                column: "CompanyId1");

           
        }
    }
}
