using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Service.PaymentProviderRepository.Postgres.Migrations
{
    public partial class InitialCreatePaymentProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "education");

            migrationBuilder.CreateTable(
                name: "payment_provider",
                schema: "education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Disabled = table.Column<bool>(type: "boolean", nullable: true),
                    Currencies = table.Column<string>(type: "text", nullable: true),
                    SupportCountries = table.Column<string>(type: "text", nullable: true),
                    RestrictedCountries = table.Column<string>(type: "text", nullable: true),
                    KycNeeded = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_provider", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payment_provider_Code",
                schema: "education",
                table: "payment_provider",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment_provider",
                schema: "education");
        }
    }
}
