using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wunderman_Thompson_MSC_Assessment.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Organisation = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    WorkEmail = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    CheckBoxValue1 = table.Column<string>(nullable: true),
                    CheckBoxValue2 = table.Column<string>(nullable: true),
                    CheckBoxValue3 = table.Column<string>(nullable: true),
                    CheckBoxValue4 = table.Column<string>(nullable: true),
                    CheckBoxValue5 = table.Column<string>(nullable: true),
                    Optional = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
