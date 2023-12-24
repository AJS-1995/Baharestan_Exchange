using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tbl_Moneys",
                columns: new[] { "Id", "AgenciesId", "Country", "Deleted", "Name", "SaveDate", "Status", "Symbol", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "افغانستان", false, "افغانی", "1402/10/02 19:06:22", true, "؋", 1 },
                    { 2, 0, "ایالات متحده امریکا", false, "دلار", "1402/10/02 19:06:22", true, "$", 1 },
                    { 3, 0, "ایران", false, "تومان", "1402/10/02 19:06:22", true, "IRR", 1 },
                    { 4, 0, "پاکستان", false, "روپیه", "1402/10/02 19:06:22", true, "₨", 1 },
                    { 5, 0, "هندوستان", false, "روپیه", "1402/10/02 19:06:22", true, "₹", 1 },
                    { 6, 0, "اروپا", false, "یورو", "1402/10/02 19:06:22", true, "€", 1 },
                    { 7, 0, "بریتانیا", false, "پوند", "1402/10/02 19:06:22", true, "£", 1 },
                    { 8, 0, "چین", false, "یوآن", "1402/10/02 19:06:22", true, "¥", 1 },
                    { 9, 0, "ترکیه", false, "لیره", "1402/10/02 19:06:22", true, "₺", 1 },
                    { 10, 0, "روسیه", false, "روبل", "1402/10/02 19:06:22", true, "₽", 1 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/02 02:45:33");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/02 02:45:33");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/02 02:45:33");
        }
    }
}
