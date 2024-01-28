using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PersonsReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_PersonsReceipts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SafeBoxId = table.Column<int>(type: "int", nullable: false),
                    MoneyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonssId = table.Column<int>(type: "int", nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PersonsReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_PersonsReceipts_Tbl_Persons_PersonssId",
                        column: x => x.PersonssId,
                        principalTable: "Tbl_Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/11/04 - 21:19:25");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PersonsReceipts_PersonssId",
                table: "Tbl_PersonsReceipts",
                column: "PersonssId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_PersonsReceipts");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/10/22 - 07:29:50");
        }
    }
}
