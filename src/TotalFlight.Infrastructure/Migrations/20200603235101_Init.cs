using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TotalFlight.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Places = table.Column<int>(nullable: false),
                    IsGrounded = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDispatched = table.Column<bool>(nullable: false),
                    IsSoftDeleted = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageThumbPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deadlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AircraftId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 75, nullable: true),
                    TargetLastCompl = table.Column<decimal>(nullable: true),
                    TargetInit = table.Column<decimal>(nullable: true),
                    TargetInterval = table.Column<decimal>(nullable: true),
                    TargetCurr = table.Column<decimal>(nullable: false),
                    DateLastCompl = table.Column<DateTime>(nullable: true),
                    DateInit = table.Column<DateTime>(nullable: true),
                    DateIntervalInDays = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deadlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discrepancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AircraftId = table.Column<string>(nullable: true),
                    SquawkId = table.Column<Guid>(nullable: true),
                    WorkOrderId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Resolution = table.Column<string>(maxLength: 600, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateFinalized = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discrepancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscrepancyTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 75, nullable: true),
                    Resolution = table.Column<string>(maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscrepancyTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaborRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DiscrepancyId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    LaborInHours = table.Column<decimal>(nullable: false),
                    DatePerformed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ManufacturersPn = table.Column<string>(maxLength: 70, nullable: true),
                    CataloguePn = table.Column<string>(maxLength: 70, nullable: true),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Vendor = table.Column<string>(nullable: true),
                    CurrentStock = table.Column<int>(nullable: false),
                    MinStock = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageThumbPath = table.Column<string>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Squawks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AircraftId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Resolution = table.Column<string>(maxLength: 600, nullable: true),
                    Creator = table.Column<string>(nullable: true),
                    IsGroundable = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateResolved = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squawks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AircraftId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateFinalized = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 40, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AircraftOptions",
                columns: table => new
                {
                    AircraftId = table.Column<string>(nullable: false),
                    HasElecHobbs = table.Column<bool>(nullable: false),
                    TracksAirtime = table.Column<bool>(nullable: false),
                    TracksCycles = table.Column<bool>(nullable: false),
                    IsTailWheel = table.Column<bool>(nullable: false),
                    IsTwin = table.Column<bool>(nullable: false),
                    IsSimulator = table.Column<bool>(nullable: false),
                    IsGrounded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftOptions", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_AircraftOptions_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AircraftTimes",
                columns: table => new
                {
                    AircraftId = table.Column<string>(nullable: false),
                    ElectricalHobbs = table.Column<decimal>(nullable: true),
                    Engine1Current = table.Column<decimal>(nullable: false),
                    Engine2Current = table.Column<decimal>(nullable: true),
                    AircraftTotal = table.Column<decimal>(nullable: false),
                    Engine1Total = table.Column<decimal>(nullable: false),
                    Engine2Total = table.Column<decimal>(nullable: true),
                    Prop1Total = table.Column<decimal>(nullable: false),
                    Prop2Total = table.Column<decimal>(nullable: true),
                    Cycles = table.Column<int>(nullable: true),
                    AirtimeCurrent = table.Column<decimal>(nullable: true),
                    AirtimeTotal = table.Column<decimal>(nullable: true),
                    AircraftTotalTgt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftTimes", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_AircraftTimes_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeadlineOptions",
                columns: table => new
                {
                    DeadlineId = table.Column<Guid>(nullable: false),
                    TracksTarget = table.Column<bool>(nullable: false),
                    TracksDate = table.Column<bool>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false),
                    Target = table.Column<int>(nullable: true),
                    WarningTgtThresh = table.Column<decimal>(nullable: false),
                    WarningDateThreshInDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineOptions", x => x.DeadlineId);
                    table.ForeignKey(
                        name: "FK_DeadlineOptions_Deadlines_DeadlineId",
                        column: x => x.DeadlineId,
                        principalTable: "Deadlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscrepancyParts",
                columns: table => new
                {
                    DiscrepancyId = table.Column<Guid>(nullable: false),
                    PartId = table.Column<Guid>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscrepancyParts", x => new { x.DiscrepancyId, x.PartId });
                    table.ForeignKey(
                        name: "FK_DiscrepancyParts_Discrepancies_DiscrepancyId",
                        column: x => x.DiscrepancyId,
                        principalTable: "Discrepancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscrepancyParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscrepancyTemplateParts",
                columns: table => new
                {
                    DiscrepancyTemplateId = table.Column<Guid>(nullable: false),
                    PartId = table.Column<Guid>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscrepancyTemplateParts", x => new { x.DiscrepancyTemplateId, x.PartId });
                    table.ForeignKey(
                        name: "FK_DiscrepancyTemplateParts_DiscrepancyTemplates_DiscrepancyTem~",
                        column: x => x.DiscrepancyTemplateId,
                        principalTable: "DiscrepancyTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscrepancyTemplateParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderTemplateDiscrepancyTemplates",
                columns: table => new
                {
                    WorkOrderTemplateId = table.Column<Guid>(nullable: false),
                    DiscrepancyTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderTemplateDiscrepancyTemplates", x => new { x.WorkOrderTemplateId, x.DiscrepancyTemplateId });
                    table.ForeignKey(
                        name: "FK_WorkOrderTemplateDiscrepancyTemplates_DiscrepancyTemplates_D~",
                        column: x => x.DiscrepancyTemplateId,
                        principalTable: "DiscrepancyTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrderTemplateDiscrepancyTemplates_WorkOrderTemplates_Wor~",
                        column: x => x.WorkOrderTemplateId,
                        principalTable: "WorkOrderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscrepancyParts_PartId",
                table: "DiscrepancyParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscrepancyTemplateParts_PartId",
                table: "DiscrepancyTemplateParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderTemplateDiscrepancyTemplates_DiscrepancyTemplateId",
                table: "WorkOrderTemplateDiscrepancyTemplates",
                column: "DiscrepancyTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AircraftOptions");

            migrationBuilder.DropTable(
                name: "AircraftTimes");

            migrationBuilder.DropTable(
                name: "DeadlineOptions");

            migrationBuilder.DropTable(
                name: "DiscrepancyParts");

            migrationBuilder.DropTable(
                name: "DiscrepancyTemplateParts");

            migrationBuilder.DropTable(
                name: "LaborRecords");

            migrationBuilder.DropTable(
                name: "Squawks");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "WorkOrderTemplateDiscrepancyTemplates");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "Deadlines");

            migrationBuilder.DropTable(
                name: "Discrepancies");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "DiscrepancyTemplates");

            migrationBuilder.DropTable(
                name: "WorkOrderTemplates");
        }
    }
}
