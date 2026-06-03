using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Final_PrograIV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateOffers_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferSkills_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Email", "Name", "Password", "WebSite" },
                values: new object[,]
                {
                    { 1, "contact@innowise.com", "Innowise", "1234", "https://innowise.com/es/tecnologias/desarrollo-dot-net/" },
                    { 2, "contact@turing.com", "TURING", "123", "https://www.turing.com/es/jobs/remote-react-js-developer" },
                    { 3, "info@paralleldevs.com", "Parallel Devs", "12345", "https://www.paralleldevs.com/" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "https://www.svgrepo.com/show/452184/csharp.svg", "C#" },
                    { 2, "https://www.svgrepo.com/show/331761/sql-database-sql-azure.svg", "SQL" },
                    { 3, "https://upload.wikimedia.org/wikipedia/commons/a/a8/NestJS.svg", "Nest" },
                    { 4, "https://www.svgrepo.com/show/354099/mysql.svg", "MySQL" },
                    { 5, "https://upload.wikimedia.org/wikipedia/commons/9/99/Unofficial_JavaScript_logo_2.svg", "JavaScript" },
                    { 6, "https://upload.wikimedia.org/wikipedia/commons/4/4c/Typescript_logo_2020.svg", "TypeScript" },
                    { 7, "https://upload.wikimedia.org/wikipedia/commons/a/a7/React-icon.svg", "React" },
                    { 8, "https://www.svgrepo.com/show/452075/node-js.svg", "Node.js" },
                    { 9, "https://upload.wikimedia.org/wikipedia/commons/c/c3/Python-logo-notext.svg", "Python" },
                    { 10, "https://www.svgrepo.com/show/452228/html-5.svg", "HTML" },
                    { 11, "https://www.svgrepo.com/show/452185/css-3.svg", "CSS" },
                    { 12, "https://www.svgrepo.com/show/354926/docker.svg", "Docker" },
                    { 13, "https://upload.wikimedia.org/wikipedia/commons/3/3f/Git_icon.svg", "Git" },
                    { 14, "https://upload.wikimedia.org/wikipedia/commons/f/fa/Microsoft_Azure.svg", "Azure" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CompanyId", "Description", "Job" },
                values: new object[,]
                {
                    { 1, 2, "Revisión", "QA" },
                    { 2, 1, "Desarrollar sistemas", "Desarrollo web" },
                    { 3, 2, "Servicios API", "Programador backend" },
                    { 4, 3, "Administrar proyectos TI", "Gerente IT" },
                    { 5, 1, "Interfaces modernas", "Frontend Developer" },
                    { 6, 2, "Pipelines y despliegues", "DevOps Engineer" },
                    { 7, 3, "Gestión de bases de datos", "Administrador de BD" },
                    { 8, 1, "Apps móviles con React Native", "Mobile Developer" },
                    { 9, 2, "Frontend y Backend", "Fullstack Developer" },
                    { 10, 3, "Atención a usuarios", "Soporte Técnico" }
                });

            migrationBuilder.InsertData(
                table: "OfferSkills",
                columns: new[] { "Id", "OfferId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 1 },
                    { 4, 2, 2 },
                    { 5, 2, 3 },
                    { 6, 3, 1 },
                    { 7, 3, 8 },
                    { 8, 3, 12 },
                    { 9, 4, 14 },
                    { 10, 4, 13 },
                    { 11, 5, 7 },
                    { 12, 5, 10 },
                    { 13, 5, 11 },
                    { 14, 6, 12 },
                    { 15, 6, 13 },
                    { 16, 6, 14 },
                    { 17, 7, 2 },
                    { 18, 7, 4 },
                    { 19, 8, 5 },
                    { 20, 8, 6 },
                    { 21, 8, 7 },
                    { 22, 9, 1 },
                    { 23, 9, 7 },
                    { 24, 9, 8 },
                    { 25, 10, 9 },
                    { 26, 10, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOffers_CandidateId",
                table: "CandidateOffers",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOffers_OfferId",
                table: "CandidateOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CompanyId",
                table: "Offers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSkills_OfferId",
                table: "OfferSkills",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferSkills_SkillId",
                table: "OfferSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateOffers");

            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "OfferSkills");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
