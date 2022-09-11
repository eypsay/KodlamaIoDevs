using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class son : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId)", "ProgrammingLanguageId", "Version" },
                values: new object[,]
                {
                    { 1, "SpringBoot", 1, null, "1.0" },
                    { 2, "Hibernate", 1, null, "2.0" },
                    { 3, "React", 2, null, "1.0" },
                    { 4, "NodeJs", 2, null, "2.0" },
                    { 5, "WPF", 3, null, "1.0" },
                    { 6, "ASP.NET", 3, null, "2.0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubTechnologies",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
