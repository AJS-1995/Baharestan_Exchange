using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_DailyRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MainMoneyId = table.Column<int>(type: "int", nullable: false),
                    PriceBey = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceSell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondaryMoneyId = table.Column<int>(type: "int", nullable: false),
                    DateDay = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DailyRates", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "SaveDate" },
                values: new object[] { "روپیه پاکستان", "1402/10/19 06:46:13" });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "SaveDate" },
                values: new object[] { "روپیه هندی", "1402/10/19 06:46:13" });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/19 06:46:13");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_DailyRates");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "SaveDate" },
                values: new object[] { "روپیه", "1402/10/06 06:50:55" });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "SaveDate" },
                values: new object[] { "روپیه", "1402/10/06 06:50:55" });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/06 06:50:55");
        }
    }
}
