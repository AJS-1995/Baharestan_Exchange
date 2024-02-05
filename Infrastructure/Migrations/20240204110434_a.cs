using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Responsible = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Companies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Tbl_ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_Tbl_ExchangeRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Moneys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Moneys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Personnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fathers_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Cart_Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Personnel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cod = table.Column<int>(type: "int", nullable: false),
                    NamePersian = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SafeBoxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Treasurer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SafeBoxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Guarantor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GuarantorPhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Persons_Tbl_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Tbl_Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Collection_Id = table.Column<int>(type: "int", nullable: false),
                    N_Invoice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ph_Invoice = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Personnel_Id = table.Column<int>(type: "int", nullable: false),
                    SafeBox_Id = table.Column<int>(type: "int", nullable: false),
                    Money_Id = table.Column<int>(type: "int", nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Expenses_Tbl_Collections_Collection_Id",
                        column: x => x.Collection_Id,
                        principalTable: "Tbl_Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SecurityCod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SaveDate = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Users_Tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Fingerprint = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                        name: "FK_Tbl_PersonsReceipts_Tbl_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Tbl_Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_PersonsReceipts_Tbl_Moneys_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "Tbl_Moneys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_PersonsReceipts_Tbl_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Tbl_Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tbl_PersonsReceipts_Tbl_SafeBoxs_SafeBoxId",
                        column: x => x.SafeBoxId,
                        principalTable: "Tbl_SafeBoxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Permissions_Tbl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tbl_Moneys",
                columns: new[] { "Id", "AgenciesId", "Country", "Deleted", "Name", "SaveDate", "Status", "Symbol", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "افغانستان", false, "افغانی", "1402/11/15 - 15:34:32", true, "؋", 1 },
                    { 2, 0, "ایالات متحده امریکا", false, "دالر", "1402/11/15 - 15:34:32", true, "$", 1 },
                    { 3, 0, "ایران", false, "تومان", "1402/11/15 - 15:34:32", true, "IRR", 1 },
                    { 4, 0, "پاکستان", false, "روپیه پاکستان", "1402/11/15 - 15:34:32", true, "₨", 1 },
                    { 5, 0, "هندوستان", false, "روپیه هندی", "1402/11/15 - 15:34:32", true, "₹", 1 },
                    { 6, 0, "اروپا", false, "یورو", "1402/11/15 - 15:34:32", true, "€", 1 },
                    { 7, 0, "بریتانیا", false, "پوند", "1402/11/15 - 15:34:32", true, "£", 1 },
                    { 8, 0, "چین", false, "یوآن", "1402/11/15 - 15:34:32", true, "¥", 1 },
                    { 9, 0, "ترکیه", false, "لیره", "1402/11/15 - 15:34:32", true, "₺", 1 },
                    { 10, 0, "روسیه", false, "روبل", "1402/11/15 - 15:34:32", true, "₽", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tbl_Roles",
                columns: new[] { "Id", "AgenciesId", "Cod", "Deleted", "Name", "NamePersian", "SaveDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 0, 1, false, "Admin", "مدیر سیستم", "1402/11/15 - 15:34:32", true, 1 },
                    { 2, 0, 1, false, "Accountant", "حسابدار", "1402/11/15 - 15:34:32", true, 1 },
                    { 3, 0, 1, false, "Viewer", "بیننده", "1402/11/15 - 15:34:32", true, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Expenses_Collection_Id",
                table: "Tbl_Expenses",
                column: "Collection_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Permissions_UserId",
                table: "Tbl_Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Persons_AgenciesId",
                table: "Tbl_Persons",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PersonsReceipts_AgenciesId",
                table: "Tbl_PersonsReceipts",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PersonsReceipts_MoneyId",
                table: "Tbl_PersonsReceipts",
                column: "MoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PersonsReceipts_PersonId",
                table: "Tbl_PersonsReceipts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_PersonsReceipts_SafeBoxId",
                table: "Tbl_PersonsReceipts",
                column: "SafeBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_Mobile",
                table: "Tbl_Users",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Users_RoleId",
                table: "Tbl_Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Companies");

            migrationBuilder.DropTable(
                name: "Tbl_DailyRates");

            migrationBuilder.DropTable(
                name: "Tbl_ExchangeRates");

            migrationBuilder.DropTable(
                name: "Tbl_Expenses");

            migrationBuilder.DropTable(
                name: "Tbl_Permissions");

            migrationBuilder.DropTable(
                name: "Tbl_Personnel");

            migrationBuilder.DropTable(
                name: "Tbl_PersonsReceipts");

            migrationBuilder.DropTable(
                name: "Tbl_Collections");

            migrationBuilder.DropTable(
                name: "Tbl_Users");

            migrationBuilder.DropTable(
                name: "Tbl_Moneys");

            migrationBuilder.DropTable(
                name: "Tbl_Persons");

            migrationBuilder.DropTable(
                name: "Tbl_SafeBoxs");

            migrationBuilder.DropTable(
                name: "Tbl_Roles");

            migrationBuilder.DropTable(
                name: "Tbl_Agencies");
        }
    }
}
