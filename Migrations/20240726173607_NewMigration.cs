using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppFooter.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameSurnameChange = table.Column<string>(type: "TEXT", nullable: false),
                    SiteChange = table.Column<string>(type: "TEXT", nullable: false),
                    EmailChange = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneChange = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentChange = table.Column<string>(type: "TEXT", nullable: false),
                    LogoChange = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footers");
        }
    }
}
