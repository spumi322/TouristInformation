using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristInformation.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__reserved___attr___4BAC3F29",
                table: "reserved_tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__attracti__3213E83FBC679E51",
                table: "attractions");

            migrationBuilder.DropPrimaryKey(
                name: "PK__reserved__3213E83F59A1ABD8",
                table: "reserved_tickets");

            migrationBuilder.RenameTable(
                name: "attractions",
                newName: "Attractions");

            migrationBuilder.RenameTable(
                name: "reserved_tickets",
                newName: "ReservedTickets");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Attractions",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Attractions",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Attractions",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Attractions",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Attractions",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Attractions",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Attractions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "recommended_age",
                table: "Attractions",
                newName: "RecommendedAge");

            migrationBuilder.RenameColumn(
                name: "attr_name",
                table: "Attractions",
                newName: "AttrName");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "ReservedTickets",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ReservedTickets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "guest_name",
                table: "ReservedTickets",
                newName: "GuestName");

            migrationBuilder.RenameColumn(
                name: "attr_id",
                table: "ReservedTickets",
                newName: "AttrId");

            migrationBuilder.RenameIndex(
                name: "IX_reserved_tickets_attr_id",
                table: "ReservedTickets",
                newName: "IX_ReservedTickets_AttrId");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "AttrName",
                table: "Attractions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldUnicode: false,
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "GuestName",
                table: "ReservedTickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attractions",
                table: "Attractions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedTickets",
                table: "ReservedTickets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedTickets_Attractions_AttrId",
                table: "ReservedTickets",
                column: "AttrId",
                principalTable: "Attractions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservedTickets_Attractions_AttrId",
                table: "ReservedTickets");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attractions",
                table: "Attractions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedTickets",
                table: "ReservedTickets");

            migrationBuilder.RenameTable(
                name: "Attractions",
                newName: "attractions");

            migrationBuilder.RenameTable(
                name: "ReservedTickets",
                newName: "reserved_tickets");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "attractions",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "attractions",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "attractions",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "attractions",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "attractions",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "attractions",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "attractions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RecommendedAge",
                table: "attractions",
                newName: "recommended_age");

            migrationBuilder.RenameColumn(
                name: "AttrName",
                table: "attractions",
                newName: "attr_name");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "reserved_tickets",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reserved_tickets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GuestName",
                table: "reserved_tickets",
                newName: "guest_name");

            migrationBuilder.RenameColumn(
                name: "AttrId",
                table: "reserved_tickets",
                newName: "attr_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedTickets_AttrId",
                table: "reserved_tickets",
                newName: "IX_reserved_tickets_attr_id");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "attractions",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "attractions",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "attr_name",
                table: "attractions",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "guest_name",
                table: "reserved_tickets",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK__attracti__3213E83FBC679E51",
                table: "attractions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__reserved__3213E83F59A1ABD8",
                table: "reserved_tickets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__reserved___attr___4BAC3F29",
                table: "reserved_tickets",
                column: "attr_id",
                principalTable: "attractions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
