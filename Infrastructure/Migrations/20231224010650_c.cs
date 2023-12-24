using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class c : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MainMoneyId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondaryMoneyId = table.Column<int>(type: "int", nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ExchangeRates", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/03 05:36:48");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_ExchangeRates");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/02 19:06:22");
        }
    }
}
