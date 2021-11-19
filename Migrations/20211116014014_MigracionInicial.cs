using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final_AP1.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "InformacionesContables",
                columns: table => new
                {
                    InformacionContableId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ingresos = table.Column<float>(type: "REAL", nullable: false),
                    FechaIngresos = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionesContables", x => x.InformacionContableId);
                });

            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    NegocioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Actividad = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.NegocioId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoViviendas",
                columns: table => new
                {
                    ViviendaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viviendas", x => x.ViviendaId);
                });

            migrationBuilder.CreateTable(
                name: "Garantes",
                columns: table => new
                {
                    GaranteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Parentesco = table.Column<string>(type: "TEXT", nullable: true),
                    InformacionContableId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantes", x => x.GaranteId);
                    table.ForeignKey(
                        name: "FK_Garantes_InformacionesContables_InformacionContableId",
                        column: x => x.InformacionContableId,
                        principalTable: "InformacionesContables",
                        principalColumn: "InformacionContableId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<int>(type: "INTEGER", nullable: false),
                    Ocupacion = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaIngresos = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Apodo = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    Dependientes = table.Column<string>(type: "TEXT", nullable: true),
                    NegocioId = table.Column<int>(type: "INTEGER", nullable: true),
                    GaranteId = table.Column<int>(type: "INTEGER", nullable: true),
                    ViviendaId = table.Column<int>(type: "INTEGER", nullable: true),
                    SexoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_EstadosCiviles_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadosCiviles",
                        principalColumn: "EstadoCivilId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Garantes_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "Garantes",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "NegocioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Viviendas_ViviendaId",
                        column: x => x.ViviendaId,
                        principalTable: "TipoViviendas",
                        principalColumn: "TipoViviendasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    Cuotas = table.Column<int>(type: "INTEGER", nullable: false),
                    Interes = table.Column<double>(type: "REAL", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cobro = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                    table.ForeignKey(
                        name: "FK_Cobros_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cobros_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Prestamos_DetalleId",
                        column: x => x.DetalleId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_DetalleId",
                        column: x => x.DetalleId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: true),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: true),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true),
                    NegocioId = table.Column<int>(type: "INTEGER", nullable: true),
                    GaranteId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Garantes_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "Garantes",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Negocios_NegocioId",
                        column: x => x.NegocioId,
                        principalTable: "Negocios",
                        principalColumn: "NegocioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Contraseña = table.Column<string>(type: "TEXT", nullable: true),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdministradorId);
                    table.ForeignKey(
                        name: "FK_Administradores_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "EstadosCiviles",
                columns: new[] { "EstadoCivilId", "Descripcion" },
                values: new object[] { 1, "Soltero/a" });

            migrationBuilder.InsertData(
                table: "EstadosCiviles",
                columns: new[] { "EstadoCivilId", "Descripcion" },
                values: new object[] { 2, "Casado/a" });

            migrationBuilder.InsertData(
                table: "EstadosCiviles",
                columns: new[] { "EstadoCivilId", "Descripcion" },
                values: new object[] { 3, "Divorciado/a" });

            migrationBuilder.InsertData(
                table: "EstadosCiviles",
                columns: new[] { "EstadoCivilId", "Descripcion" },
                values: new object[] { 4, "Viuda/o" });

            migrationBuilder.InsertData(
                table: "EstadosCiviles",
                columns: new[] { "EstadoCivilId", "Descripcion" },
                values: new object[] { 5, "Union Libre" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Descripcion" },
                values: new object[] { 1, "Masculino" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Descripcion" },
                values: new object[] { 2, "Femenino" });

            migrationBuilder.InsertData(
                table: "TipoViviendas",
                columns: new[] { "TipoViviendasId", "Descripcion" },
                values: new object[] { 1, "Alquilada" });

            migrationBuilder.InsertData(
                table: "TipoViviendas",
                columns: new[] { "TipoViviendasId", "Descripcion" },
                values: new object[] { 2, "Casa propia" });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_EmpleadoId",
                table: "Administradores",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EstadoCivilId",
                table: "Cliente",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_GaranteId",
                table: "Cliente",
                column: "GaranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_NegocioId",
                table: "Cliente",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_SexoId",
                table: "Cliente",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ViviendaId",
                table: "Cliente",
                column: "TipoViviendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_ClienteId",
                table: "Cobros",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_PrestamoId",
                table: "Cobros",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ClienteId",
                table: "Empleados",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CobroId",
                table: "Empleados",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_GaranteId",
                table: "Empleados",
                column: "GaranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_NegocioId",
                table: "Empleados",
                column: "NegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PrestamoId",
                table: "Empleados",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Garantes_InformacionContableId",
                table: "Garantes",
                column: "InformacionContableId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "CobrosDetalle");

            migrationBuilder.DropTable(
                name: "PrestamosDetalle");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "Garantes");

            migrationBuilder.DropTable(
                name: "Negocios");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "TipoViviendas");

            migrationBuilder.DropTable(
                name: "InformacionesContables");
        }
    }
}
