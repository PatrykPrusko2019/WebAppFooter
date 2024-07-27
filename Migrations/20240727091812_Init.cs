using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppFooter.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurnameChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentChange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoChange = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
