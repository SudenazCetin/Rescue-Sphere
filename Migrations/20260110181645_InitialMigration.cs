using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rescue_Sphere.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupportCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedByUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SupportCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpRequests_SupportCategories_SupportCategoryId",
                        column: x => x.SupportCategoryId,
                        principalTable: "SupportCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HelpRequests_Users_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    HelpRequestId = table.Column<int>(type: "INTEGER", nullable: false),
                    VolunteerUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteerAssignments_HelpRequests_HelpRequestId",
                        column: x => x.HelpRequestId,
                        principalTable: "HelpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteerAssignments_Users_VolunteerUserId",
                        column: x => x.VolunteerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SupportCategories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(7074), "Yiyecek ve içecek yardımı", false, "Gıda", null },
                    { 2, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(7078), "Acil barınma ve konaklama yardımı", false, "Barınma", null },
                    { 3, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(7081), "Tıbbi yardım ve sağlık hizmetleri", false, "Sağlık", null },
                    { 4, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(7083), "Taşınma ve ulaştırma yardımı", false, "Nakliye", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "PasswordHash", "Role", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 18, 16, 15, 712, DateTimeKind.Utc).AddTicks(9213), "admin@rescuesphere.com", false, "$2a$11$38ma4bszbKYX97g.CbBP0ONn5dugAG4YUMqrrva33fVBhop/dBnYW", 2, null, "admin" },
                    { 2, new DateTime(2026, 1, 10, 18, 16, 15, 928, DateTimeKind.Utc).AddTicks(7349), "ali@rescuesphere.com", false, "$2a$11$XfIi/VEL6MvWvOlBg5zrR.qu36QEdMzMtI3q4wX0xzaVPimKcRnbu", 1, null, "volunteer_ali" },
                    { 3, new DateTime(2026, 1, 10, 18, 16, 16, 139, DateTimeKind.Utc).AddTicks(9362), "fatma@rescuesphere.com", false, "$2a$11$LmH/GbvWxgILA8MKZr6L1eQZMQrdMNGrgLbn9ucMV1ZpuHt6VYnl.", 1, null, "volunteer_fatma" },
                    { 4, new DateTime(2026, 1, 10, 18, 16, 16, 351, DateTimeKind.Utc).AddTicks(5748), "mehmet@rescuesphere.com", false, "$2a$11$UnT3YNjyyl678vpGCfTDPu28Ltz.aRiZ.dRqiTxwAu04uwt0a.LLG", 0, null, "citizen_mehmet" },
                    { 5, new DateTime(2026, 1, 10, 18, 16, 16, 571, DateTimeKind.Utc).AddTicks(661), "zeynep@rescuesphere.com", false, "$2a$11$ECalResVtVoGBMQdT9LNKufdqMbaBOO.6DLcCq1CLUA68AkFVvXgm", 0, null, "citizen_zeynep" }
                });

            migrationBuilder.InsertData(
                table: "HelpRequests",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Location", "Priority", "RequestedByUserId", "Status", "SupportCategoryId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(9022), "Ailemiz için yardım talep ediyoruz, 3 kişilik aile", false, "İstanbul, Sultangazi", 2, 4, 0, 1, "Acil Gıda Yardımı", null },
                    { 2, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(9026), "Deprem nedeniyle evim hasar gördü, geçici barınma yardımı istiyorum", false, "İzmir, Konak", 3, 5, 1, 2, "Geçici Barınma İhtiyacı", null },
                    { 3, new DateTime(2026, 1, 10, 18, 16, 16, 572, DateTimeKind.Utc).AddTicks(9030), "Yaşlı anne için ilaç ve tıbbi malzeme gerekli", false, "Ankara, Çankaya", 1, 4, 0, 3, "Sağlık Desteği", null }
                });

            migrationBuilder.InsertData(
                table: "VolunteerAssignments",
                columns: new[] { "Id", "AssignedAt", "CreatedAt", "HelpRequestId", "IsDeleted", "Status", "UpdatedAt", "VolunteerUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 10, 18, 16, 16, 573, DateTimeKind.Utc).AddTicks(17), new DateTime(2026, 1, 10, 18, 16, 16, 573, DateTimeKind.Utc).AddTicks(166), 1, false, 0, null, 2 },
                    { 2, new DateTime(2026, 1, 10, 18, 16, 16, 573, DateTimeKind.Utc).AddTicks(169), new DateTime(2026, 1, 10, 18, 16, 16, 573, DateTimeKind.Utc).AddTicks(170), 2, false, 1, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_RequestedByUserId",
                table: "HelpRequests",
                column: "RequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpRequests_SupportCategoryId",
                table: "HelpRequests",
                column: "SupportCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerAssignments_HelpRequestId",
                table: "VolunteerAssignments",
                column: "HelpRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerAssignments_VolunteerUserId",
                table: "VolunteerAssignments",
                column: "VolunteerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteerAssignments");

            migrationBuilder.DropTable(
                name: "HelpRequests");

            migrationBuilder.DropTable(
                name: "SupportCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
