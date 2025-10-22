using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePlog.Api.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialMigrationAuthEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b05afbe2-71a2-4915-94e4-ab8552877133",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88cd145f-bc43-4134-8d48-b230ea898f9e", "AQAAAAIAAYagAAAAEBaSTOM0VBTIc8T0FdBCSN7pFgR+IXJ2Wkzt0rbf8ap/QuwMa6hYPeRnMX9dy01Lrw==", "38e22768-bc56-462f-843f-001ca4106eaa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b05afbe2-71a2-4915-94e4-ab8552877133",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2401842f-383b-4b84-9d55-d1948c4410e3", "AQAAAAIAAYagAAAAEFJMxfsTAEG7aOW4RdM+xslveDK6a6NN8Eo7kkuf+xaZZnh9YIKee9LfiJvBuIyR/g==", "05baa973-2d6c-4bfa-9d45-716529bd92c7" });
        }
    }
}
