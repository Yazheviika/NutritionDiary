using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NutritionDiary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NutritionFacts_EnergyKcalPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_FatPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_SaturatedFatPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_CarbohydratesPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_ProteinsPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_SugarsPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_FiberPer100g = table.Column<double>(type: "double precision", nullable: false),
                    NutritionFacts_SaltPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_IronPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_CalciumPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_PotassiumPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_VitaminDPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_VitaminCPer100g = table.Column<double>(type: "double precision", nullable: true),
                    NutritionFacts_VitaminB12Per100g = table.Column<double>(type: "double precision", nullable: true),
                    ItemType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    NutriscoreGrade = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    ExternalId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FoodItemId = table.Column<int>(type: "integer", nullable: true),
                    FoodItemName = table.Column<string>(type: "text", nullable: false),
                    NutritionTotalsSnapshot_EnergyKcal = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Fat = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_SaturatedFat = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Proteins = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Sugars = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Fiber = table.Column<double>(type: "double precision", nullable: false),
                    NutritionTotalsSnapshot_Salt = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_Iron = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_Calcium = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_Potassium = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_VitaminD = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_VitaminC = table.Column<double>(type: "double precision", nullable: true),
                    NutritionTotalsSnapshot_VitaminB12 = table.Column<double>(type: "double precision", nullable: true),
                    QuantityInG = table.Column<double>(type: "double precision", nullable: false),
                    Meal = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryEntries_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntries_FoodItemId",
                table: "DiaryEntries",
                column: "FoodItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");

            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
