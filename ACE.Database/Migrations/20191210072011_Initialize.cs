using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContributionTypes",
                columns: table => new
                {
                    ContributionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsMandatory = table.Column<bool>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: true),
                    IsOnlyOnce = table.Column<bool>(nullable: false),
                    IsPrFamily = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionTypes", x => x.ContributionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                });

            migrationBuilder.CreateTable(
                name: "MainFamily",
                columns: table => new
                {
                    MainFamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamilyClan = table.Column<string>(nullable: true),
                    FamilyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainFamily", x => x.MainFamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Identity = table.Column<string>(nullable: true),
                    MainFamilyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                    table.ForeignKey(
                        name: "FK_Families_MainFamily_MainFamilyId",
                        column: x => x.MainFamilyId,
                        principalTable: "MainFamily",
                        principalColumn: "MainFamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsMainFamilyPerson = table.Column<bool>(nullable: false),
                    MemberStatus = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelephoneNumber1 = table.Column<string>(nullable: true),
                    TelephoneNumber2 = table.Column<string>(nullable: true),
                    Cpr = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsUnderAge = table.Column<bool>(nullable: false),
                    DistrictId = table.Column<int>(nullable: true),
                    Contry = table.Column<string>(nullable: true),
                    IsMarried = table.Column<bool>(nullable: false),
                    IsMale = table.Column<bool>(nullable: false),
                    Profession = table.Column<string>(nullable: true),
                    WeddingDate = table.Column<DateTime>(type: "date", nullable: false),
                    BaptismalDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "date", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "date", nullable: false),
                    MovingDate = table.Column<DateTime>(type: "date", nullable: false),
                    FamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Members_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    ContributionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<int>(nullable: true),
                    FamilyId = table.Column<int>(nullable: true),
                    ContributionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.ContributionId);
                    table.ForeignKey(
                        name: "FK_Contributions_ContributionTypes_ContributionTypeId",
                        column: x => x.ContributionTypeId,
                        principalTable: "ContributionTypes",
                        principalColumn: "ContributionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributions_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contributions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    IsObsolete = table.Column<bool>(nullable: false),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_ContributionTypeId",
                table: "Contributions",
                column: "ContributionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_FamilyId",
                table: "Contributions",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_MemberId",
                table: "Contributions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_MainFamilyId",
                table: "Families",
                column: "MainFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_DistrictId",
                table: "Members",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_FamilyId",
                table: "Members",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_MemberId",
                table: "Note",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "ContributionTypes");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "MainFamily");
        }
    }
}
