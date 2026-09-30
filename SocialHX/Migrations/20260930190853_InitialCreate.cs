using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialHX.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "Prescriber",
                columns: table => new
                {
                    PrescriberID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriber", x => x.PrescriberID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    PrescriberID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Event1ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Event1Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Event1OtherPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Event2ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Event2Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Event2OtherPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Event3ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Event3Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Event3OtherPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Event4ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Event4Notes = table.Column<string>(type: "TEXT", nullable: false),
                    Event4OtherPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_Activity_Event1ID",
                        column: x => x.Event1ID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Activity_Event2ID",
                        column: x => x.Event2ID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Activity_Event3ID",
                        column: x => x.Event3ID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Activity_Event4ID",
                        column: x => x.Event4ID,
                        principalTable: "Activity",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Prescriber_PrescriberID",
                        column: x => x.PrescriberID,
                        principalTable: "Prescriber",
                        principalColumn: "PrescriberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpWeek1",
                columns: table => new
                {
                    FollowUpWeek1ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Response = table.Column<bool>(type: "INTEGER", nullable: false),
                    StudentReport = table.Column<string>(type: "TEXT", nullable: false),
                    StudentAdjustments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpWeek1", x => x.FollowUpWeek1ID);
                    table.ForeignKey(
                        name: "FK_FollowUpWeek1_Prescription_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowUpWeek4",
                columns: table => new
                {
                    FollowUpWeek4ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrescriptionID = table.Column<int>(type: "INTEGER", nullable: false),
                    DidMeet = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DidAttend = table.Column<bool>(type: "INTEGER", nullable: false),
                    EventsAttended = table.Column<int>(type: "INTEGER", nullable: false),
                    Feelings = table.Column<string>(type: "TEXT", nullable: false),
                    Barriers = table.Column<string>(type: "TEXT", nullable: false),
                    Refill = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpWeek4", x => x.FollowUpWeek4ID);
                    table.ForeignKey(
                        name: "FK_FollowUpWeek4_Prescription_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpWeek1_PrescriptionID",
                table: "FollowUpWeek1",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUpWeek4_PrescriptionID",
                table: "FollowUpWeek4",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Event1ID",
                table: "Prescription",
                column: "Event1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Event2ID",
                table: "Prescription",
                column: "Event2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Event3ID",
                table: "Prescription",
                column: "Event3ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Event4ID",
                table: "Prescription",
                column: "Event4ID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PrescriberID",
                table: "Prescription",
                column: "PrescriberID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_StudentID",
                table: "Prescription",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowUpWeek1");

            migrationBuilder.DropTable(
                name: "FollowUpWeek4");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Prescriber");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
