using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarServiceDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class CorrectManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractServices",
                table: "ContractServices");

            migrationBuilder.DropIndex(
                name: "IX_ContractServices_ServiceId",
                table: "ContractServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ContractServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractServices",
                table: "ContractServices",
                columns: new[] { "ServiceId", "ContractId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractServices",
                table: "ContractServices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ContractServices",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractServices",
                table: "ContractServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContractServices_ServiceId",
                table: "ContractServices",
                column: "ServiceId");
        }
    }
}
