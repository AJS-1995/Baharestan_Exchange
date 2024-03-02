using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_LivelihoodMonths",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Month = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    LivelihoodId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoneyId = table.Column<int>(type: "int", nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_LivelihoodMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_LivelihoodMonths_Tbl_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Tbl_Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_LivelihoodMonths_Tbl_Livelihoods_LivelihoodId",
                        column: x => x.LivelihoodId,
                        principalTable: "Tbl_Livelihoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/12/11 - 05:18:49");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LivelihoodMonths_AgenciesId",
                table: "Tbl_LivelihoodMonths",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_LivelihoodMonths_LivelihoodId",
                table: "Tbl_LivelihoodMonths",
                column: "LivelihoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_LivelihoodMonths");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 4,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 5,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 6,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 7,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 8,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 9,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Moneys",
                keyColumn: "Id",
                keyValue: 10,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");

            migrationBuilder.UpdateData(
                table: "Tbl_Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "SaveDate",
                value: "1402/12/11 - 05:14:34");
        }
    }
}
