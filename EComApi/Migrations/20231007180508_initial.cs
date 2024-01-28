using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EComApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChoiseAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AttributeType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiseAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TextAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    AttributeType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleChoiseValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ChoiseAttributeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleChoiseValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PossibleChoiseValue_ChoiseAttributes_ChoiseAttributeId",
                        column: x => x.ChoiseAttributeId,
                        principalTable: "ChoiseAttributes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TextValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    TextAttributeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextValue_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextValue_TextAttributes_TextAttributeId",
                        column: x => x.TextAttributeId,
                        principalTable: "TextAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PossibleChoiseValueProduct",
                columns: table => new
                {
                    ChoiseValuesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleChoiseValueProduct", x => new { x.ChoiseValuesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PossibleChoiseValueProduct_PossibleChoiseValue_ChoiseValues~",
                        column: x => x.ChoiseValuesId,
                        principalTable: "PossibleChoiseValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PossibleChoiseValueProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PossibleChoiseValue_ChoiseAttributeId",
                table: "PossibleChoiseValue",
                column: "ChoiseAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleChoiseValueProduct_ProductsId",
                table: "PossibleChoiseValueProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_TextValue_ProductId",
                table: "TextValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TextValue_TextAttributeId",
                table: "TextValue",
                column: "TextAttributeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "PossibleChoiseValueProduct");

            migrationBuilder.DropTable(
                name: "TextValue");

            migrationBuilder.DropTable(
                name: "PossibleChoiseValue");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TextAttributes");

            migrationBuilder.DropTable(
                name: "ChoiseAttributes");
        }
    }
}
