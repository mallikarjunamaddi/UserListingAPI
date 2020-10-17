using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserListingAPI.DataModel.Migrations
{
    public partial class AddedLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(maxLength: 200, nullable: true),
                    Level = table.Column<string>(maxLength: 5, nullable: false),
                    Callsite = table.Column<string>(maxLength: 300, nullable: true),
                    Type = table.Column<string>(maxLength: 500, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    InnerException = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: false),
                    LogDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
