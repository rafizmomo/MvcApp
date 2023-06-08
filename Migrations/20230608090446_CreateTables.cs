using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                 name: "Table_Group",
                 columns: table => new
                 {
                     GroupID = table.Column<int>(nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     GroupName = table.Column<string>(maxLength: 100, nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Table_Group", x => x.GroupID);
                 });

            migrationBuilder.CreateTable(
                name: "Table_Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(maxLength: 100, nullable: true),
                    Sequence = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "Table_User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    GroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Table_User_Table_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Table_Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Table_Group_Access",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false),
                    MenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_Group_Access", x => new { x.GroupID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_Table_Group_Access_Table_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Table_Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Table_Group_Access_Table_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Table_Menu",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_Group_Access_MenuID",
                table: "Table_Group_Access",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_User_GroupID",
                table: "Table_User",
                column: "GroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table_Group_Access");

            migrationBuilder.DropTable(
                name: "Table_User");

            migrationBuilder.DropTable(
                name: "Table_Menu");

            migrationBuilder.DropTable(
                name: "Table_Group");
        }
    }
}
