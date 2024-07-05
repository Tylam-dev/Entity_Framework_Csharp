using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework_Csharp.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("baf7eeb1-8841-4474-9f22-fb61b644de02"), null, "Actividades Personales", 50 },
                    { new Guid("baf7eeb1-8841-4474-9f22-fb61b644de20"), null, "Actividades Pendientes", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("baf7eeb1-8841-4474-9f22-fb61b644de08"), new Guid("baf7eeb1-8841-4474-9f22-fb61b644de20"), null, new DateTime(2024, 7, 5, 16, 12, 2, 653, DateTimeKind.Utc).AddTicks(7080), 1, "Pago de servicios publicos" },
                    { new Guid("baf7eeb1-8841-4474-9f22-fb61b644de15"), new Guid("baf7eeb1-8841-4474-9f22-fb61b644de02"), null, new DateTime(2024, 7, 5, 16, 12, 2, 653, DateTimeKind.Utc).AddTicks(7080), 0, "Terminar de ver pelicula" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("baf7eeb1-8841-4474-9f22-fb61b644de08"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("baf7eeb1-8841-4474-9f22-fb61b644de15"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("baf7eeb1-8841-4474-9f22-fb61b644de02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("baf7eeb1-8841-4474-9f22-fb61b644de20"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
