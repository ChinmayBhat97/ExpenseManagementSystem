using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseManagementSystem.Migrations
{
    public partial class InitForDeptnClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalClaims",
                columns: table => new
                {
                    claimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claimantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    claimantEmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false),
                    managerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    managerEmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accuntNumber = table.Column<long>(type: "bigint", nullable: false),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    billingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    claimingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalClaims", x => x.claimID);
                    table.ForeignKey(
                        name: "FK_PersonalClaims_Departments_DeptID",
                        column: x => x.DeptID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalClaims_DeptID",
                table: "PersonalClaims",
                column: "DeptID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
