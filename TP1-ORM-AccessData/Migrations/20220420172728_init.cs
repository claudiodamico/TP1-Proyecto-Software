using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1_ORM_AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoDeAlquileres",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDeAlquileres", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Editorial = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Edicion = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: true),
                    FechaAlquiler = table.Column<DateTime>(type: "date", nullable: true),
                    FechaReserva = table.Column<DateTime>(type: "date", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Cliente_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Alquileres_EstadoDeAlquileres_Estado",
                        column: x => x.Estado,
                        principalTable: "EstadoDeAlquileres",
                        principalColumn: "EstadoId");
                    table.ForeignKey(
                        name: "FK_Alquileres_Libros_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Libros",
                        principalColumn: "ISBN");
                });

            migrationBuilder.InsertData(
                table: "EstadoDeAlquileres",
                columns: new[] { "EstadoId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Reservado" },
                    { 2, "Alquilado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "ISBN", "Autor", "Edicion", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "8416543798", "Shirow Masamune", "2017", "Planeta Cómic", "https://images-na.ssl-images-amazon.com/images/I/51qmqp1+IuL._SX327_BO1,204,203,200_.jpg", 16, "Ghost in the Shell" },
                    { "9505470673", "J. R. R. Tolkien", "2001", "Minotauro ediciones avd", "https://images.cdn2.buscalibre.com/fit-in/360x360/ed/77/ed77b8615c4e99183fa8531a90736da2.jpg", 15, "El Senor de los Anillos I" },
                    { "9781789092110", "Tanya Lapointe", "2020", "Titan Books Ltd", "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/7890/9781789092110.jpg", 20, "Blade Runner 2049" },
                    { "9786073128841", "George R. R. Martin", "2015", "Debolsillo", "https://images.cdn2.buscalibre.com/fit-in/360x360/1d/18/1d18287dbc8c35da55595f045483183f.jpg", 12, "Choque de Reyes" },
                    { "9788445073735", "J. R. R. Tolkien", "2002", "Minotauro ediciones avd", "https://images.cdn3.buscalibre.com/fit-in/360x360/ab/57/ab5704b44ae7b4b945e4ab2f92061e74.jpg", 10, "El señor de los anillos II" },
                    { "9788445073742", "J. R. R. Tolkien", "2002", "Minotauro ediciones avd", "https://images.cdn3.buscalibre.com/fit-in/360x360/6c/c7/6cc7e8d88806fcf50711f82d6187c42e.jpg", 20, "El Señor de los Anillos III" },
                    { "9789563251982", "George R. R. Martin", "2015", "Debolsillo", "https://images.cdn3.buscalibre.com/fit-in/360x360/2c/fe/2cfea65fe12f59a0d4b20ab05a294953.jpg", 14, "Festin de Cuervos" },
                    { "9789563251999", "George R. R. Martin", "2015", "Debolsillo", "https://images.cdn2.buscalibre.com/fit-in/360x360/11/84/1184e14aa656b6099a8e88751597515e.jpg", 18, "Tormenta de Espadas" },
                    { "9789563252033", "George R. R. Martin", "2015", "Debolsillo", "https://images.cdn2.buscalibre.com/fit-in/360x360/2e/0f/2e0f16435c40946b5ccf9ea619e833f9.jpg", 30, "Danza de Dragones" },
                    { "9789877251470", "George R. R. Martin", "2014", "Debolsillo", "https://images.cdn1.buscalibre.com/fit-in/360x360/3d/76/3d76043985ab3665f9bbbaa4fdf4deaa.jpg", 10, "Juego de Tronos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Cliente",
                table: "Alquileres",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_Estado",
                table: "Alquileres",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ISBN",
                table: "Alquileres",
                column: "ISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoDeAlquileres");

            migrationBuilder.DropTable(
                name: "Libros");
        }
    }
}
