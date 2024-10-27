using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class reservation_car_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rezervations_CarId",
                table: "Rezervations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervations_Cars_CarId",
                table: "Rezervations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervations_Cars_CarId",
                table: "Rezervations");

            migrationBuilder.DropIndex(
                name: "IX_Rezervations_CarId",
                table: "Rezervations");
        }
    }
}
