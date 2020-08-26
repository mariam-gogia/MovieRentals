using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HW6MovieSharing.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowRequest",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    SharedWithFirstName = table.Column<string>(nullable: true),
                    SharedWithLastName = table.Column<string>(nullable: true),
                    SharedwithEmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1024, nullable: false),
                    Category = table.Column<string>(maxLength: 256, nullable: false),
                    SharedWithFirstName = table.Column<string>(maxLength: 256, nullable: true),
                    SharedWithLastName = table.Column<string>(maxLength: 256, nullable: true),
                    SharedwithEmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    SharedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    IsShareable = table.Column<bool>(nullable: false),
                    Request = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRequest");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
