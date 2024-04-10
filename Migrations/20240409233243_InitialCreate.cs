using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace activos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    Iddepartamento = table.Column<int>(name: "Id_departamento", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.Iddepartamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo",
                columns: table => new
                {
                    Idtipo = table.Column<int>(name: "Id_tipo", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipopersona = table.Column<string>(name: "Tipo_persona", type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo", x => x.Idtipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoActivos",
                columns: table => new
                {
                    Idtipoactivo = table.Column<int>(name: "Id_tipo_activo", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContableCompra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaContableDepreciacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActivos", x => x.Idtipoactivo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    Idempleado = table.Column<int>(name: "Id_empleado", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cedula = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iddepartamento = table.Column<int>(name: "Id_departamento", type: "int", nullable: false),
                    Idtipo = table.Column<int>(name: "Id_tipo", type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.Idempleado);
                    table.ForeignKey(
                        name: "FK_empleado_departamentos_Id_departamento",
                        column: x => x.Iddepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id_departamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleado_tipo_Id_tipo",
                        column: x => x.Idtipo,
                        principalTable: "tipo",
                        principalColumn: "Id_tipo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    Idactivofijo = table.Column<int>(name: "Id_activo_fijo", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iddepartamento = table.Column<int>(name: "Id_departamento", type: "int", nullable: false),
                    Idtipoactivo = table.Column<int>(name: "Id_tipo_activo", type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepreciacionAcumulada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosFijos", x => x.Idactivofijo);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_TipoActivos_Id_tipo_activo",
                        column: x => x.Idtipoactivo,
                        principalTable: "TipoActivos",
                        principalColumn: "Id_tipo_activo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_departamentos_Id_departamento",
                        column: x => x.Iddepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id_departamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CalculoDepreciaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnioProceso = table.Column<int>(type: "int", nullable: false),
                    MesProceso = table.Column<int>(type: "int", nullable: false),
                    ActivoFijoId = table.Column<int>(type: "int", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MontoDepreciado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepreciacionAcumulada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuentaCompra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CuentaDepreciacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoDepreciaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculoDepreciaciones_ActivosFijos_ActivoFijoId",
                        column: x => x.ActivoFijoId,
                        principalTable: "ActivosFijos",
                        principalColumn: "Id_activo_fijo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_Id_departamento",
                table: "ActivosFijos",
                column: "Id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_Id_tipo_activo",
                table: "ActivosFijos",
                column: "Id_tipo_activo");

            migrationBuilder.CreateIndex(
                name: "IX_CalculoDepreciaciones_ActivoFijoId",
                table: "CalculoDepreciaciones",
                column: "ActivoFijoId");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_Id_departamento",
                table: "empleado",
                column: "Id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_empleado_Id_tipo",
                table: "empleado",
                column: "Id_tipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoDepreciaciones");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "tipo");

            migrationBuilder.DropTable(
                name: "TipoActivos");

            migrationBuilder.DropTable(
                name: "departamentos");
        }
    }
}
