using Microsoft.EntityFrameworkCore;
using Entity_Framework_Csharp;

namespace Entity_Framework_Csharp;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de20"), Nombre = "Actividades Pendientes", Peso = 2});
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de02"), Nombre = "Actividades Personales", Peso = 50});
        modelBuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de08"), CategoriaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de20"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.UtcNow });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de15"), CategoriaId = Guid.Parse("baf7eeb1-8841-4474-9f22-fb61b644de02"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula", FechaCreacion = DateTime.UtcNow });
        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.FechaCreacion).IsRequired();
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}