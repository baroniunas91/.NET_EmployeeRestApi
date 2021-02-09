using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeTask.RestApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BossId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_BossId",
                        column: x => x.BossId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "BossId", "CurrentSalary", "EmploymentDate", "FirstName", "HomeAddress", "LastName", "Role" },
                values: new object[] { 1, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5000m, new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominick", "Vilnius, Ozo g. 30", "Crouch", "CEO" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "BossId", "CurrentSalary", "EmploymentDate", "FirstName", "HomeAddress", "LastName", "Role" },
                values: new object[] { 2, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3000m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Vilnius, Ozo g. 30", "Crouch", "Project Manager" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthdate", "BossId", "CurrentSalary", "EmploymentDate", "FirstName", "HomeAddress", "LastName", "Role" },
                values: new object[,]
                {
                    { 3, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000m, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donny", "Vilnius, Ozo g. 30", "Crouch", ".NET developer" },
                    { 4, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000m, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rick", "Vilnius, Ozo g. 30", "Crouch", ".NET developer" },
                    { 5, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Vilnius, Ozo g. 30", "Crouch", ".NET developer" },
                    { 6, new DateTime(1991, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000m, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodger", "Vilnius, Ozo g. 30", "Crouch", ".NET developer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BossId",
                table: "Employees",
                column: "BossId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
