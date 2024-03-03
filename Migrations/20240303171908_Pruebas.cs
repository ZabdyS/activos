using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace activos.Migrations
{
    /// <inheritdoc />
    public partial class Pruebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_departamentos_DepartamentoId_departamento",
                table: "empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_empleado_tipo_tipoid_tipo",
                table: "empleado");

            migrationBuilder.AlterColumn<int>(
                name: "tipoid_tipo",
                table: "empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId_departamento",
                table: "empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_departamentos_DepartamentoId_departamento",
                table: "empleado",
                column: "DepartamentoId_departamento",
                principalTable: "departamentos",
                principalColumn: "Id_departamento");

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_tipo_tipoid_tipo",
                table: "empleado",
                column: "tipoid_tipo",
                principalTable: "tipo",
                principalColumn: "id_tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleado_departamentos_DepartamentoId_departamento",
                table: "empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_empleado_tipo_tipoid_tipo",
                table: "empleado");

            migrationBuilder.AlterColumn<int>(
                name: "tipoid_tipo",
                table: "empleado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId_departamento",
                table: "empleado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_departamentos_DepartamentoId_departamento",
                table: "empleado",
                column: "DepartamentoId_departamento",
                principalTable: "departamentos",
                principalColumn: "Id_departamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_empleado_tipo_tipoid_tipo",
                table: "empleado",
                column: "tipoid_tipo",
                principalTable: "tipo",
                principalColumn: "id_tipo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
