using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Service.Managment.Persistence.Migrations
{
    public partial class CreateUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarkupPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Markup = table.Column<decimal>(nullable: false),
                    ApplyPoint = table.Column<bool>(nullable: false),
                    CanUseCoupon = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkupPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsRedeemPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    PlanDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsRedeemPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    ParentUserId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ExternalLoginId = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CanUseCoupon = table.Column<bool>(nullable: false),
                    DisplayMarkup = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_User_ParentUserId",
                        column: x => x.ParentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultMarkupPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkupPlanId = table.Column<int>(nullable: false),
                    Module = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultMarkupPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultMarkupPlan_MarkupPlan_MarkupPlanId",
                        column: x => x.MarkupPlanId,
                        principalTable: "MarkupPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefaultPointsRedeemPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PointsRedeemPlanId = table.Column<int>(nullable: false),
                    Module = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultPointsRedeemPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultPointsRedeemPlan_PointsRedeemPlan_PointsRedeemPlanId",
                        column: x => x.PointsRedeemPlanId,
                        principalTable: "PointsRedeemPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCreditCards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CardNumber = table.Column<string>(nullable: true),
                    CardDisplayNumber = table.Column<string>(nullable: true),
                    CardHolderName = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCreditCard_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMarkupPlans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    MarkupPlanId = table.Column<int>(nullable: false),
                    Module = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMarkupPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMarkupPlan_MarkupPlan_MarkupPlanId",
                        column: x => x.MarkupPlanId,
                        principalTable: "MarkupPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMarkupPlan_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPointsRedeemPlans",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    PointsRedeemPlanId = table.Column<int>(nullable: false),
                    Module = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPointsRedeemPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Redeem_Plans",
                        column: x => x.PointsRedeemPlanId,
                        principalTable: "PointsRedeemPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Points_Redeem_Plans",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultMarkupPlans_MarkupPlanId",
                table: "DefaultMarkupPlans",
                column: "MarkupPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DefaultPointsRedeemPlans_PointsRedeemPlanId",
                table: "DefaultPointsRedeemPlans",
                column: "PointsRedeemPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCreditCards_UserId",
                table: "UserCreditCards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMarkupPlans_MarkupPlanId",
                table: "UserMarkupPlans",
                column: "MarkupPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMarkupPlans_UserId",
                table: "UserMarkupPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPointsRedeemPlans_PointsRedeemPlanId",
                table: "UserPointsRedeemPlans",
                column: "PointsRedeemPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPointsRedeemPlans_UserId",
                table: "UserPointsRedeemPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParentUserId",
                table: "Users",
                column: "ParentUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultMarkupPlans");

            migrationBuilder.DropTable(
                name: "DefaultPointsRedeemPlans");

            migrationBuilder.DropTable(
                name: "UserCreditCards");

            migrationBuilder.DropTable(
                name: "UserMarkupPlans");

            migrationBuilder.DropTable(
                name: "UserPointsRedeemPlans");

            migrationBuilder.DropTable(
                name: "MarkupPlans");

            migrationBuilder.DropTable(
                name: "PointsRedeemPlans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
