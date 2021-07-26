using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerPortal.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    StockDetailId = table.Column<int>(type: "int", nullable: true),
                    MutualFundDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MutualFundDetails",
                columns: table => new
                {
                    MutualFundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    MutualFundName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MutualFundUnits = table.Column<int>(type: "int", nullable: false),
                    PortfolioTransactionDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MutualFundDetails", x => x.MutualFundId);
                    table.ForeignKey(
                        name: "FK_MutualFundDetails_PortfolioDetails_PortfolioTransactionDetailId",
                        column: x => x.PortfolioTransactionDetailId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockDetails",
                columns: table => new
                {
                    StockDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCount = table.Column<int>(type: "int", nullable: false),
                    PortfolioTransactionDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetails", x => x.StockDetailId);
                    table.ForeignKey(
                        name: "FK_StockDetails_PortfolioDetails_PortfolioTransactionDetailId",
                        column: x => x.PortfolioTransactionDetailId,
                        principalTable: "PortfolioDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MutualFundDetails_PortfolioTransactionDetailId",
                table: "MutualFundDetails",
                column: "PortfolioTransactionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDetails_PortfolioTransactionDetailId",
                table: "StockDetails",
                column: "PortfolioTransactionDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MutualFundDetails");

            migrationBuilder.DropTable(
                name: "StockDetails");

            migrationBuilder.DropTable(
                name: "PortfolioDetails");
        }
    }
}
