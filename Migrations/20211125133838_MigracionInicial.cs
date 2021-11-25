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
                name: "Ocupaciones",
                columns: table => new
                {
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.OcupacionId);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
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
                name: "TipoNegocios",
                columns: table => new
                {
                    TipoNegocioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNegocios", x => x.TipoNegocioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoViviendas",
                columns: table => new
                {
                    TipoViviendasId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViviendas", x => x.TipoViviendasId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Clave = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
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
                    Ingresos = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantes", x => x.GaranteId);
                    table.ForeignKey(
                        name: "FK_Garantes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuariosUsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosDetalle_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosDetalle_Usuarios_UsuariosUsuarioId",
                        column: x => x.UsuariosUsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CobroId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobrosDetalle_Cobros_DetalleId",
                        column: x => x.DetalleId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Negocios",
                columns: table => new
                {
                    NegocioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    FechaN = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoNegocioId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negocios", x => x.NegocioId);
                    table.ForeignKey(
                        name: "FK_Negocios_TipoNegocios_TipoNegocioId",
                        column: x => x.TipoNegocioId,
                        principalTable: "TipoNegocios",
                        principalColumn: "TipoNegocioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Negocios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
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
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Apodo = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Dependientes = table.Column<string>(type: "TEXT", nullable: true),
                    NegocioId = table.Column<int>(type: "INTEGER", nullable: true),
                    GaranteId = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoViviendasId = table.Column<int>(type: "INTEGER", nullable: true),
                    SexoId = table.Column<int>(type: "INTEGER", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "INTEGER", nullable: true),
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_Cliente_Ocupaciones_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupaciones",
                        principalColumn: "OcupacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_TipoViviendas_TipoViviendasId",
                        column: x => x.TipoViviendasId,
                        principalTable: "TipoViviendas",
                        principalColumn: "TipoViviendasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
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
                    Balance = table.Column<float>(type: "REAL", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moras",
                columns: table => new
                {
                    MoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moras", x => x.MoraId);
                    table.ForeignKey(
                        name: "FK_Moras_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moras_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosDetalle",
                columns: table => new
                {
                    CuotaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCuota = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Interes = table.Column<double>(type: "REAL", nullable: false),
                    Capital = table.Column<int>(type: "INTEGER", nullable: false),
                    BalanceInteres = table.Column<int>(type: "INTEGER", nullable: false),
                    BalanceCapital = table.Column<int>(type: "INTEGER", nullable: false),
                    PrestamoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosDetalle", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Prestamos_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestamosDetalle_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
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
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 11, "Representante de ventas" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 10, "Asesor Financiero" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 9, "Consultor de Ciberseguridad" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 8, "Diseñador Grafico" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 7, "Asistente Medico" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 4, "Arquitecto/a" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 5, "Contable" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 12, "Odontologo" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 3, "Abogado/a" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 2, "Doctor/a" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 1, "Ingeniero/a" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionId", "Descripcion" },
                values: new object[] { 6, "Desarrolador Web" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 3, "Este permiso puede agregar datos", "Agrega" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 1, "Este permiso puede modificar datos", "Modifica" });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoId", "Descripcion", "Nombre" },
                values: new object[] { 2, "Este permiso puede eliminar datos", "Elimina" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Descripcion" },
                values: new object[] { 1, "Masculino" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Descripcion" },
                values: new object[] { 2, "Femenino" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 6, "Guarderia" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 1, "Colmado" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 2, "Hospital" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 3, "Almacen" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 4, "Oficina" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 5, "Banco" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 7, "Supermercado" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 8, "Libreria" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 9, "Veterinaria" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 10, "Botica" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 11, "Farmacia" });

            migrationBuilder.InsertData(
                table: "TipoNegocios",
                columns: new[] { "TipoNegocioId", "Descripcion" },
                values: new object[] { 12, "Clinica" });

            migrationBuilder.InsertData(
                table: "TipoViviendas",
                columns: new[] { "TipoViviendasId", "Descripcion" },
                values: new object[] { 1, "Alquilada" });

            migrationBuilder.InsertData(
                table: "TipoViviendas",
                columns: new[] { "TipoViviendasId", "Descripcion" },
                values: new object[] { 2, "Casa propia" });

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
                column: "NegocioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_OcupacionId",
                table: "Cliente",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_SexoId",
                table: "Cliente",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoViviendasId",
                table: "Cliente",
                column: "TipoViviendasId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_ClienteId",
                table: "Cobros",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_PrestamoId",
                table: "Cobros",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalle_CobroId",
                table: "CobrosDetalle",
                column: "CobroId");

            migrationBuilder.CreateIndex(
                name: "IX_Garantes_UsuarioId",
                table: "Garantes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Moras_PrestamoId",
                table: "Moras",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Moras_UsuarioId",
                table: "Moras",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_ClientesId",
                table: "Negocios",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_TipoNegocioId",
                table: "Negocios",
                column: "TipoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Negocios_UsuarioId",
                table: "Negocios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_UsuarioId",
                table: "Prestamos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosDetalle_PrestamoId",
                table: "PrestamosDetalle",
                column: "PrestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosDetalle_RolId",
                table: "UsuariosDetalle",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosDetalle_UsuariosUsuarioId",
                table: "UsuariosDetalle",
                column: "UsuariosUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Cliente_ClienteId",
                table: "Cobros",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobros_Prestamos_PrestamoId",
                table: "Cobros",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "PrestamoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Negocios_Cliente_ClientesId",
                table: "Negocios",
                column: "ClientesId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_EstadosCiviles_EstadoCivilId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Garantes_GaranteId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Negocios_NegocioId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "CobrosDetalle");

            migrationBuilder.DropTable(
                name: "Moras");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "PrestamosDetalle");

            migrationBuilder.DropTable(
                name: "UsuariosDetalle");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "Garantes");

            migrationBuilder.DropTable(
                name: "Negocios");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoNegocios");

            migrationBuilder.DropTable(
                name: "Ocupaciones");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "TipoViviendas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
