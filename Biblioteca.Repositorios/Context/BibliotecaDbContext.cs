using Biblioteca.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;

namespace Biblioteca.Repositorios.Context
{
    public class BibliotecaDbContext: DbContext
    {

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options): 
            base(options)
        
        
        {

        }

        public DbSet<Libro> Libro => Set <Libro>();
        public DbSet<Multa> Multa => Set<Multa>();
        public DbSet<Socio>Socio => Set<Socio>();
        public DbSet<Prestamo > Prestamo => Set<Prestamo>();
        public DbSet<PrestamoLibro> PrestamoLibro => Set<PrestamoLibro>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Libro>(entity =>
            {

                entity.HasKey(l => l.ID);
                entity.Property(l => l.NombreLibro).IsRequired().HasMaxLength(60);
                entity.Property(l => l.NombreAutor).IsRequired().HasMaxLength(60);
                entity.Property(l => l.CreatedAt).IsRequired();
                entity.Property(l => l.Genero).IsRequired();
                entity.Property(l => l.UpdatedAt).IsRequired(false);
                entity.HasQueryFilter(l => !l.Eliminado);

                

            });


            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(p => p.ID);
                entity.Property(p => p.InicioPrestamo).IsRequired();
                entity.Property(p => p.FinalPrestamo).IsRequired();
                entity.Property(p => p.FechaDevolucion).IsRequired(false);
                entity.Property(p => p.Pago).HasPrecision(18,2);
                entity.Property(p => p.UpdatedAt).IsRequired(false);
                entity.HasQueryFilter(p => !p.Eliminado);
                entity.Property(p => p.CreatedAt).IsRequired();

                entity.HasOne(p => p.Socio)
                .WithMany(s => s.Prestamos)
                .HasForeignKey(p => p.SocioId)
                .OnDelete(DeleteBehavior.Restrict);
            });



            modelBuilder.Entity<Socio>(entity =>
            {
                entity.HasKey(s => s.ID);
                entity.Property(s => s.PrimerNombre).IsRequired().HasMaxLength(60);
                entity.Property(s => s.Apellido).IsRequired().HasMaxLength(60);
                entity.Property(s => s.NumeroTelefono).IsRequired().HasMaxLength(20);
                entity.Property(s => s.CedulaCiudadania).IsRequired().HasMaxLength(15);
                entity.Property(s => s.CreatedAt).IsRequired();
                entity.Property(s => s.UpdatedAt).IsRequired(false);
                entity.HasQueryFilter(s => !s.Eliminado);

                entity.HasIndex(s => s.CedulaCiudadania)
                .IsUnique()
                .HasFilter("[Eliminado] = 0");

            });


            modelBuilder.Entity<PrestamoLibro>(entity =>
            {

                entity.HasKey(pl => pl.ID);
                entity.HasQueryFilter(pl => !pl.Eliminado);

                //relacion con libro
                entity.HasOne(pl => pl.Libro)
                .WithMany(l => l.PrestamoLibros)
                .HasForeignKey(pl => pl.LibroId)
                .OnDelete(DeleteBehavior.Restrict);

                //Relacion con prestamo

                entity.HasOne(pl => pl.Prestamo)
                .WithMany(p => p.PrestamoLibros)
                .HasForeignKey(pl => pl.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(pl => new { pl.PrestamoId, pl.LibroId })
                .IsUnique()
                .HasFilter("[Eliminado] = 0");

            });

            modelBuilder.Entity<Multa>(entity =>
            {
                entity.HasKey(m => m.ID);
                entity.Property(m => m.Estado).IsRequired();
                entity.Property(m => m.Monto).HasPrecision(18, 2);
                entity.Property(m => m.Comentario).HasMaxLength(200);
                entity.Property(m => m.CreatedAt).IsRequired();
                entity.Property(m => m.UpdatedAt).IsRequired(false);
                entity.HasQueryFilter(m => !m.Eliminado);

                //relacion con socio

                entity.HasOne(m => m.Socio)
                .WithMany(s => s.Multas)
                .HasForeignKey(m => m.SocioId)
                .OnDelete(DeleteBehavior.Restrict);

                //Relacion con prestamo 

                entity.HasOne(m => m.Prestamo)
                .WithMany(p => p.Multas)
                .HasForeignKey(m => m.PrestamoId)
                .OnDelete(DeleteBehavior.Restrict);




            });

        }
        public override int SaveChanges()
        {
            AplicarAuditoria();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AplicarAuditoria();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AplicarAuditoria()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;   // en vez de DELETE, un UPDATE
                        entry.Entity.Eliminado = true;
                        entry.Entity.EliminadoEn = DateTime.UtcNow;
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }


    }
}
