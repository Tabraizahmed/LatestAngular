using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LatestAngular.Migrations
{
    public partial class addVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModelId = table.Column<int>(nullable: true),
                    IsRegistered = table.Column<bool>(nullable: false),
                    ContactName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 255, nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblVehicle_tblModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "tblModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblVehicleFeature",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVehicleFeature", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_tblVehicleFeature_tblFeature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "tblFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblVehicleFeature_tblVehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "tblVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblVehicle_ModelId",
                table: "tblVehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVehicleFeature_FeatureId",
                table: "tblVehicleFeature",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblVehicleFeature");

            migrationBuilder.DropTable(
                name: "tblVehicle");
        }
    }
}
