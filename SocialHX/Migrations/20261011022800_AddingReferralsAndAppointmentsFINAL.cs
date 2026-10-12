using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialHX.Migrations
{
    /// <inheritdoc />
    public partial class AddingReferralsAndAppointmentsFINAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_1_Prescriber_PrescriberID",
                table: "Appointment_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_1_Student_StudentID",
                table: "Appointment_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Appointment_1_AppointmentID",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Referral_1_Student_StudentID",
                table: "Referral_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Referral_1",
                table: "Referral_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment_1",
                table: "Appointment_1");

            migrationBuilder.RenameTable(
                name: "Referral_1",
                newName: "Referral");

            migrationBuilder.RenameTable(
                name: "Appointment_1",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Referral_1_StudentID",
                table: "Referral",
                newName: "IX_Referral_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_1_StudentID",
                table: "Appointment",
                newName: "IX_Appointment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_1_PrescriberID",
                table: "Appointment",
                newName: "IX_Appointment_PrescriberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Referral",
                table: "Referral",
                column: "ReferralID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Prescriber_PrescriberID",
                table: "Appointment",
                column: "PrescriberID",
                principalTable: "Prescriber",
                principalColumn: "PrescriberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Student_StudentID",
                table: "Appointment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Appointment_AppointmentID",
                table: "Prescription",
                column: "AppointmentID",
                principalTable: "Appointment",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referral_Student_StudentID",
                table: "Referral",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Prescriber_PrescriberID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Student_StudentID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Appointment_AppointmentID",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Referral_Student_StudentID",
                table: "Referral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Referral",
                table: "Referral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Referral",
                newName: "Referral_1");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointment_1");

            migrationBuilder.RenameIndex(
                name: "IX_Referral_StudentID",
                table: "Referral_1",
                newName: "IX_Referral_1_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_StudentID",
                table: "Appointment_1",
                newName: "IX_Appointment_1_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_PrescriberID",
                table: "Appointment_1",
                newName: "IX_Appointment_1_PrescriberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Referral_1",
                table: "Referral_1",
                column: "ReferralID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment_1",
                table: "Appointment_1",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_1_Prescriber_PrescriberID",
                table: "Appointment_1",
                column: "PrescriberID",
                principalTable: "Prescriber",
                principalColumn: "PrescriberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_1_Student_StudentID",
                table: "Appointment_1",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Appointment_1_AppointmentID",
                table: "Prescription",
                column: "AppointmentID",
                principalTable: "Appointment_1",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referral_1_Student_StudentID",
                table: "Referral_1",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
