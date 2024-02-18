using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristInformation.Migrations
{
    /// <inheritdoc />
    public partial class addbasedomainentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attractions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attr_name = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    city = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    category = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    recommended_age = table.Column<double>(type: "float", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__attracti__3213E83FBC679E51", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reserved_tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guest_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    attr_id = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reserved__3213E83F59A1ABD8", x => x.id);
                    table.ForeignKey(
                        name: "FK__reserved___attr___4BAC3F29",
                        column: x => x.attr_id,
                        principalTable: "attractions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reserved_tickets_attr_id",
                table: "reserved_tickets",
                column: "attr_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reserved_tickets");

            migrationBuilder.DropTable(
                name: "attractions");
        }
    }
}
