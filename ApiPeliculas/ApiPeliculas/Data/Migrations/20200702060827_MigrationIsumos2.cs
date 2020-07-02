using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPeliculas.Migrations
{
    public partial class MigrationIsumos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "Insumo");

            migrationBuilder.RenameColumn(
                name: "precioUnitario",
                table: "Insumo",
                newName: "PrecioUnitario");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId",
                table: "Insumo",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Insumo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Insumo",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Categoria_categoriaId",
                table: "Insumo",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insumo_Categoria_categoriaId",
                table: "Insumo");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Insumo");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Insumo");

            migrationBuilder.RenameColumn(
                name: "PrecioUnitario",
                table: "Insumo",
                newName: "precioUnitario");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId",
                table: "Insumo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "Insumo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insumo_Categoria1_categoriaId",
                table: "Insumo",
                column: "categoriaId",
                principalTable: "Categoria1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
