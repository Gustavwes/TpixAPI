using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpixAPI.Migrations
{
    public partial class imgUrlToTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VotePost",
                columns: table => new
                {
                    FK_PostId = table.Column<int>(nullable: false),
                    FK_MemberId = table.Column<int>(nullable: false),
                    VoteValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotePost", x => new { x.FK_PostId, x.FK_MemberId });
                });

            migrationBuilder.CreateTable(
                name: "VoteTopic",
                columns: table => new
                {
                    FK_TopicId = table.Column<int>(nullable: false),
                    FK_MemberId = table.Column<int>(nullable: false),
                    VoteValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteTopic", x => new { x.FK_TopicId, x.FK_MemberId });
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    ImgUrl = table.Column<string>(maxLength: 300, nullable: true),
                    FK_CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Category__FK_Cre__06CD04F7",
                        column: x => x.FK_CreatedBy,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    MainBody = table.Column<string>(maxLength: 4000, nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    FK_CategoryId = table.Column<int>(nullable: false),
                    FK_CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Topic__FK_Catego__09A971A2",
                        column: x => x.FK_CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Topic__FK_Create__0A9D95DB",
                        column: x => x.FK_CreatedBy,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MainBody = table.Column<string>(maxLength: 4000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    FK_ParentTopicId = table.Column<int>(nullable: false),
                    FK_CreatedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Post__FK_Created__0E6E26BF",
                        column: x => x.FK_CreatedBy,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Post__FK_ParentT__0D7A0286",
                        column: x => x.FK_ParentTopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    FK_MemberReportedId = table.Column<int>(nullable: false),
                    FK_PostId = table.Column<int>(nullable: false),
                    FK_TopicId = table.Column<int>(nullable: false),
                    FK_ReportingMemberId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Reason = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => new { x.FK_TopicId, x.FK_MemberReportedId, x.FK_PostId, x.FK_ReportingMemberId });
                    table.ForeignKey(
                        name: "FK__Report__FK_Membe__160F4887",
                        column: x => x.FK_MemberReportedId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Report__FK_PostI__18EBB532",
                        column: x => x.FK_PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Report__FK_Repor__17036CC0",
                        column: x => x.FK_ReportingMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Report__FK_Topic__17F790F9",
                        column: x => x.FK_TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_FK_CreatedBy",
                table: "Category",
                column: "FK_CreatedBy");

            migrationBuilder.CreateIndex(
                name: "UQ__Member__A9D105347DA6888F",
                table: "Member",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Member__536C85E439ECE2C6",
                table: "Member",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_FK_CreatedBy",
                table: "Post",
                column: "FK_CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Post_FK_ParentTopicId",
                table: "Post",
                column: "FK_ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_FK_MemberReportedId",
                table: "Report",
                column: "FK_MemberReportedId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_FK_PostId",
                table: "Report",
                column: "FK_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_FK_ReportingMemberId",
                table: "Report",
                column: "FK_ReportingMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_FK_CategoryId",
                table: "Topic",
                column: "FK_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_FK_CreatedBy",
                table: "Topic",
                column: "FK_CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "VotePost");

            migrationBuilder.DropTable(
                name: "VoteTopic");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
