using Microsoft.EntityFrameworkCore;
using TP1_ORM_AccessData.Entities;

namespace TP1_ORM_AccessData.Data
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext() { }

        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DbLibreria;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.ISBN);

                entity.Property(e => e.ISBN)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Edicion)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Editorial)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(45);


            });

            modelBuilder.Entity<EstadoDeAlquiler>(entity =>
            {
                entity.HasKey(e => e.EstadoId);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.Property(e => e.FechaAlquiler).HasColumnType("date");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.Property(e => e.FechaReserva).HasColumnType("date");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Alquileres)
                    .HasForeignKey(d => d.Cliente);

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Alquileres)
                    .HasForeignKey(d => d.Estado);

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.Alquileres)
                    .HasForeignKey(d => d.Isbn);
            });

            //INSERTS

            modelBuilder.Entity<Libro>().HasData(
            new Libro
            {
                ISBN = "9505470673",
                Titulo = "El Senor de los Anillos I",
                Autor = "J. R. R. Tolkien",
                Editorial = "Minotauro ediciones avd",
                Edicion = "2001",
                Stock = 15,
                Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/ed/77/ed77b8615c4e99183fa8531a90736da2.jpg",
            },
             new Libro
             {
                 ISBN = "9788445073735",
                 Titulo = "El señor de los anillos II",
                 Autor = "J. R. R. Tolkien",
                 Editorial = "Minotauro ediciones avd",
                 Edicion = "2002",
                 Stock = 10,
                 Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/ab/57/ab5704b44ae7b4b945e4ab2f92061e74.jpg",
             },
              new Libro
              {
                  ISBN = "9788445073742",
                  Titulo = "El Señor de los Anillos III",
                  Autor = "J. R. R. Tolkien",
                  Editorial = "Minotauro ediciones avd",
                  Edicion = "2002",
                  Stock = 20,
                  Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/6c/c7/6cc7e8d88806fcf50711f82d6187c42e.jpg",
              },
              new Libro
              {
                  ISBN = "9789877251470",
                  Titulo = "Juego de Tronos",
                  Autor = "George R. R. Martin",
                  Editorial = "Debolsillo",
                  Edicion = "2014",
                  Stock = 10,
                  Imagen = "https://images.cdn1.buscalibre.com/fit-in/360x360/3d/76/3d76043985ab3665f9bbbaa4fdf4deaa.jpg",
              },
              new Libro
              {
                  ISBN = "9786073128841",
                  Titulo = "Choque de Reyes",
                  Autor = "George R. R. Martin",
                  Editorial = "Debolsillo",
                  Edicion = "2015",
                  Stock = 12,
                  Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/1d/18/1d18287dbc8c35da55595f045483183f.jpg",
              },
              new Libro
              {
                  ISBN = "9789563251999",
                  Titulo = "Tormenta de Espadas",
                  Autor = "George R. R. Martin",
                  Editorial = "Debolsillo",
                  Edicion = "2015",
                  Stock = 18,
                  Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/11/84/1184e14aa656b6099a8e88751597515e.jpg",
              },
              new Libro
              {
                  ISBN = "9789563251982",
                  Titulo = "Festin de Cuervos",
                  Autor = "George R. R. Martin",
                  Editorial = "Debolsillo",
                  Edicion = "2015",
                  Stock = 14,
                  Imagen = "https://images.cdn3.buscalibre.com/fit-in/360x360/2c/fe/2cfea65fe12f59a0d4b20ab05a294953.jpg",
              },
              new Libro
              {
                  ISBN = "9789563252033",
                  Titulo = "Danza de Dragones",
                  Autor = "George R. R. Martin",
                  Editorial = "Debolsillo",
                  Edicion = "2015",
                  Stock = 30,
                  Imagen = "https://images.cdn2.buscalibre.com/fit-in/360x360/2e/0f/2e0f16435c40946b5ccf9ea619e833f9.jpg",
              },
              new Libro
              {
                  ISBN = "9781789092110",
                  Titulo = "Blade Runner 2049",
                  Autor = "Tanya Lapointe",
                  Editorial = "Titan Books Ltd",
                  Edicion = "2020",
                  Stock = 20,
                  Imagen = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9781/7890/9781789092110.jpg",
              },
              new Libro
              {
                  ISBN = "8416543798",
                  Titulo = "Ghost in the Shell",
                  Autor = "Shirow Masamune",
                  Editorial = "Planeta Cómic",
                  Edicion = "2017",
                  Stock = 16,
                  Imagen = "https://images-na.ssl-images-amazon.com/images/I/51qmqp1+IuL._SX327_BO1,204,203,200_.jpg",
              });

            modelBuilder.Entity<EstadoDeAlquiler>().HasData(
                new EstadoDeAlquiler
                {
                    EstadoId = 1,
                    Descripcion = "Reservado"
                },
                new EstadoDeAlquiler
                {
                    EstadoId = 2,
                    Descripcion = "Alquilado"
                },
                new EstadoDeAlquiler
                {
                    EstadoId = 3,
                    Descripcion = "Cancelado"
                });
            

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<EstadoDeAlquiler> EstadoDeAlquileres { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
    }
}
